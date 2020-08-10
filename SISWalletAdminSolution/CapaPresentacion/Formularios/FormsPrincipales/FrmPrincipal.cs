namespace CapaPresentacion.Formularios.FormsPrincipales
{
    using CapaEntidades;
    using CapaPresentacion.Formularios.FormsClientes;
    using System.Windows.Forms;

    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
            this.Load += FrmPrincipal_Load;
            this.btnClientes.Click += BtnClientes_Click;
        }

        private void BtnClientes_Click(object sender, System.EventArgs e)
        {
            FrmClientes frmClientes = new FrmClientes
            {
                StartPosition = FormStartPosition.CenterScreen,
            };
            frmClientes.ShowDialog();
        }

        private void FrmPrincipal_Load(object sender, System.EventArgs e)
        {
            MainController main = MainController.GetInstance();
            main.Usuario = new Usuarios
            {
                Id_usuario = 2022,
                Nombres = "RAUL",
                Apellidos = "URQUIJO",
            };
            main.FrmPrincipal = this;
        }
    }
}
