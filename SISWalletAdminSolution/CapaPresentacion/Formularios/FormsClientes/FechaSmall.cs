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
    public partial class FechaSmall : UserControl
    {
        public FechaSmall()
        {
            InitializeComponent();
            this.btnPrint.Click += BtnPrint_Click;
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            this.OnBtnPrintClick?.Invoke(this.dateFecha.Value, e);
        }

        public event EventHandler OnBtnPrintClick;
    }
}
