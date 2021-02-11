using CapaEntidades;
using CapaNegocio;
using CapaPresentacion.Formularios.FormsArticulos;
using CapaPresentacion.Formularios.FormsEstadisticas;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.FormsPrincipales
{
    public partial class FrmIniciarSesion : Form
    {
        public FrmIniciarSesion()
        {
            InitializeComponent();
            this.Load += FrmIniciarSesion_Load;
            this.ListaEmpleados.SelectedIndexChanged += ListaEmpleados_SelectedIndexChanged;
            this.btnCerrar.Click += BtnCerrar_Click;
            this.btnIngresar.Click += BtnIngresar_Click;
            this.txtPass.OnCustomKeyPress += TxtPass_OnCustomKeyPress;
        }

        private async void TxtPass_OnCustomKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                MensajeEspera.ShowWait("Iniciando...");

                var (rpta, objects) = await NCredenciales.Login(this.usuarioSelected.Celular,
                    this.txtPass.Texto, DateTime.Now.ToString("yyyy-MM-dd"));
                if (rpta.Equals("OK"))
                {
                    Credenciales credencial = (Credenciales)objects[0];                    
                    MainController main = MainController.GetInstance();
                    main.Usuario = credencial.Usuario;
                    
                    if (credencial.Usuario.Tipo_usuario.Equals("TRABAJADOR CARTERAS"))
                    {
                        Turnos turno = (Turnos)objects[1];
                        main.Turno = turno;

                        FrmObservarArticulos frmArticulos = new FrmObservarArticulos
                        {
                            StartPosition = FormStartPosition.CenterScreen,
                            WindowState = FormWindowState.Maximized,
                        };
                        frmArticulos.Show();
                        //frmArticulos.LoadArticulos(dtArticulos);
                        this.Hide();
                    }
                    else
                    {
                        DataTable dtSolicitudes = (DataTable)objects[1];
                        DataTable dtCobros = (DataTable)objects[2];

                        FrmPrincipal FrmPrincipal = new FrmPrincipal
                        {
                            StartPosition = FormStartPosition.CenterScreen,
                            WindowState = FormWindowState.Maximized,
                        };
                        FrmPrincipal.LoadCobros(dtCobros);
                        FrmPrincipal.LoadNotificaciones(dtSolicitudes);
                        FrmPrincipal.Show();
                        //FrmEstadisticasCobro.LoadArticulos(dtArticulos);
                        this.Hide();
                    }
                }
                else
                {
                    MensajeEspera.CloseForm();
                    Mensajes.MensajeInformacion(rpta, "Entendido");
                }

                MensajeEspera.CloseForm();
            }
        }

        private async void BtnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                MensajeEspera.ShowWait("Iniciando...");

                var (rpta, objects) = await NCredenciales.Login(this.usuarioSelected.Celular,
                    this.txtPass.Texto, DateTime.Now.ToString());
                if (rpta.Equals("OK"))
                {
                    Credenciales credencial = (Credenciales)objects[0];
                    Turnos turno = (Turnos)objects[1];
                    MainController main = MainController.GetInstance();
                    main.Usuario = credencial.Usuario;
                    main.Turno = turno;

                    if(credencial.Usuario.Tipo_usuario.Equals("TRABAJADOR CARTERAS"))
                    {                    
                        FrmObservarArticulos frmArticulos = new FrmObservarArticulos
                        {
                            StartPosition = FormStartPosition.CenterScreen,
                            WindowState = FormWindowState.Maximized,
                        };
                        frmArticulos.Show();
                        //frmArticulos.LoadArticulos(dtArticulos);
                        this.Hide();
                    }
                    else
                    {
                        FrmPrincipal frmPrincipal = new FrmPrincipal
                        {
                            StartPosition = FormStartPosition.CenterScreen,
                            WindowState = FormWindowState.Maximized,
                        };
                        frmPrincipal.Show();
                        //frmArticulos.LoadArticulos(dtArticulos);
                        this.Hide();
                    }
                }
                else
                {
                    MensajeEspera.CloseForm();
                    Mensajes.MensajeInformacion(rpta, "Entendido");
                }

                MensajeEspera.CloseForm();
            }
            catch (Exception ex)
            {
                MensajeEspera.CloseForm();
                Mensajes.MensajeErrorCompleto(this.Name, "BtnIngresar_Click",
                    "Hubo un error al ingresar", ex.Message);
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ListaEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            int id_empleado;
            if (int.TryParse(Convert.ToString(cb.SelectedValue), out id_empleado))
            {
                if (this.DtUsuarios != null)
                {
                    this.txtPass.txtBusqueda.Focus();
                    DataRow[] rows = this.DtUsuarios.Select(string.Format("Id_usuario = {0}", id_empleado));
                    if (rows.Length > 0)
                    {
                        Usuarios us = new Usuarios(rows[0]);
                        this.usuarioSelected = us;
                    }
                    else
                    {
                        Mensajes.MensajeInformacion("No se encontró el usuario en la lista de usuarios", "Entendido");
                    }
                }

            }
        }

        private async void FrmIniciarSesion_Load(object sender, EventArgs e)
        {
            this.txtPass.txtBusqueda.TextAlign = HorizontalAlignment.Center;
            this.txtPass.Texto_inicial = "Contraseña";
            this.txtPass.txtBusqueda.UseSystemPasswordChar = true;

            var (dtUsuarios, rpta) =
               await NUsuarios.BuscarUsuarios("TIPO USUARIO", "CARTERAS");

            if (dtUsuarios != null)
            {
                this.DtUsuarios = dtUsuarios;
                this.ListaEmpleados.DataSource = dtUsuarios;
                this.ListaEmpleados.ValueMember = "Id_usuario";
                this.ListaEmpleados.DisplayMember = "Nombre_completo";
                this.ListaEmpleados.SelectedValue = 0;
            }
            else
            {
                Mensajes.MensajeErrorCompleto(this.Name, "FrmIniciarSesion_Load",
                    "Hubo un error al conectarse con el servidor",
                    "Hubo un error al conectarse con el servidor, por favor intentelo de nuevo o envíe un ticket " +
                    "al administrador del sistema, detalles: " + rpta);
            }
        }

        private Usuarios usuarioSelected;
        public DataTable DtUsuarios { get; set; }
    }
}
