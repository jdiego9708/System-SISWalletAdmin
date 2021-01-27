using CapaEntidades;
using CapaEntidades.Helpers;
using CapaNegocio;
using CapaPresentacion.Formularios.FormsClientes;
using CapaPresentacion.Formularios.FormsEstadisticas;
using CapaPresentacion.Formularios.FormsPrincipales;
using CapaPresentacion.Formularios.FormsReportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.FormsArticulos
{
    public partial class FrmObservarArticulos : Form
    {
        public FrmObservarArticulos()
        {
            InitializeComponent();
            this.btnNuevoArticulo.Click += BtnNuevoArticulo_Click;
            this.btnRefresh.Click += BtnRefresh_Click;
            this.btnEstadisticas.Click += BtnEstadisticas_Click;
            this.Load += FrmObservarArticulos_Load;
            this.btnImprimirArticulos.Click += BtnImprimirArticulos_Click;
            this.btnClientes.Click += BtnClientes_Click;
            this.FormClosed += FrmObservarArticulos_FormClosed;
            this.btnAddCliente.Click += BtnAddCliente_Click;
        }

        private void BtnAddCliente_Click(object sender, EventArgs e)
        {
            FrmNuevoCliente frmNuevoCliente = new FrmNuevoCliente
            {
                StartPosition = FormStartPosition.CenterScreen,
            };
            frmNuevoCliente.Show();
        }

        private void FrmObservarArticulos_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private async void BtnClientes_Click(object sender, EventArgs e)
        {
            MensajeEspera.ShowWait("Cargando reporte...");

            MainController main = MainController.GetInstance();
            int id_cobro = main.Turno.Id_cobro;

            DataTable dtClientes = new DataTable("Clientes");
            dtClientes.Columns.Add("Id_cliente", typeof(int));
            dtClientes.Columns.Add("Nombre_cliente", typeof(string));
            dtClientes.Columns.Add("Celular_cliente", typeof(string));
            dtClientes.Columns.Add("Referencia_articulo", typeof(string));
            dtClientes.Columns.Add("Saldo_restante", typeof(string));
            dtClientes.Columns.Add("Venta_total", typeof(string));
            dtClientes.Columns.Add("Fecha_venta", typeof(string));
            dtClientes.Columns.Add("Fecha_ultimo_pago", typeof(string));

            int id_cliente = 0;
            string nombre_cliente = string.Empty;
            string celular_cliente = string.Empty;
            string referencia_articulo = string.Empty;
            decimal saldo_restante = 0;
            decimal total_venta = 0;
            DateTime fecha_venta = DateTime.Now;
            decimal suma_ventas = 0;
            decimal suma_saldos = 0;
            DateTime fecha_ultimo_pago = DateTime.Now;

            DataTable dtVentas =
                NVentas.BuscarVentas("ID COBRO", id_cobro.ToString(), out string rpta);
            if (dtVentas != null)
            {
                foreach(DataRow row in dtVentas.Rows)
                {
                    Ventas venta = new Ventas(row);
                    id_cliente = venta.Id_cliente;
                    nombre_cliente = venta.Cliente.NombreCompleto;
                    celular_cliente = venta.Cliente.Celular;
                    total_venta = venta.Total_venta;
                    fecha_venta = venta.Fecha_venta;
                    suma_ventas += venta.Total_venta;

                    var (dtDetalleArticulos, rptaBusqueda) = 
                        await NArticulos.BuscarArticulos("ID VENTA", venta.Id_venta.ToString());
                    if (dtDetalleArticulos != null)
                    {
                        StringBuilder referencias = new StringBuilder();
                        referencias.Append(dtDetalleArticulos.Rows.Count + " referencias: ");
                        foreach(DataRow rowArt in dtDetalleArticulos.Rows)
                        {
                            Detalle_articulos_venta detalle = new Detalle_articulos_venta(rowArt);
                            referencias.Append("(" + detalle.Articulo.Id_articulo + ") ");
                            referencias.Append(detalle.Articulo.Referencia_articulo + " - ");
                        }
                        referencia_articulo = referencias.ToString();
                    }
                    else
                    {
                        referencia_articulo = "NO SE ENCONTRARON LAS REFERENCIAS";
                    }

                    //Buscar los agendamientos de cada venta para ver su saldo restante
                    DataTable dtAgendamientos = NAgendamiento_cobros.BuscarAgendamientos("ID VENTA", venta.Id_venta.ToString(),
                        out rpta);
                    if (dtAgendamientos != null)
                    {
                        Agendamiento_cobros ag = new Agendamiento_cobros(dtAgendamientos.Rows[0]);
                        saldo_restante = ag.Saldo_restante;
                        suma_saldos += ag.Saldo_restante;
                        fecha_ultimo_pago = ag.Fecha_cobro;
                    }

                    DataRow newRow = dtClientes.NewRow();
                    newRow["Id_cliente"] = id_cliente;
                    newRow["Nombre_cliente"] = nombre_cliente;
                    newRow["Celular_cliente"] = celular_cliente;
                    newRow["Referencia_articulo"] = referencia_articulo;
                    newRow["Saldo_restante"] = saldo_restante.ToString("C");
                    newRow["Venta_total"] = total_venta.ToString("C");
                    newRow["Fecha_venta"] = fecha_venta.ToString("dd-MM-yyyy");
                    newRow["Fecha_ultimo_pago"] = fecha_ultimo_pago.ToString("dd-MM-yyyy");
                    dtClientes.Rows.Add(newRow);
                }

                if (dtClientes.Rows.Count > 0)
                {
                    MensajeEspera.CloseForm();
                    //Enviar informe
                    FrmReporteClientes frmReporteClientes = new FrmReporteClientes
                    {
                        WindowState = FormWindowState.Maximized,
                        dtClientes = dtClientes,
                        Total_saldos = suma_saldos.ToString("C"),
                        Total_ventas = suma_ventas.ToString("C"),
                    };
                    frmReporteClientes.Show();
                }
                else
                    Mensajes.MensajeInformacion("No se encontraron clientes", "Entendido");
            }
            else
                Mensajes.MensajeInformacion("No se encontraron clientes", "Entendido");

            MensajeEspera.CloseForm();
        }

        private void BtnImprimirArticulos_Click(object sender, EventArgs e)
        {
            if (this.DtArticulos != null)
            {
                DataTable dtArticulosImpresion = new DataTable("Articulos");
                dtArticulosImpresion.Columns.Add("Id_articulo", typeof(int));
                dtArticulosImpresion.Columns.Add("Referencia_articulo", typeof(string));
                dtArticulosImpresion.Columns.Add("Stock_articulo", typeof(int));
                dtArticulosImpresion.Columns.Add("Proveedor", typeof(string));
                dtArticulosImpresion.Columns.Add("Valor_proveedor", typeof(string));
                dtArticulosImpresion.Columns.Add("Valor_cliente", typeof(string));

                foreach (DataRow row in this.DtArticulos.Rows)
                {
                    int id_articulo = Convert.ToInt32(row["Id_articulo"]);
                    string referencia = Convert.ToString(row["Referencia_articulo"]);
                    int stock = Convert.ToInt32(row["Cantidad_articulo"]);
                    string proveedor = Convert.ToString(row["Nombre_proveedor"]);
                    decimal valor_proveedor = Convert.ToDecimal(row["Valor_proveedor"]);
                    decimal valor_articulo = Convert.ToDecimal(row["Valor_articulo"]);

                    DataRow rowNew = dtArticulosImpresion.NewRow();
                    rowNew["Id_articulo"] = id_articulo;
                    rowNew["Referencia_articulo"] = referencia;
                    rowNew["Stock_articulo"] = stock;
                    rowNew["Proveedor"] = proveedor;
                    rowNew["Valor_proveedor"] = valor_proveedor.ToString("C");
                    rowNew["Valor_cliente"] = valor_articulo.ToString("C");
                    dtArticulosImpresion.Rows.Add(rowNew);
                }

                FrmReporteArticulos frmReporteArticulos = new FrmReporteArticulos
                {
                    WindowState = FormWindowState.Maximized,
                    dtArticulos = dtArticulosImpresion,
                };
                frmReporteArticulos.Show();
            }
            else
                Mensajes.MensajeInformacion("NO hay artículos para imprimir", "Entendido");
        }

        private async void FrmObservarArticulos_Load(object sender, EventArgs e)
        {
            this.Show();
            await this.LoadArticulos("COMPLETO", "");
        }

        private void BtnEstadisticas_Click(object sender, EventArgs e)
        {
            FrmEstadisticasCobro frmEstadisticasCobro = new FrmEstadisticasCobro
            {
                WindowState = FormWindowState.Maximized,
            };
            frmEstadisticasCobro.Show();
        }

        private async void BtnRefresh_Click(object sender, EventArgs e)
        {
            await this.LoadArticulos("COMPLETO", "");
        }

        private void BtnNuevoArticulo_Click(object sender, EventArgs e)
        {
            FrmNuevoArticulo frmNuevoArticulo = new FrmNuevoArticulo
            {
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal,
            };
            frmNuevoArticulo.OnArticuloSuccess += FrmNuevoArticulo_OnArticuloSuccess;
            frmNuevoArticulo.Show();
        }

        private async void FrmNuevoArticulo_OnArticuloSuccess(object sender, EventArgs e)
        {     
            await this.LoadArticulos("COMPLETO", "");
        }

        public async Task LoadArticulos(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                //Verificamos conexión
                Response connection = await ConnectionHelper.CheckConnection();
                //Si la conexión es false mostraremos un mensaje
                if (connection.IsSuccess)
                {
                    var Comprobaciones =
                        await NArticulos.BuscarArticulos(tipo_busqueda, texto_busqueda);

                    if (this.ArticulosList != null)
                        this.ArticulosList.Clear();

                    if (this.panelArticulos.Controls.Count > 0)
                        this.panelArticulos.Controls.Clear();

                    if (Comprobaciones.dtArticulos != null)
                    {
                        this.DtArticulos = Comprobaciones.dtArticulos;
                        List<Articulos> articulos = (from DataRow dr in Comprobaciones.dtArticulos.Rows
                                                     select new Articulos(dr)).ToList();

                        this.ArticulosList = articulos;

                        List<UserControl> controls = new List<UserControl>();
                        foreach (Articulos art in articulos)
                        {
                            ArticuloItem artItem = new ArticuloItem
                            {
                                Articulo = art,
                            };
                            artItem.OnBtnAddStock += ArtItem_OnBtnAddStock;
                            controls.Add(artItem);
                        }

                        this.panelArticulos.PageSize = 30;
                        this.panelArticulos.OnBsPositionChanged += PanelArticulos_OnBsPositionChanged;
                        this.panelArticulos.SetPagedDataSource(controls, this.bindingNavigator1);
                        this.positionChanged = 1;

                        if (this.ArticulosList.Count <= 0)
                            this.lblResultados.Text = "No hay articulos";
                        else if (this.ArticulosList.Count == 1)
                            this.lblResultados.Text = "Hay un articulo";
                        else if (this.ArticulosList.Count > 1)
                            this.lblResultados.Text = "Se encontraron " + this.ArticulosList.Count + " articulos.";
                    }
                    else
                    {
                        this.lblResultados.Text = "No hay articulos";

                        if (!Comprobaciones.rpta.Equals("OK"))
                            throw new Exception(Comprobaciones.rpta);
                    }
                }
                else
                    Mensajes.MensajeInformacion("Verifique la conexión a internet", "Entendido");
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "public async Task LoadArticulos",
                    "Hubo un error al buscar artículos", ex.Message);
            }
        }

        int positionChanged = 1;
        private void PanelArticulos_OnBsPositionChanged(object sender, EventArgs e)
        {
            if (positionChanged != this.panelArticulos.bs.Position)
            {
                this.positionChanged = this.panelArticulos.bs.Position;
                List<UserControl> controls = (List<UserControl>)sender;
                this.panelArticulos.AddArrayControl(controls);
            }
        }

        private void ArtItem_OnBtnAddStock(object sender, EventArgs e)
        {
            Articulos articulo = (Articulos)sender;
            FrmNuevoArticulo frmNuevoArticulo = new FrmNuevoArticulo
            {
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal,
                Articulo = articulo,
            };
            frmNuevoArticulo.OnArticuloSuccess += FrmNuevoArticulo_OnArticuloSuccess;
            frmNuevoArticulo.Show();
            frmNuevoArticulo.AsignarDatos(articulo);
        }

        public void LoadArticulos(DataTable dtArticulos)
        {
            try
            {
                if (this.ArticulosList != null)
                    this.ArticulosList.Clear();

                if (this.panelArticulos.Controls.Count > 0)
                    this.panelArticulos.Controls.Clear();

                if (dtArticulos != null)
                {
                    List<Articulos> articulos = (from DataRow dr in dtArticulos.Rows
                                                 select new Articulos(dr)).ToList();

                    this.ArticulosList = articulos;

                    List<UserControl> controls = new List<UserControl>();
                    foreach (Articulos art in articulos)
                    {
                        ArticuloItem artItem = new ArticuloItem
                        {
                            Articulo = art,
                        };
                        artItem.OnBtnAddStock += ArtItem_OnBtnAddStock;
                        controls.Add(artItem);
                    }

                    this.panelArticulos.PageSize = 30;
                    this.panelArticulos.OnBsPositionChanged += PanelArticulos_OnBsPositionChanged;
                    this.panelArticulos.SetPagedDataSource(controls, this.bindingNavigator1);

                    if (this.ArticulosList.Count <= 0)
                        this.lblResultados.Text = "No hay articulos";
                    else if (this.ArticulosList.Count == 1)
                        this.lblResultados.Text = "Hay un articulo";
                    else if (this.ArticulosList.Count > 1)
                        this.lblResultados.Text = "Se encontraron " + this.ArticulosList.Count + " articulos.";
                }
                else
                {
                    this.lblResultados.Text = "No hay articulos";
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "public async Task LoadArticulos",
                    "Hubo un error al buscar artículos", ex.Message);
            }
        }

        public DataTable DtArticulos { get; set; }

        private List<Articulos> _articulosList;

        public List<Articulos> ArticulosList { get => _articulosList; set => _articulosList = value; }
    }
}
