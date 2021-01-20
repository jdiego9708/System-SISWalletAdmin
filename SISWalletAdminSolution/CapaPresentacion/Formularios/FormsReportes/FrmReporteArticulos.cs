using Microsoft.Reporting.WinForms;
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
    public partial class FrmReporteArticulos : Form
    {
        public FrmReporteArticulos()
        {
            InitializeComponent();
        }

        public DataTable dtArticulos { get; set; }

        private void FrmReporteArticulos_Load(object sender, EventArgs e)
        {
            ReportDataSource dsDatosPedido = new ReportDataSource("dtArticulos", this.dtArticulos);
            reportViewer1.LocalReport.DataSources.Add(dsDatosPedido);

            //Asignar parámetros de observaciones y horas
            ReportParameter[] reportParameters = new ReportParameter[1];
            reportParameters[0] = new ReportParameter("FechaHora", DateTime.Now.ToLongDateString());
            this.reportViewer1.LocalReport.SetParameters(reportParameters);

            this.reportViewer1.RefreshReport();
        }
    }
}
