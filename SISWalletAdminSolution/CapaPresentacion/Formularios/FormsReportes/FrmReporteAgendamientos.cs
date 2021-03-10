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
    public partial class FrmReporteAgendamientos : Form
    {
        public FrmReporteAgendamientos()
        {
            InitializeComponent();
        }

        public DataTable DtAgendamientos { get; set; }
        public string Total_recaudo { get; set; }

        private void FrmReporteAgendamientos_Load(object sender, EventArgs e)
        {
            ReportDataSource dsDatos = new ReportDataSource("dtAgendamientos", this.DtAgendamientos);
            reportViewer1.LocalReport.DataSources.Add(dsDatos);

            //Asignar parámetros de observaciones y horas
            ReportParameter[] reportParameters = new ReportParameter[2];
            reportParameters[0] = new ReportParameter("FechaHora", DateTime.Now.ToLongDateString());
            reportParameters[1] = new ReportParameter("Total_recaudo", Total_recaudo);
            this.reportViewer1.LocalReport.SetParameters(reportParameters);

            this.reportViewer1.RefreshReport();
        }
    }
}
