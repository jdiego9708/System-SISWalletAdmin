namespace CapaPresentacion.Formularios.FormsPrincipales
{
    using CapaEntidades;
    using CapaPresentacion.Formularios.FormsClientes;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System;
    using System.Data;
    using CapaNegocio;
    using CapaPresentacion.Formularios.FormsArticulos;
    using System.Text;
    using CapaPresentacion.Formularios.FormsReportes;
    using CapaPresentacion.Formularios.FormsEstadisticas;

    public partial class FrmPrincipal : Form
    {
        PoperContainer container;

        public FrmPrincipal()
        {
            InitializeComponent();
            this.Load += FrmPrincipal_Load;
            this.listaCobros.SelectedIndexChanged += ListaCobros_SelectedIndexChanged;
            this.FormClosing += FrmPrincipal_FormClosing;
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        public void LoadNotificaciones(DataTable dtSolicitudes)
        {
            if (dtSolicitudes != null)
            {
                if (dtSolicitudes.Rows.Count == 1)
                {
                    this.btnNotificaciones.Text = "Una notificación";
                }
                else if (dtSolicitudes.Rows.Count > 1)
                {
                    this.btnNotificaciones.Text = dtSolicitudes.Rows.Count + " notificaciones";
                }
                else
                {
                    this.btnNotificaciones.Text = "No hay notificaciones";
                }
            }
        }

        private void LoadCobros(string tipo_busqueda, string texto_busqueda1, string texto_busqueda2)
        {
            try
            {
                DataTable dtCobros =
                    NCobros.BuscarCobros(tipo_busqueda, texto_busqueda1, texto_busqueda2, out string rpta);

                this.listaCobros.DataSource = null;

                if (dtCobros != null)
                {
                    this.listaCobros.DataSource = dtCobros;
                    this.listaCobros.ValueMember = "Id_cobro";
                    this.listaCobros.DisplayMember = "Observaciones";
                }
                else
                    if (!rpta.Equals("OK"))
                    throw new Exception(rpta);
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "LoadCobros",
                    "Hubo un error al cargar la lista de cobros", ex.Message);
            }
        }

        public void LoadCobros(DataTable dtCobros)
        {
            try
            {
                this.dtCobros = dtCobros;
                this.listaCobros.DataSource = null;

                if (dtCobros != null)
                {
                    this.listaCobros.DataSource = dtCobros;
                    this.listaCobros.ValueMember = "Id_cobro";
                    this.listaCobros.DisplayMember = "Observaciones";
                }
                else
                    Mensajes.MensajeInformacion("Tabla de cobros vacía", "Entendido");
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "LoadCobros",
                    "Hubo un error al cargar la lista de cobros", ex.Message);
            }
        }

        private void AbrirCobro(int id_cobro)
        {
            MainController main = MainController.GetInstance();
            main.Id_cobro = id_cobro;

            if (this.dtCobros != null)
            {
                DataRow[] rows = this.dtCobros.Select(string.Format("Id_cobro = {0}", id_cobro));
                if (rows.Length > 0)
                {
                    main.Cobro = new Cobros(rows[0]);
                }
            }

            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.Clear();

            if (id_cobro == 7)
            {
                try
                {
                    FrmObservarArticulos frm = new FrmObservarArticulos
                    {
                        TopLevel = false,
                        WindowState = FormWindowState.Maximized,
                    };
                    Form FormComprobado = this.ComprobarExistencia(frm);
                    if (FormComprobado != null)
                    {
                        frm.WindowState = FormWindowState.Maximized;
                        frm.Activate();
                    }
                    else
                    {
                        frm.FormBorderStyle = FormBorderStyle.Fixed3D;
                        this.panel1.Controls.Add(frm);
                        this.panel1.Tag = frm;
                        frm.Show();
                    }
                    frm.BringToFront();
                }
                catch (Exception ex)
                {
                    Mensajes.MensajeErrorCompleto(this.Name, "AbrirCobro",
                        "Hubo un error con el formulario FrmObservarArticulos", ex.Message);
                }
            }
            else
            {
                try
                {
                    FrmEstadisticasDiarias frm = new FrmEstadisticasDiarias
                    {
                        TopLevel = false,
                        FormBorderStyle = FormBorderStyle.None,
                        Dock = DockStyle.Fill,
                    };
                    Form FormComprobado = this.ComprobarExistencia(frm);
                    if (FormComprobado != null)
                    {
                        frm.WindowState = FormWindowState.Maximized;
                        frm.Activate();
                    }
                    else
                    {
                        frm.FormBorderStyle = FormBorderStyle.Fixed3D;
                        this.panel1.Controls.Add(frm);
                        this.panel1.Tag = frm;
                        frm.Show();
                    }
                    frm.BringToFront();
                }
                catch (Exception ex)
                {
                    Mensajes.MensajeErrorCompleto(this.Name, "AbrirCobro",
                        "Hubo un error con el formulario FrmEstadisticasDiarias", ex.Message);
                }
            }
        }

        private void ListaCobros_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (int.TryParse(Convert.ToString(cb.SelectedValue), out int id_cobro))
            {
                this.AbrirCobro(id_cobro);
            }
        }

        private void FrmPrincipal_Load(object sender, System.EventArgs e)
        {
            MainController main = MainController.GetInstance();
            this.LoadCobros("ID USUARIO", main.Usuario.Id_usuario.ToString(), "");
        }

        private Form ComprobarExistencia(Form form)
        {
            if (this.container != null)
                this.container.Close();

            Form frmDevolver = null;
            foreach (Form frm in this.panel1.Controls)
            {
                if (frm.Name.Equals(form.Name))
                {
                    frmDevolver = frm;
                    break;
                }

            }
            return frmDevolver;
        }

        public DataTable dtCobros { get; set; }
    }
}

