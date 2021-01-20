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
    public partial class FrmReporteFactura : Form
    {
        public FrmReporteFactura()
        {
            InitializeComponent();
        }

        public DataTable dtArticulosFactura { get; set; }
        public string Id_articulo { get; set; }
        public string FechaHora { get; set; }
        public string EstadoFactura { get; set; }
        public string TotalFactura { get; set; }

        private void FrmReporteFactura_Load(object sender, EventArgs e)
        {
            ReportDataSource dsDatos = new ReportDataSource("dtArticulosFactura", this.dtArticulosFactura);
            reportViewer1.LocalReport.DataSources.Add(dsDatos);

            //Asignar parámetros de observaciones y horas
            ReportParameter[] reportParameters = new ReportParameter[4];
            reportParameters[0] = new ReportParameter("Id_articulo", Id_articulo);
            reportParameters[1] = new ReportParameter("FechaHora", DateTime.Now.ToLongDateString());
            reportParameters[2] = new ReportParameter("Estado_factura", EstadoFactura);
            reportParameters[3] = new ReportParameter("Total_factura", TotalFactura);
            this.reportViewer1.LocalReport.SetParameters(reportParameters);
            this.reportViewer1.RefreshReport();
        }
    }
}
