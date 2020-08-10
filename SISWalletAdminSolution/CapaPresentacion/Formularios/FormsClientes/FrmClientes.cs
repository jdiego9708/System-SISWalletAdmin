namespace CapaPresentacion.Formularios.FormsClientes
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using Syncfusion.WinForms.Controls;

    public partial class FrmClientes : SfForm
    {
        PoperContainer container;

        public FrmClientes()
        {
            InitializeComponent();

            #region PROPIEDADES DE FORMULARIO
            this.Style.TitleBar.Height = 26;
            this.Style.TitleBar.BackColor = Color.White;
            this.Style.TitleBar.IconBackColor = Color.FromArgb(15, 161, 212);
            this.BackColor = Color.White;
            this.Style.TitleBar.ForeColor = ColorTranslator.FromHtml("#343434");
            this.Style.TitleBar.CloseButtonForeColor = Color.DarkGray;
            this.Style.TitleBar.MaximizeButtonForeColor = Color.DarkGray;
            this.Style.TitleBar.MinimizeButtonForeColor = Color.DarkGray;
            this.Style.TitleBar.HelpButtonForeColor = Color.DarkGray;
            this.Style.TitleBar.IconHorizontalAlignment = HorizontalAlignment.Left;
            this.Style.TitleBar.Font = this.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.Style.TitleBar.TextHorizontalAlignment = HorizontalAlignment.Center;
            this.Style.TitleBar.TextVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            #endregion

            this.btnImportarClientes.Click += BtnImportarClientes_Click;
        }

        private void BtnImportarClientes_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCargarClientes frm = new FrmCargarClientes
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill,
                };
                Form FormComprobado = this.ComprobarExistencia(frm);
                if (FormComprobado != null)
                {
                    frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                }
                else
                {
                    this.panel1.Controls.Add(frm);
                    this.panel1.Tag = frm;
                    frm.Show();
                }
                frm.BringToFront();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnImportarClientes_Click",
                    "Hubo un error con el botón importar clientes", ex.Message);
            }
        }

        private Form ComprobarExistencia(Form form)
        {
            if (container != null)
                container.Close();

            Form frmDevolver = null;
            foreach (Form frm in this.panel1.Controls)
            {
                if (frm.Name.Equals(form.Name))
                {
                    frmDevolver = frm;
                    break;
                }

            }
            return frmDevolver;
        }
    }
}
