using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;

namespace CapaPresentacion.Formularios.FormsProveedores
{
    public partial class FrmNuevoProveedor : Form
    {
        public FrmNuevoProveedor()
        {
            InitializeComponent();
            this.btnGuardar.Click += BtnGuardar_Click;
        }


        private bool Comprobaciones(out Proveedores proveedor)
        {
            if (this.IsEditar)
                proveedor = this.Proveedor;
            else
            {
                proveedor = new Proveedores();
                proveedor.Fecha_ingreso = DateTime.Now;
                proveedor.Estado_proveedor = "ACTIVO";
            }

            if (string.IsNullOrEmpty(this.txtNombre.Text))
            {
                Mensajes.MensajeInformacion("Compruebe el nombre del proveedor", "Entendido");
                return false; 
            }

            if (string.IsNullOrEmpty(this.txtContacto.Text))
            {
                Mensajes.MensajeInformacion("Compruebe el contacto del proveedor", "Entendido");
                return false;
            }

            proveedor.Nombre_proveedor = this.txtNombre.Text;
            proveedor.Descripcion_proveedor = this.txtDescripcion.Text;
            proveedor.Contacto_proveedor = this.txtContacto.Text;
            return true;
        }

        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Comprobaciones(out Proveedores proveedor))
                {
                    if (this.IsEditar)
                    {
                        string rpta =
                        await NProveedores.EditarProveedor(proveedor.Id_proveedor, proveedor);
                        if (rpta.Equals("OK"))
                        {
                            Mensajes.MensajeInformacion("Se editó correctamente el proveedor", "Entendido");
                            this.Close();
                        }
                        else
                            throw new Exception(rpta);
                    }
                    else
                    {
                       var (rpta, id_proveedor) =
                       await NProveedores.InsertarProveedor(proveedor);
                        if (rpta.Equals("OK"))
                        {
                            proveedor.Id_proveedor = id_proveedor;
                            Mensajes.MensajeInformacion("Se ingresó correctamente el proveedor", "Entendido");
                            this.Close();
                        }
                        else
                            throw new Exception(rpta);
                    }                          
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnGuardar_Click(object sender, EventArgs e)",
                    "Hubo un error al guardar la información del proveedor", ex.Message);
            }
        }

        private void AsignarDatos(Proveedores proveedor)
        {
            this.txtNombre.Text = proveedor.Nombre_proveedor;
            this.txtContacto.Text = proveedor.Contacto_proveedor;
            this.txtDescripcion.Text = proveedor.Descripcion_proveedor;
        }

        private Proveedores _proveedor;

        public Proveedores Proveedor
        {
            get => _proveedor;
            set
            {
                _proveedor = value;
                this.AsignarDatos(value);
            }
        }

        private bool _isEditar;

        public bool IsEditar
        {
            get => _isEditar;
            set
            {
                _isEditar = value;
                this.Text = "Editar datos de un proveedor";
            }
        }
    }
}
