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
        public FrmAgendamientoVentas()
        {
            InitializeComponent();
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
                if (dtAgendamiento != null)
                {
                    int pagos = 0;
                    int nopagos = 0;

                    List<UserControl> controls = new List<UserControl>();
                    foreach (DataRow row in dtAgendamiento.Rows)
                    {
                        Agendamiento_cobros ag = new Agendamiento_cobros(row);

                        if (ag.Estado_cobro.Equals("TERMINADO"))
                            pagos += 1;
                        else
                            nopagos += 1;

                        AgendamientoSmall agendamientoSmall = new AgendamientoSmall
                        {
                            Agendamiento = ag,
                        };
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
