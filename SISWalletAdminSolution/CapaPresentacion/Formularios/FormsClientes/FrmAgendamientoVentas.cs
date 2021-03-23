using CapaEntidades;
using CapaNegocio;
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
    public partial class FrmAgendamientoVentas : Form
    {
        PoperContainer container;

        public FrmAgendamientoVentas()
        {
            InitializeComponent();
            this.btnAbono.Click += BtnAbono_Click;
        }

        private void BtnAbono_Click(object sender, EventArgs e)
        {
            AbonoSmall abonoSmall = new AbonoSmall();

            if (this.UltimoAgendamiento == null)
            {
                abonoSmall.Saldo_actual = this.Venta.Total_venta;
            }
            else
            {
                abonoSmall.Saldo_actual = this.UltimoAgendamiento.Saldo_restante;
            }

            abonoSmall.OnBtnSaveClick += AbonoSmall_OnBtnSaveClick;
            this.container = new PoperContainer(abonoSmall);
            this.container.Show(this.btnAbono);
        }

        private async void AbonoSmall_OnBtnSaveClick(object sender, EventArgs e)
        {
            object[] objs = (object[])sender;
            decimal valor_abono = (decimal)objs[0];
            DateTime fecha_proximo_abono = (DateTime)objs[1];
            DateTime fecha_abono = (DateTime)objs[2];

            if (valor_abono != 0)
            {
                MainController main = MainController.GetInstance();
                string rpta = "OK";

                if (this.UltimoAgendamiento != null)
                {
                    this.UltimoAgendamiento.Fecha_cobro = fecha_abono;
                    this.UltimoAgendamiento.Valor_pagado = valor_abono;
                    this.UltimoAgendamiento.Saldo_restante -= valor_abono;
                    this.UltimoAgendamiento.Id_turno = main.Turno.Id_turno;
                    this.UltimoAgendamiento.Turno = main.Turno;
                    this.UltimoAgendamiento.Estado_cobro = "TERMINADO";

                    rpta =
                        await NAgendamiento_cobros.EditarAgendamiento(this.UltimoAgendamiento.Id_agendamiento, this.UltimoAgendamiento);
                }
                else
                {
                    this.UltimoAgendamiento = new Agendamiento_cobros();
                    this.UltimoAgendamiento.Fecha_cobro = fecha_abono;
                    this.UltimoAgendamiento.Valor_pagado = valor_abono;
                    this.UltimoAgendamiento.Saldo_restante -= valor_abono;
                    this.UltimoAgendamiento.Id_turno = main.Turno.Id_turno;
                    this.UltimoAgendamiento.Turno = main.Turno;
                    this.UltimoAgendamiento.Estado_cobro = "TERMINADO";
                }
           
                if (rpta.Equals("OK"))
                {
                    this.UltimoAgendamiento.Valor_pagado = 0;
                    this.UltimoAgendamiento.Fecha_cobro = fecha_proximo_abono;
                    this.UltimoAgendamiento.Estado_cobro = "PENDIENTE";
                    rpta = NAgendamiento_cobros.InsertarAgendamiento(out int id_agendamiento, this.UltimoAgendamiento);
                    if (rpta.Equals("OK"))
                    {
                        Mensajes.MensajeInformacion("Abono realizado y proximo cobro agendado con éxito para la fecha " +
                            fecha_proximo_abono.ToLongDateString(), "Entendido");
                    }
                    else
                    {
                        Mensajes.MensajeInformacion("Abono realizado correctamente pero no se realizó el agendamiento para el proximo cobro", "Entendido");
                    }

                    this.LoadAgendamientos("ID VENTA", this.Venta.Id_venta.ToString());

                }
                else
                {
                    Mensajes.MensajeInformacion("No se pudo realizar el abono", "Entendido");
                }
            }
        }

        private void AsignarInformacion(Ventas venta)
        {
            StringBuilder info = new StringBuilder();
            info.Append("(" + venta.Id_venta + ") La venta fue realizada el " + venta.Fecha_venta.ToLongDateString() + Environment.NewLine);
            info.Append("Cliente: ").Append(venta.Cliente.NombreCompleto).Append(" - Celular: " + venta.Cliente.Celular).Append(Environment.NewLine);
            info.Append("El valor de la venta fue de: ").Append(venta.Valor_venta.ToString("C"));
            this.txtInformacion.Text = info.ToString();
        }

        private async void LoadAgendamientos(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                var (rpta, dtAgendamiento) = await NAgendamiento_cobros.BuscarAgendamientos(tipo_busqueda, texto_busqueda);
                this.Agendamientos = new List<Agendamiento_cobros>();
                if (dtAgendamiento != null)
                {
                    int pagos = 0;
                    int nopagos = 0;

                    List<UserControl> controls = new List<UserControl>();
                    this.UltimoAgendamiento = new Agendamiento_cobros(dtAgendamiento.Rows[0]);
                    foreach (DataRow row in dtAgendamiento.Rows)
                    {
                        Agendamiento_cobros ag = new Agendamiento_cobros(row);
                        this.Agendamientos.Add(ag);
                        if (ag.Estado_cobro.Equals("TERMINADO"))
                            pagos += 1;
                        else
                            nopagos += 1;

                        AgendamientoSmall agendamientoSmall = new AgendamientoSmall
                        {
                            Agendamiento = ag,
                        };
                        agendamientoSmall.OnRefresh += AgendamientoSmall_OnRefresh;
                        controls.Add(agendamientoSmall);
                    }
                    this.panelPagos.AddArrayControl(controls);

                    this.rdNoPagos.Text = "No pagos (" + nopagos + ")";
                    this.rdTerminados.Text = "Terminados (" + pagos + ")";
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "LoadAgendamientos",
                    "Hubo un error al buscar los agendamientos", ex.Message);
            }
        }

        private void AgendamientoSmall_OnRefresh(object sender, EventArgs e)
        {
            this.LoadAgendamientos("ID VENTA", this.Venta.Id_venta.ToString());
        }

        public List<Agendamiento_cobros> Agendamientos { get; set; }
        public Agendamiento_cobros UltimoAgendamiento { get; set; }

        private Ventas _venta;

        public Ventas Venta
        {
            get => _venta;
            set
            {
                _venta = value;
                this.LoadAgendamientos("ID VENTA", value.Id_venta.ToString());
                this.AsignarInformacion(value);
            }
        }
    }
}
