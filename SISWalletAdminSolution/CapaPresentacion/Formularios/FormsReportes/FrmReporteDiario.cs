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
    public partial class FrmReporteDiario : Form
    {
        public FrmReporteDiario()
        {
            InitializeComponent();
        }

        public string FechaHoraTurno { get; set; }
        public string FechaHoraReporte { get; set; }
        public string InformacionTurno { get; set; }



        private void FrmReporteDiario_Load(object sender, EventArgs e)
        {
            //Asignar parámetros de observaciones y horas
            ReportParameter[] reportParameters = new ReportParameter[3];
            reportParameters[0] = new ReportParameter("FechaHoraTurno", FechaHoraTurno);
            reportParameters[1] = new ReportParameter("FechaHoraReporte", FechaHoraReporte);
            reportParameters[2] = new ReportParameter("InformacionTurno", InformacionTurno);
            this.reportViewer1.LocalReport.SetParameters(reportParameters);
            this.reportViewer1.RefreshReport();
        }
    }
}
