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
    public partial class PrecioSmall : UserControl
    {
        public PrecioSmall()
        {
            InitializeComponent();

            this.txtPrecio.KeyPress += Txt_KeyPress;
            this.txtPrecio.LostFocus += Txt_GotFocus;
            this.txtPrecio.GotFocus += Txt_LostFocus;
            this.txtPrecio.Click += TxtPrecio_Click;
            this.btnSave.Click += BtnSave_Click;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            bool result = decimal.TryParse(txtPrecio.Text, out decimal num);
            if (result)
            {
                this.txtPrecio.Text = num.ToString("C");
                this.txtPrecio.Tag = num;
                this.OnBtnSaveClick?.Invoke(num, e);
            }
            else
            {
                Mensajes.MensajeInformacion("No tiene el formato correcto", "Entendido");
            }
         
        }

        public event EventHandler OnBtnSaveClick;

        private void TxtPrecio_Click(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.Text = Convert.ToString(txt.Tag);
            txt.SelectAll();
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
            //TextBox txt = (TextBox)sender;
            //txt.Text = Convert.ToString(txt.Tag);
            //txt.SelectAll();
        }

        private void Txt_LostFocus(object sender, EventArgs e)
        {
            //TextBox txt = (TextBox)sender;

            //if (txt.Text.Equals(""))
            //{
            //    string precio = "0";
            //    txt.Tag = 0;
            //    txt.Text = string.Format("{0:C}", precio);
            //}
            //else
            //{
            //    bool result = decimal.TryParse(txt.Text, out decimal num);
            //    if (result)
            //    {
            //        txt.Tag = num;
            //        txt.Text = string.Format("{0:C}", num);
            //    }
            //}
        }

        private decimal _precioArticulo;

        public decimal PrecioArticulo
        {
            get => _precioArticulo;
            set
            {
                _precioArticulo = value;
                this.txtPrecio.Tag = value;
                this.txtPrecio.Text = value.ToString("C");
            }
        }
    }
}
