using CapaEntidades;
using CapaNegocio;
using CapaPresentacion.Formularios.FormsClientes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.FormsVentas
{
    public partial class FrmVentas : Form
    {
        public FrmVentas()
        {
            InitializeComponent();
        }

        private void AsignarDatos(Usuarios usuario)
        {
            StringBuilder info = new StringBuilder();
            info.Append("(" + usuario.Id_usuario + ") " + usuario.NombreCompleto).Append(" - Cédula: " + usuario.Identificacion + " - Teléfono: " + usuario.Celular);
            this.txtInformacion.Text = info.ToString();
            this.LoadVentas("ID CLIENTE", usuario.Id_usuario.ToString());
        }

        private async void LoadVentas(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                var (rpta, dtVentas) =
                   await NVentas.BuscarVentas(tipo_busqueda, texto_busqueda);

                this.VentasUsuario = new List<Ventas>();

                if (dtVentas != null)
                {
                    this.gbVentas.Text = "Se encontraron " + dtVentas.Rows.Count + " ventas.";

                    List<UserControl> controls = new List<UserControl>();
                    foreach (DataRow row in dtVentas.Rows)
                    {
                        Ventas ve = new Ventas(row);
                        VentaSmall ventaSmall = new VentaSmall
                        {
                            Venta = ve,
                        };
                        ventaSmall.OnBtnNext += VentaSmall_OnBtnNext;
                        ventaSmall.OnBtnEdit += VentaSmall_OnBtnEdit;
                        this.VentasUsuario.Add(ve);
                        controls.Add(ventaSmall);
                    }
                    this.panelVentas.AddArrayControl(controls);
                }
                else
                {
                    this.gbVentas.Text = "No se encontraron ventas";

                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "LoadVentas",
                    "Hubo un error al cargar las ventas", ex.Message);
            }
        }

        private void VentaSmall_OnBtnEdit(object sender, EventArgs e)
        {
            Ventas ve = (Ventas)sender;
            FrmNuevoCliente frmNuevoCliente = new FrmNuevoCliente
            {
                StartPosition = FormStartPosition.CenterScreen,
                Venta = ve,
            };
            frmNuevoCliente.ShowDialog();
        }

        private void VentaSmall_OnBtnNext(object sender, EventArgs e)
        {
            Ventas ve = (Ventas)sender;
            FrmAgendamientoVentas frmAgendamientoVentas = new FrmAgendamientoVentas
            {
                StartPosition = FormStartPosition.CenterScreen,
                Venta = ve,
            };
            frmAgendamientoVentas.ShowDialog();
        }

        private Usuarios _usuario;
        private List<Ventas> _ventasUsuario;
        public List<Ventas> VentasUsuario { get => _ventasUsuario; set => _ventasUsuario = value; }
        public Usuarios Usuario
        {
            get => _usuario;
            set
            {
                _usuario = value;
                this.AsignarDatos(value);
            }
        }
    }
}
