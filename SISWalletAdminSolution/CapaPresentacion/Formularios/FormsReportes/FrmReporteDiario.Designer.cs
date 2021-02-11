
namespace CapaPresentacion.Formularios.FormsReportes
{
    partial class FrmReporteDiario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReporteDiario));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.gbReporte = new System.Windows.Forms.GroupBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.gbReporte.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbReporte
            // 
            this.gbReporte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbReporte.Controls.Add(this.reportViewer1);
            this.gbReporte.Location = new System.Drawing.Point(12, 12);
            this.gbReporte.Name = "gbReporte";
            this.gbReporte.Size = new System.Drawing.Size(657, 413);
            this.gbReporte.TabIndex = 1;
            this.gbReporte.TabStop = false;
            this.gbReporte.Text = "Reporte";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Formularios.FormsReportes.rptEstadisticasDiarias.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 21);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(651, 389);
            this.reportViewer1.TabIndex = 2;
            // 
            // FrmReporteDiario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(681, 442);
            this.Controls.Add(this.gbReporte);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmReporteDiario";
            this.Text = "Reporte diario";
            this.Load += new System.EventHandler(this.FrmReporteDiario_Load);
            this.gbReporte.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox gbReporte;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}