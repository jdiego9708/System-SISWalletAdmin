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

namespace CapaPresentacion.Formularios.FormsArticulos
{
    public partial class ArticuloItem : UserControl
    {
        public ArticuloItem()
        {
            InitializeComponent();
            this.btnAgregarStock.Click += BtnAgregarStock_Click;
        }

        private void BtnAgregarStock_Click(object sender, EventArgs e)
        {
            this.OnBtnAddStock?.Invoke(this.Articulo, e);
        }

        public event EventHandler OnBtnAddStock;

        private void AsignarArticulo(Articulos articulo)
        {
            this.txtValor.Text = "$" + articulo.Valor_articulo.ToString("N2");
            this.txtReferencia.Text = articulo.Referencia_articulo;
            this.txtStock.Text = ((int)articulo.Cantidad_articulo) + " " + articulo.Tipo_cantidad;
            this.txtDescripcion.Text = articulo.Descripcion_articulo;
            if (articulo.Estado_articulo.Equals("ACTIVO"))
                this.panel1.BackColor = Color.Teal;
            else
                this.panel1.BackColor = Color.FromArgb(255, 128, 128);

            if (articulo.Cantidad_articulo < 5)            
                this.txtStock.ForeColor = Color.FromArgb(255, 128, 128);
            else
                this.txtStock.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private Articulos _articulo;

        public Articulos Articulo
        {
            get => _articulo;
            set
            {
                _articulo = value;
                this.AsignarArticulo(value);
            }
        }
    }
}
