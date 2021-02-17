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
    public partial class AbonoSmall : UserControl
    {
        public AbonoSmall()
        {
            InitializeComponent();
            this.btnSave.Click += BtnSave_Click;
            this.txtValorAbono.KeyPress += Txt_KeyPress;
            this.txtValorAbono.GotFocus += Txt_GotFocus;
            this.txtValorAbono.LostFocus += Txt_LostFocus;
            this.txtValorAbono.TextChanged += TxtValorAbono_TextChanged;
        }

        private void TxtValorAbono_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (decimal.TryParse(txt.Text, out decimal abono))
            {
                this.Valor_abono = abono;
                this.Calcular();
            }
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
                txt.Text = string.Format("{0:C}", precio);
            }
            else
            {
                bool result = int.TryParse(txt.Text, out int num);
                if (result)
                {
                    txt.Tag = num;
                    txt.Text = string.Format("{0:C}", txt.Tag);
                }
            }
        }

        public event EventHandler OnBtnSaveClick;

        private void BtnSave_Click(object sender, EventArgs e)
        {
            this.OnBtnSaveClick?.Invoke(this.Valor_abono, e);
        }

        private void Calcular()
        {
            this.Saldo_con_abono = this.Saldo_actual - this.Valor_abono;

            StringBuilder info = new StringBuilder();
            info.Append("El saldo actual es ").Append(this.Saldo_actual.ToString("C"));
            if (this.Valor_abono != 0)
            {
                info.Append(" con el abono por el saldo sería ").Append(this.Saldo_con_abono.ToString("C"));
            }

            this.Informacion = info.ToString();
        }

        private string _informacion;
        private decimal _valor_abono;
        private decimal _saldo_actual;
        private decimal _saldo_con_abono;

        public string Informacion
        {
            get => _informacion;
            set
            {
                _informacion = value;
                this.txtInfo.Text = value;
            }
        }
        public decimal Valor_abono
        {
            get => _valor_abono;
            set
            {
                _valor_abono = value;
                this.Calcular();
            }
        }
        public decimal Saldo_actual { get => _saldo_actual; set => _saldo_actual = value; }
        public decimal Saldo_con_abono { get => _saldo_con_abono; set => _saldo_con_abono = value; }
    }
}
