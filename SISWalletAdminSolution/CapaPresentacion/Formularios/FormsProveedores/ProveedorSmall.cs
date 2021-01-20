using CapaEntidades;
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
    public partial class ProveedorSmall : UserControl
    {
        public ProveedorSmall()
        {
            InitializeComponent();
            this.btnNext.Click += BtnNext_Click;
        }

        public event EventHandler OnBtnNext;

        private void BtnNext_Click(object sender, EventArgs e)
        {
            OnBtnNext?.Invoke(this.Proveedor, e);
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
    }
}
