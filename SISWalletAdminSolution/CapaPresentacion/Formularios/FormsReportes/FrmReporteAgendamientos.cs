using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.FormsReportes
{
    public partial class FrmReporteAgendamientos : Form
    {
        public FrmReporteAgendamientos()
        {
            InitializeComponent();
        }

        private void FrmReporteAgendamientos_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
