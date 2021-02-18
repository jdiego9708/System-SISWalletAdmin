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
            this.FormClosed += FrmObservarArticulos_FormClosed;
            this.btnAddCliente.Click += BtnAddCliente_Click;
        }

        private void BtnAddCliente_Click(object sender, EventArgs e)
        {
            FrmClientes frmClientes = new FrmClientes
            {
                StartPosition = FormStartPosition.CenterScreen,
            };
            frmClientes.Show();
        }

        private void FrmObservarArticulos_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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
