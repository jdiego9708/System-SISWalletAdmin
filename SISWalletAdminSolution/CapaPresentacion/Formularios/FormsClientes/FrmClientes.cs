using CapaEntidades;
using CapaNegocio;
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

namespace CapaPresentacion.Formularios.FormsClientes
{
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
            this.btnAddCliente.Click += BtnAddCliente_Click;
            this.Load += FrmClientes_Load;
            this.txtBusqueda.OnCustomKeyPress += TxtBusqueda_OnCustomKeyPress;
            this.txtBusqueda.OnPxClick += TxtBusqueda_OnPxClick;
            this.btnRefresh.Click += BtnRefresh_Click;

            this.rdPendientes.CheckedChanged += RdPendientes_CheckedChanged;
            this.rdTerminados.CheckedChanged += RdTerminados_CheckedChanged;

            this.btnReporte.Click += BtnClientes_Click;
            this.btnPrint.Click += BtnPrint_Click;
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                MensajeEspera.ShowWait("Cargando...");

                DataTable dtAgendamiento = new DataTable();
                dtAgendamiento.Columns.Add("Id_agendamiento", typeof(int));
                dtAgendamiento.Columns.Add("Fecha_agendamiento", typeof(string));
                dtAgendamiento.Columns.Add("Nombre_cliente", typeof(string));
                dtAgendamiento.Columns.Add("Celular_cliente", typeof(string));
                dtAgendamiento.Columns.Add("Saldo_restante", typeof(string));
                dtAgendamiento.Columns.Add("Valor_cuota", typeof(string));
                dtAgendamiento.Columns.Add("Valor_pagado", typeof(string));
                dtAgendamiento.Columns.Add("Tipo_cobro", typeof(string));


                if (this.DtAgendamientos != null)
                {
                    decimal total_recaudo = 0;

                    foreach (DataRow row in this.DtAgendamientos.Rows)
                    {
                        Agendamiento_cobros ag = new Agendamiento_cobros(row);

                        int id_agendamiento = ag.Id_agendamiento;
                        DateTime fecha_agendamiento = ag.Fecha_cobro;
                        string nombre_cliente = ag.Venta.Cliente.NombreCompleto;
                        string celular_cliente = ag.Venta.Cliente.Celular;
                        decimal saldo_restante = ag.Saldo_restante;
                        decimal valor_cuota = ag.Valor_cobro;
                        decimal valor_pagado = 0;
                        string tipo_cobro = ag.Tipo_cobro;

                        total_recaudo += valor_cuota;

                        DataRow newRow = dtAgendamiento.NewRow();
                        newRow["Id_agendamiento"] = id_agendamiento;
                        newRow["Fecha_agendamiento"] = fecha_agendamiento.ToString("yyyy-MM-dd");
                        newRow["Nombre_cliente"] = nombre_cliente;
                        newRow["Celular_cliente"] = celular_cliente;
                        newRow["Saldo_restante"] = saldo_restante.ToString("C");
                        newRow["Valor_cuota"] = valor_cuota.ToString("C");
                        newRow["Valor_pagado"] = valor_pagado.ToString("C");
                        newRow["Tipo_cobro"] = tipo_cobro;
                        dtAgendamiento.Rows.Add(newRow);
                    }
                    MensajeEspera.CloseForm();
                    FrmReporteAgendamientos frmReporteAgendamientos = new FrmReporteAgendamientos
                    {
                        DtAgendamientos = dtAgendamiento,
                        Total_recaudo = "Total a recaudar: " + total_recaudo.ToString("C"),
                    };
                    frmReporteAgendamientos.ShowDialog();
                }
                MensajeEspera.CloseForm();
            }
            catch (Exception ex)
            {
                MensajeEspera.CloseForm();
                Mensajes.MensajeErrorCompleto(this.Name, "",
                   "Hubo un error al cargar el reporte", ex.Message);
            }
        }

        private async void BtnClientes_Click(object sender, EventArgs e)
        {
            MensajeEspera.ShowWait("Cargando reporte...");

            MainController main = MainController.GetInstance();
            int id_cobro = main.Id_cobro;

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

            var (rpta, dtVentas) =
                await NVentas.BuscarVentas("ID COBRO ACTIVO", id_cobro.ToString());
            if (dtVentas != null)
            {
                foreach (DataRow row in dtVentas.Rows)
                {
                    Ventas venta = new Ventas(row);
                    id_cliente = venta.Id_cliente;
                    nombre_cliente = venta.Cliente.NombreCompleto;
                    celular_cliente = venta.Cliente.Celular;
                    total_venta = venta.Total_venta;
                    fecha_venta = venta.Fecha_venta;
                    suma_ventas += venta.Total_venta;

                    if (!venta.Tipo_venta.Equals("MIGRACION"))
                    {
                        var (dtDetalleArticulos, rptaBusqueda) =
                        await NArticulos.BuscarArticulos("ID VENTA", venta.Id_venta.ToString());
                        if (dtDetalleArticulos != null)
                        {
                            StringBuilder referencias = new StringBuilder();
                            referencias.Append(dtDetalleArticulos.Rows.Count + " referencias: ");
                            foreach (DataRow rowArt in dtDetalleArticulos.Rows)
                            {
                                Detalle_articulos_venta detalle = new Detalle_articulos_venta(rowArt);
                                referencias.Append("(" + detalle.Articulo.Id_articulo + ") ");
                                referencias.Append(detalle.Articulo.Referencia_articulo + " - ");
                            }
                            referencia_articulo = referencias.ToString();
                        }
                    }

                    //Buscar los agendamientos de cada venta para ver su saldo restante
                    var (rpta1, dtAgendamientos) = await NAgendamiento_cobros.BuscarAgendamientos("ID VENTA", venta.Id_venta.ToString());
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

        private async void BtnRefresh_Click(object sender, EventArgs e)
        {
            await this.LoadAgendamientos("FECHA PENDIENTE", DateTime.Now.ToString("yyyy-MM-dd"));
        }

        private async void RdTerminados_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rd = (RadioButton)sender;
            if (rd.Checked)
            {
                await this.LoadAgendamientos("FECHA TERMINADO", DateTime.Now.ToString("yyyy-MM-dd"));
            }
        }

        private async void RdPendientes_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rd = (RadioButton)sender;
            if (rd.Checked)
            {
                await this.LoadAgendamientos("FECHA PENDIENTE", DateTime.Now.ToString("yyyy-MM-dd"));
            }
        }

        private async void TxtBusqueda_OnPxClick(object sender, EventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            MainController main = MainController.GetInstance();

            if (string.IsNullOrEmpty(txt.Texto))
                await this.LoadAgendamientos("FECHA PENDIENTE", DateTime.Now.ToString("yyyy-MM-dd"));
            else
                await this.LoadClientes("TODO", txt.Texto, "");
        }

        private async void TxtBusqueda_OnCustomKeyPress(object sender, KeyPressEventArgs e)
        {
            CustomTextBox txt = (CustomTextBox)sender;
            if (e.KeyChar == (int)Keys.Enter)
            {
                MainController main = MainController.GetInstance();

                if (string.IsNullOrEmpty(txt.Texto))
                    await this.LoadAgendamientos("FECHA PENDIENTE", DateTime.Now.ToString("yyyy-MM-dd"));
                else
                {
                    if (this.rdCliente.Checked)
                    {
                        if (int.TryParse(txt.Texto, out int id_usuario))
                        {
                            await this.LoadClientes("ID CLIENTE", id_usuario.ToString(), "");
                        }
                        else
                            Mensajes.MensajeInformacion("Debe digitar un código de solo números", "Entendido");
                    }
                    else if (this.rdVenta.Checked)
                    {
                        if (int.TryParse(txt.Texto, out int id_venta))
                        {
                            await this.LoadClientes("ID VENTA", id_venta.ToString(), "");
                        }
                        else
                            Mensajes.MensajeInformacion("Debe digitar un código de solo números", "Entendido");
                    }
                    else
                        await this.LoadClientes("TODO", txt.Texto, "");
                }
            }
        }

        private async void FrmClientes_Load(object sender, EventArgs e)
        {
            MainController main = MainController.GetInstance();
            await this.LoadAgendamientos("FECHA PENDIENTE", DateTime.Now.ToString("yyyy-MM-dd"));

            this.Show();

        }

        private void BtnAddCliente_Click(object sender, EventArgs e)
        {
            FrmNuevoCliente frmNuevoCliente = new FrmNuevoCliente
            {
                StartPosition = FormStartPosition.CenterScreen,
            };
            frmNuevoCliente.Show();
        }

        private async Task LoadClientes(string tipo_busqueda, string texto_busqueda1, string texto_busqueda2)
        {
            try
            {
                MensajeEspera.ShowWait("Cargando...");
                var (dtClientes, rpta) = await NUsuarios.BuscarClientes(tipo_busqueda, texto_busqueda1, texto_busqueda2);

                this.panelClientes.clearDataSource();
                this.positionChanged = 1;

                if (dtClientes != null)
                {
                    List<UserControl> userControls = new List<UserControl>();

                    foreach (DataRow row in dtClientes.Rows)
                    {
                        Ventas venta = new Ventas(row);
                        ClienteSmall clienteSmall = new ClienteSmall
                        {
                            Venta = venta,
                        };
                        clienteSmall.OnRefresh += ClienteSmall_OnRefresh;
                        userControls.Add(clienteSmall);
                    }

                    this.panelClientes.PageSize = 20;
                    this.panelClientes.OnBsPositionChanged += PaneClientes_OnBsPositionChanged;
                    this.panelClientes.SetPagedDataSource(userControls, this.bindingNavigator2);
                }
                MensajeEspera.CloseForm();
            }
            catch (Exception ex)
            {
                MensajeEspera.CloseForm();
                Mensajes.MensajeErrorCompleto(this.Name, "LoadClientes",
                    "Hubo un error al cargar los clientes", ex.Message);
            }
        }

        private async void ClienteSmall_OnRefresh(object sender, EventArgs e)
        {
            await this.LoadAgendamientos("FECHA PENDIENTE", DateTime.Now.ToString("yyyy-MM-dd"));
        }

        private async Task LoadAgendamientos(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                MensajeEspera.ShowWait("Cargando...");
                var (rpta, dtAgendamiento) = await NAgendamiento_cobros.BuscarAgendamientos(tipo_busqueda, texto_busqueda);

                this.panelClientes.clearDataSource();
                this.positionChanged = 1;
                this.DtAgendamientos = dtAgendamiento;

                if (dtAgendamiento != null)
                {
                    List<UserControl> userControls = new List<UserControl>();

                    foreach (DataRow row in dtAgendamiento.Rows)
                    {
                        Agendamiento_cobros ag = new Agendamiento_cobros(row);
                        ClienteSmall clienteSmall = new ClienteSmall
                        {
                            Agendamiento = ag,
                        };
                        clienteSmall.OnRefresh += ClienteSmall_OnRefresh;
                        userControls.Add(clienteSmall);
                    }

                    this.panelClientes.PageSize = 20;
                    this.panelClientes.OnBsPositionChanged += PaneClientes_OnBsPositionChanged;
                    this.panelClientes.SetPagedDataSource(userControls, this.bindingNavigator2);
                }

                MensajeEspera.CloseForm();
                this.Show();
            }
            catch (Exception ex)
            {
                MensajeEspera.CloseForm();
                Mensajes.MensajeErrorCompleto(this.Name, "LoadClientes",
                    "Hubo un error al cargar los agendamientos", ex.Message);
            }
        }

        int positionChanged = 1;
        private void PaneClientes_OnBsPositionChanged(object sender, EventArgs e)
        {
            if (positionChanged != this.panelClientes.bs.Position)
            {
                this.positionChanged = this.panelClientes.bs.Position;
                List<UserControl> controls = (List<UserControl>)sender;
                this.panelClientes.AddArrayControl(controls);
            }
        }

        public DataTable DtAgendamientos { get; set; }
    }
}
