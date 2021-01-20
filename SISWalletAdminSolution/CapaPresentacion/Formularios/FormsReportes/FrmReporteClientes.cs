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
    public partial class FrmReporteClientes : Form
    {
        public FrmReporteClientes()
        {
            InitializeComponent();
        }

        public DataTable dtClientes { get; set; }
        public string Total_ventas { get; set; }
        public string Total_saldos{ get; set; }

        private void FrmReporteClientes_Load(object sender, EventArgs e)
        {
            ReportDataSource dsDatos= new ReportDataSource("dtClientes", this.dtClientes);
            reportViewer1.LocalReport.DataSources.Add(dsDatos);

            //Asignar parámetros de observaciones y horas
            ReportParameter[] reportParameters = new ReportParameter[3];
            reportParameters[0] = new ReportParameter("FechaHora", DateTime.Now.ToLongDateString());
            reportParameters[1] = new ReportParameter("Total_ventas", Total_ventas);
            reportParameters[2] = new ReportParameter("Total_saldos", Total_saldos);
            this.reportViewer1.LocalReport.SetParameters(reportParameters);

            this.reportViewer1.RefreshReport();
        }
    }
}
