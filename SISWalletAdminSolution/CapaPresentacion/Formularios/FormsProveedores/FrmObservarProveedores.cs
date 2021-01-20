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

namespace CapaPresentacion.Formularios.FormsProveedores
{
    public partial class FrmObservarProveedores : Form
    {
        public FrmObservarProveedores()
        {
            InitializeComponent();
            this.Load += FrmObservarProveedores_Load;
            this.btnNuevoProveedor.Click += BtnNuevoProveedor_Click;
            this.btnRefresh.Click += BtnRefresh_Click;
        }

        private async void BtnRefresh_Click(object sender, EventArgs e)
        {
            await this.BuscarProveedores("COMPLETO", "");
        }

        private void BtnNuevoProveedor_Click(object sender, EventArgs e)
        {
            FrmNuevoProveedor frmNuevoProveedor = new FrmNuevoProveedor
            {
                StartPosition = FormStartPosition.CenterScreen,
            };
            frmNuevoProveedor.ShowDialog();
        }

        private async void FrmObservarProveedores_Load(object sender, EventArgs e)
        {
            await this.BuscarProveedores("COMPLETO", "");
        }

        private async Task BuscarProveedores(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                var (dtProveedores, rpta) = 
                    await NProveedores.BuscarProveedores(tipo_busqueda, texto_busqueda);

                this.panelProveedores.clearDataSource();

                if (dtProveedores != null)
                {
                    List<UserControl> controls = new List<UserControl>();
                    foreach(DataRow row in dtProveedores.Rows)
                    {
                        Proveedores proveedor = new Proveedores(row);
                        ProveedorSmall proveedorSmall = new ProveedorSmall
                        {
                            Proveedor = proveedor,
                        };
                        proveedorSmall.OnBtnNext += ProveedorSmall_OnBtnNext;
                        controls.Add(proveedorSmall);
                    }

                    this.panelProveedores.AddArrayControl(controls);
                }
                else
                {
                    if (!rpta.Equals("OK"))
                        throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarProveedores(string tipo_busqueda, string texto_busqueda)",
                    "Hubo un error al buscar los proveedores", ex.Message);
            }
        }

        private void ProveedorSmall_OnBtnNext(object sender, EventArgs e)
        {
            Proveedores proveedor = (Proveedores)sender;

            if (this.AddArticulo)
            {
                this.OnProveedorSelected?.Invoke(proveedor, e);
                this.Close();
                return;
            }

            if (this.EditProveedor)
            {
                FrmNuevoProveedor frmNuevoProveedor = new FrmNuevoProveedor
                {
                    StartPosition = FormStartPosition.CenterScreen,
                    IsEditar = true,
                    Proveedor = proveedor,
                };
                frmNuevoProveedor.ShowDialog();
                return;
            }
        }

        public event EventHandler OnProveedorSelected;

        public bool AddArticulo { get; set; }

        public bool EditProveedor { get; set; }
    }
}
