namespace CapaPresentacion.Formularios.FormsClientes
{
    using System;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using CapaEntidades;
    using CapaNegocio;
    using CapaPresentacion.Formularios.FormsPrincipales;
    using CapaPresentacion.Formularios.FormsReportes;
    using Syncfusion.WinForms.Controls;

    public partial class FrmClientes : SfForm
    {
        PoperContainer container;

        public FrmClientes()
        {
            InitializeComponent();

            #region PROPIEDADES DE FORMULARIO
            this.Style.TitleBar.Height = 26;
            this.Style.TitleBar.BackColor = Color.White;
            this.Style.TitleBar.IconBackColor = Color.FromArgb(15, 161, 212);
            this.BackColor = Color.White;
            this.Style.TitleBar.ForeColor = ColorTranslator.FromHtml("#343434");
            this.Style.TitleBar.CloseButtonForeColor = Color.DarkGray;
            this.Style.TitleBar.MaximizeButtonForeColor = Color.DarkGray;
            this.Style.TitleBar.MinimizeButtonForeColor = Color.DarkGray;
            this.Style.TitleBar.HelpButtonForeColor = Color.DarkGray;
            this.Style.TitleBar.IconHorizontalAlignment = HorizontalAlignment.Left;
            this.Style.TitleBar.Font = this.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.Style.TitleBar.TextHorizontalAlignment = HorizontalAlignment.Center;
            this.Style.TitleBar.TextVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            #endregion

            this.btnReporteClientes.Click += BtnReporteClientes_Click;
            this.Load += FrmClientes_Load;
            this.dateBusqueda.ValueChanged += DateBusqueda_ValueChanged;
        }

        private void DateBusqueda_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker date = (DateTimePicker)sender;
            this.LoadReporteDiario(date.Value);
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            MainController main = MainController.GetInstance();
            this.dateBusqueda.MinDate = main.Cobro.Fecha_apertura;

            this.LoadReporteDiario(DateTime.Now);
        }

        private void BtnReporteClientes_Click(object sender, EventArgs e)
        {
            MensajeEspera.ShowWait("Cargando reporte...");
            DataTable dtClientes = new DataTable("Clientes");
            dtClientes.Columns.Add("Id_cliente", typeof(int));
            dtClientes.Columns.Add("Nombre_cliente", typeof(string));
            dtClientes.Columns.Add("Celular_cliente", typeof(string));
            dtClientes.Columns.Add("Referencia_articulo", typeof(string));
            dtClientes.Columns.Add("Saldo_restante", typeof(string));
            dtClientes.Columns.Add("Venta_total", typeof(string));
            dtClientes.Columns.Add("Fecha_venta", typeof(string));
            dtClientes.Columns.Add("Fecha_ultimo_pago", typeof(string));
            dtClientes.Columns.Add("Dias_mora", typeof(int));

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
            MainController main = MainController.GetInstance();

            DataTable dtVentas =
                NVentas.BuscarVentas("ID COBRO", main.Id_cobro.ToString(), out string rpta);
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

                    DateTime fecharegistro = DateTime.Parse("04/05/2018 8:34:01");
                    TimeSpan timeSpan = DateTime.Now - fecha_ultimo_pago;
                    double dias_mora = timeSpan.TotalDays;

                    DataRow newRow = dtClientes.NewRow();
                    newRow["Id_cliente"] = id_cliente;
                    newRow["Nombre_cliente"] = nombre_cliente;
                    newRow["Celular_cliente"] = celular_cliente;
                    newRow["Referencia_articulo"] = referencia_articulo;
                    newRow["Saldo_restante"] = saldo_restante.ToString("C");
                    newRow["Venta_total"] = total_venta.ToString("C");
                    newRow["Fecha_venta"] = fecha_venta.ToString("dd-MM-yyyy");
                    newRow["Fecha_ultimo_pago"] = fecha_ultimo_pago.ToString("dd-MM-yyyy");
                    newRow["Dias_mora"] = dias_mora;
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

        private void LoadReporteDiario(DateTime fecha)
        {
            MensajeEspera.ShowWait("Cargando reporte...");
            StringBuilder info = new StringBuilder();
            //Obtener el turno de esta fecha
            DataTable dtTurnos =
                NTurnos.BuscarTurnos("FECHA INICIO", "2021-02-10", out string rpta);
            if (dtTurnos != null)
            {
                Turnos turno = new Turnos(dtTurnos.Rows[0]);
                info.Append("Valor inicial en caja ").Append(turno.Valor_inicial.ToString("C")).Append(Environment.NewLine);
                info.Append("Se empezó con ").Append(turno.Clientes_iniciales).Append(" clientes y se terminó con ").Append(turno.Clientes_total).Append(Environment.NewLine);

                //Obtener los clientes nuevos
                DataTable dtVentas = NVentas.BuscarVentas("FECHA ID COBRO", "2021-02-10", out rpta);
                if (dtVentas != null)
                {
                    info.Append("Clientes nuevos o renovados ").Append(dtVentas.Rows.Count).Append(Environment.NewLine);
                }
                else
                    info.Append("No hubieron clientes nuevos o renovados ");

                info.Append("Total de ventas y renovaciones ").Append(turno.Recaudo_ventas_nuevas.ToString("C")).Append(Environment.NewLine);
                info.Append("Recaudo pretendido ").Append(turno.Recaudo_pretendido_turno.ToString("C")).Append(Environment.NewLine);
                info.Append("Total recaudado ").Append(turno.Recaudo_cuotas.ToString("C")).Append(Environment.NewLine);
                info.Append("Otros ingresos ").Append(turno.Recaudo_otros.ToString("C")).Append(Environment.NewLine);

                if (turno.Gastos_total == 0)
                    info.Append("No hubieron gastos").Append(Environment.NewLine);
                else
                    info.Append("Gastos/Egresos ").Append(turno.Gastos_total.ToString("C")).Append(Environment.NewLine);

                info.Append("CAJA FINAL ").Append(turno.Recaudo_real.ToString("C")).Append(Environment.NewLine);

                if (dtVentas != null)
                {
                    info.Append("Resumen de clientes nuevos o renovados").Append(Environment.NewLine);
                    foreach (DataRow row in dtVentas.Rows)
                    {
                        Ventas venta = new Ventas(row);
                        info.Append("- Nombre: ").Append(venta.Cliente.NombreCompleto).Append(" - Celular: ").Append(venta.Cliente.Celular);
                        info.Append("- Valor préstamo: ").Append(venta.Valor_venta).Append(" - Plazo: ").Append(venta.Numero_cuotas).Append(Environment.NewLine);
                    }
                }

                FrmReporteDiario frmReporteDiario = new FrmReporteDiario
                {
                    FormBorderStyle = FormBorderStyle.None,
                    TopMost = false,
                    TopLevel = false,
                    Dock = DockStyle.Fill,
                    InformacionTurno = info.ToString(),
                    FechaHoraReporte = "Fecha y hora de generación: " + DateTime.Now.ToLongDateString(),
                    FechaHoraTurno = "Fecha y hora de turno: " + turno.Fecha_inicio_turno.ToLongDateString(),
                };

                if (this.gbResultados.Controls.Count > 0)
                    this.gbResultados.Controls.Clear();

                this.gbResultados.Controls.Add(frmReporteDiario);
                frmReporteDiario.Show();
            }
            else
            {
                info.Append("No se encontró el turno");
                Mensajes.MensajeInformacion("No se encontró el turno en la fecha seleccionada", "Entendido");
            }
            MensajeEspera.CloseForm();
        }

        private void BtnImportarClientes_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCargarClientes frm = new FrmCargarClientes
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill,
                };
                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                else
                {
                    this.gbResultados.Controls.Add(frm);
                    this.gbResultados.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnImportarClientes_Click",
                    "Hubo un error con el botón importar clientes", ex.Message);
            }
        }

        private Form ComprobarExistencia(Form form)
        {
            if (container != null)
                container.Close();

            Form frmDevolver = null;
            foreach (Form frm in this.gbResultados.Controls)
            {
                if (frm.Name.Equals(form.Name))
                {
                    frmDevolver = frm;
                    break;
                }

            }
            return frmDevolver;
        }
    }
}
