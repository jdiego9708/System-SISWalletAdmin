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
        }

        private async void BtnRefresh_Click(object sender, EventArgs e)
        {
            await this.LoadAgendamientos("FECHA PENDIENTE", DateTime.Now.ToString("yyyy-MM-dd"));
        }

        private async void RdTerminados_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            if (chk.Checked)
            {
                await this.LoadAgendamientos("FECHA TERMINADO", DateTime.Now.ToString("yyyy-MM-dd"));
            }
        }

        private async void RdPendientes_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            if (chk.Checked)
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
                    if (this.checkBox1.Checked)
                    {
                        if (int.TryParse(txt.Texto, out int id_usuario))
                        {
                            await this.LoadClientes("ID CLIENTE", id_usuario.ToString(), "");
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
            this.Show();

            MainController main = MainController.GetInstance();
            await this.LoadAgendamientos("FECHA PENDIENTE", DateTime.Now.ToString("yyyy-MM-dd"));
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
                    List<ClienteSmall> controls = (from DataRow dr in dtClientes.Rows
                                                   select new ClienteSmall { Venta = new Ventas(dr) }).ToList();

                    List<UserControl> userControls = new List<UserControl>();
                    userControls.AddRange(controls);

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

        private async Task LoadAgendamientos(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                MensajeEspera.ShowWait("Cargando...");
                var (rpta, dtAgendamiento) = await NAgendamiento_cobros.BuscarAgendamientos(tipo_busqueda, texto_busqueda);

                this.panelClientes.clearDataSource();
                this.positionChanged = 1;

                if (dtAgendamiento != null)
                {
                    List<ClienteSmall> controls = (from DataRow dr in dtAgendamiento.Rows
                                                   select new ClienteSmall { Agendamiento = new Agendamiento_cobros(dr) }).ToList();

                    List<UserControl> userControls = new List<UserControl>();
                    userControls.AddRange(controls);

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
    }
}
