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
    public partial class ArticuloSmall : UserControl
    {
        public ArticuloSmall()
        {
            InitializeComponent();
            this.btnNext.Click += BtnNext_Click;
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            this.OnBtnNext?.Invoke(this.Articulo, e);
        }

        public event EventHandler OnBtnNext;

        private void AsignarDatos(Articulos articulo)
        {
            this.txtReferencia.Text =
                "Referencia: (" + articulo.Id_articulo + ")" + articulo.Referencia_articulo + ".";
            this.txtPrecio.Text = "Precio: " + articulo.Valor_articulo.ToString("C") + "";
        }

        private Articulos articulo;

        public Articulos Articulo { get => articulo;
            set
            {
                articulo = value;
                this.AsignarDatos(value);
            }
        }
    }
}
