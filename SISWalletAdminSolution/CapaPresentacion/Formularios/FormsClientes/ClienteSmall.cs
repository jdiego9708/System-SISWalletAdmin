using CapaEntidades;
using CapaNegocio;
using CapaPresentacion.Formularios.FormsVentas;
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
    public partial class ClienteSmall : UserControl
    {
        PoperContainer container;

        public ClienteSmall()
        {
            InitializeComponent();
            this.btnNext.Click += BtnNext_Click;
            this.btnAbono.Click += BtnAbono_Click;
            this.btnRemove.Click += BtnRemove_Click;
        }

        public event EventHandler OnRefresh;

        private async void BtnRemove_Click(object sender, EventArgs e)
        {
            Mensajes.MensajePregunta("¿Confirma la inactivación/eliminación del cliente?", "Confirmar", "Cancelar", out DialogResult dialog);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    string rpta = string.Empty;
                    if (this.Agendamiento != null)
                    {
                        rpta = await NUsuarios.InactivarUsuario(this.Agendamiento.Venta.Id_cliente);
                        if (rpta.Equals("OK"))
                        {
                            Mensajes.MensajeInformacion("Se inactivó correctamente el cliente", "Entendido");
                            this.OnRefresh?.Invoke(sender, e);
                        }
                        else
                        {
                            throw new Exception(rpta);
                        }

                        return;
                    }

                    if (this.Venta != null)
                    {
                        rpta = await NUsuarios.InactivarUsuario(this.Venta.Id_cliente);
                        if (rpta.Equals("OK"))
                        {
                            Mensajes.MensajeInformacion("Se inactivó correctamente el cliente", "Entendido");
                            this.OnRefresh?.Invoke(sender, e);
                        }
                        else
                        {
                            throw new Exception(rpta);
                        }

                        return;
                    }

                }
                catch (Exception ex)
                {
                    Mensajes.MensajeErrorCompleto(this.Name, "BtnRemove_Click",
                        "Hubo un error al remover el cliente", ex.Message);
                }
                
            }
        }

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

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (this.Agendamiento != null)
            {
                FrmVentas frmVentas = new FrmVentas
                {
                    Usuario = this.Agendamiento.Venta.Cliente,
                    StartPosition = FormStartPosition.CenterScreen,
                };
                frmVentas.Show();
                return;
            }

            if (this.Venta != null)
            {
                FrmVentas frmVentas = new FrmVentas
                {
                    Usuario = this.Venta.Cliente,
                    StartPosition = FormStartPosition.CenterScreen,
                };
                frmVentas.Show();
            }
        }

        private void AsignarDatos(Agendamiento_cobros agendamiento)
        {
            StringBuilder infoCliente = new StringBuilder();
            infoCliente.Append("(" + agendamiento.Venta.Cliente.Id_usuario + ") " + agendamiento.Venta.Cliente.NombreCompleto + " - Celular: " + agendamiento.Venta.Cliente.Celular + " - Cédula: " + agendamiento.Venta.Cliente.Identificacion).Append(Environment.NewLine);

            StringBuilder infoPago = new StringBuilder();
            infoPago.Append("Total de la venta: " + agendamiento.Venta.Total_venta + " - Valor cuota: " + agendamiento.Venta.Valor_cuota.ToString("C")).Append(Environment.NewLine);

            this.txtInfoPago.Text = infoPago.ToString();
            this.txtInfoCliente.Text = infoCliente.ToString();

            if (agendamiento.Estado_cobro.Equals("PENDIENTE"))
                this.panel1.BackColor = Color.FromArgb(255, 128, 128);
            else
                this.panel1.BackColor = Color.SteelBlue;

            this.btnAbono.Visible = true;
        }

        private void AsignarDatos(Ventas venta)
        {
            StringBuilder infoCliente = new StringBuilder();
            infoCliente.Append("(" + venta.Cliente.Id_usuario + ") " + venta.Cliente.NombreCompleto + " - Celular: " + venta.Cliente.Celular + " - Cédula: " + venta.Cliente.Identificacion).Append(Environment.NewLine);

            StringBuilder infoPago = new StringBuilder();
            infoPago.Append("Total de la venta: " + venta.Total_venta + " - Valor cuota: " + venta.Valor_cuota.ToString("C")).Append(Environment.NewLine);

            this.txtInfoPago.Text = infoPago.ToString();
            this.txtInfoCliente.Text = infoCliente.ToString();

            if (venta.Estado_venta.Equals("ACTIVO"))
                this.panel1.BackColor = Color.FromArgb(255, 128, 128);
            else
                this.panel1.BackColor = Color.SteelBlue;

            this.btnAbono.Visible = false;
        }

        private Agendamiento_cobros _agendamiento;
        private Ventas _venta;

        public Ventas Venta
        {
            get => _venta;
            set
            {
                _venta = value;
                this.AsignarDatos(value);
            }
        }
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
