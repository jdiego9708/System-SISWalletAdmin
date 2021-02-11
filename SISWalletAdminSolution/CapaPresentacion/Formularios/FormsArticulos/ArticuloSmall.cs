using CapaEntidades;
using CapaPresentacion.Properties;
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
            this.numericCantidad.ValueChanged += NumericCantidad_ValueChanged;
            this.btnEditarPrecio.Click += BtnEditarPrecio_Click;
        }

        private void BtnEditarPrecio_Click(object sender, EventArgs e)
        {
            if (this.txtPrecio.ReadOnly)
            {
                this.txtPrecio.ReadOnly = false;
                this.txtPrecio.KeyPress += Txt_KeyPress;
                this.txtPrecio.LostFocus += Txt_GotFocus;
                this.txtPrecio.GotFocus += Txt_LostFocus;
            }
            else
            {
                this.txtPrecio.KeyPress -= Txt_KeyPress;
                this.txtPrecio.LostFocus -= Txt_GotFocus;
                this.txtPrecio.GotFocus -= Txt_LostFocus;
                this.txtPrecio.ReadOnly = true;
            }

            //if (this.txtPrecio.Tag != null)
            //    this.txtPrecio.Text = ((decimal)this.txtPrecio.Tag).ToString("C");

            this.txtPrecio.SelectAll();
        }

        private void Txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void Txt_GotFocus(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.Text = Convert.ToString(txt.Tag);
            txt.SelectAll();
        }

        private void Txt_LostFocus(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;

            if (txt.Text.Equals(""))
            {
                string precio = "0";
                txt.Tag = 0;
                txt.Text = string.Format("{0:C}", precio);
            }
            else
            {
                bool result = decimal.TryParse(txt.Text, out decimal num);
                if (result)
                {
                    txt.Tag = num;
                    txt.Text = string.Format("{0:C}", num);
                    this.Articulo.Valor_articulo = num;
                }
            }
        }

        private void NumericCantidad_ValueChanged(object sender, EventArgs e)
        {
            //this.Articulo.Cantidad_articulo = this.numericCantidad.Value;
            if (this.OnCantidadChanged != null)
            {
                this.OnCantidadChanged.Invoke(new object[] { this.Articulo, this.numericCantidad.Value }, e);
                this.Articulo.Cantidad_articulo = this.numericCantidad.Value;
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (this.IsAdd)
            { 
                this.OnBtnRemover?.Invoke(this.Articulo, e);
            }
            else
            {
                this.Articulo.Cantidad_articulo = this.numericCantidad.Value;
                this.OnBtnNext?.Invoke(this.Articulo, e);
            }
        }

        public event EventHandler OnCantidadChanged;
        public event EventHandler OnBtnNext;
        public event EventHandler OnBtnRemover;

        private void AsignarDatos(Articulos articulo)
        {
            this.txtReferencia.Text =
                "Referencia: (" + articulo.Id_articulo + ")" + articulo.Referencia_articulo + ".";
            this.txtPrecio.Text = articulo.Valor_articulo.ToString("C");
            this.txtPrecio.Tag = articulo.Valor_articulo;
            this.numericCantidad.Value = articulo.Cantidad_articulo;
        }

        private Articulos articulo;
        private bool _isAdd;

        public Articulos Articulo { get => articulo;
            set
            {
                articulo = value;
                this.AsignarDatos(value);
            }
        }

        public bool IsAdd
        {
            get => _isAdd;
            set
            {
                _isAdd = value;
                this.btnNext.BackgroundImage = Resources.negative;
            }
        }

    }
}
