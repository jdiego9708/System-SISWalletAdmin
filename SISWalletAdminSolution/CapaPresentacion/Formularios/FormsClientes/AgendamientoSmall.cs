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
    public partial class AgendamientoSmall : UserControl
    {
        PoperContainer container;

        public AgendamientoSmall()
        {
            InitializeComponent();
            this.btnAbono.Click += BtnAbono_Click;
        }

        public event EventHandler OnRefresh;

        private void BtnAbono_Click(object sender, EventArgs e)
        {
            AbonoSmall abonoSmall = new AbonoSmall
            {
                Saldo_actual = this.Agendamiento.Saldo_restante,
            };
            abonoSmall.OnBtnSaveClick += AbonoSmall_OnBtnSaveClick;
            this.container = new PoperContainer(abonoSmall);
            this.container.Show(this.btnAbono);
        }

        private async void AbonoSmall_OnBtnSaveClick(object sender, EventArgs e)
        {
            object[] objs = (object[])sender;
            decimal valor_abono = (decimal)objs[0];
            DateTime fecha_proximo_abono = (DateTime)objs[1];

            if (valor_abono != 0)
            {
                MainController main = MainController.GetInstance();
                this.Agendamiento.Valor_pagado = valor_abono;
                this.Agendamiento.Saldo_restante -= valor_abono;
                this.Agendamiento.Id_turno = main.Turno.Id_turno;
                this.Agendamiento.Turno = main.Turno;
                this.Agendamiento.Estado_cobro = "TERMINADO";

                string rpta =
                    await NAgendamiento_cobros.EditarAgendamiento(this.Agendamiento.Id_agendamiento, this.Agendamiento);
                if (rpta.Equals("OK"))
                {
                    this.Agendamiento.Valor_pagado = 0;
                    this.Agendamiento.Fecha_cobro = fecha_proximo_abono;
                    this.Agendamiento.Estado_cobro = "PENDIENTE";
                    rpta = NAgendamiento_cobros.InsertarAgendamiento(out int id_agendamiento, this.Agendamiento);
                    if (rpta.Equals("OK"))
                    {
                        Mensajes.MensajeInformacion("Abono realizado y proximo cobro agendado con éxito para la fecha " +
                            fecha_proximo_abono.ToLongDateString(), "Entendido");
                    }
                    else
                    {
                        Mensajes.MensajeInformacion("Abono realizado correctamente pero no se realizó el agendamiento para el proximo cobro", "Entendido");
                    }
                    this.OnRefresh?.Invoke(sender, e);
                }
                else
                {
                    Mensajes.MensajeInformacion("No se pudo realizar el abono", "Entendido");
                }
            }
        }

        private void AsignarDatos(Agendamiento_cobros agendamiento)
        {
            StringBuilder info = new StringBuilder();
            info.Append(agendamiento.Estado_cobro).Append(" - ").Append(agendamiento.Fecha_cobro.ToLongDateString()).Append(Environment.NewLine);
            info.Append("Valor de cuota: ").Append(agendamiento.Valor_cobro.ToString("C"));
            if (agendamiento.Estado_cobro.Equals("TERMINADO"))
                info.Append(" - Valor pagado: ").Append(Agendamiento.Valor_pagado.ToString("C"));

            info.Append(" - Saldo restante: ").Append(agendamiento.Saldo_restante.ToString("C"));
            this.txtInfoCliente.Text = info.ToString();

            if (agendamiento.Estado_cobro.Equals("TERMINADO"))
                this.panel1.BackColor = Color.SteelBlue;
            else
            {
                this.panel1.BackColor = Color.FromArgb(255, 128, 128);

                if ((DateTime.Now - agendamiento.Fecha_cobro).Days < 1)
                    this.btnAbono.Visible = true;
                else
                    this.btnAbono.Visible = false;
            }
        }

        private Agendamiento_cobros _agendamiento;

        public Agendamiento_cobros Agendamiento
        {
            get => _agendamiento;
            set
            {
                _agendamiento = value;
                this.AsignarDatos(value);
            }
        }
    }
}
