
namespace CapaPresentacion.Formularios.FormsClientes
{
    partial class AgendamientoSmall
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgendamientoSmall));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtInfoCliente = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAbono = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtInfoCliente);
            this.groupBox1.Location = new System.Drawing.Point(0, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(567, 77);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información de pago";
            // 
            // txtInfoCliente
            // 
            this.txtInfoCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInfoCliente.BackColor = System.Drawing.Color.White;
            this.txtInfoCliente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInfoCliente.Enabled = false;
            this.txtInfoCliente.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtInfoCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtInfoCliente.Location = new System.Drawing.Point(6, 18);
            this.txtInfoCliente.Multiline = true;
            this.txtInfoCliente.Name = "txtInfoCliente";
            this.txtInfoCliente.ReadOnly = true;
            this.txtInfoCliente.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInfoCliente.Size = new System.Drawing.Size(555, 53);
            this.txtInfoCliente.TabIndex = 1;
            this.txtInfoCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(613, 5);
            this.panel1.TabIndex = 1;
            // 
            // btnAbono
            // 
            this.btnAbono.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAbono.BackgroundImage")));
            this.btnAbono.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAbono.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnAbono.FlatAppearance.BorderSize = 0;
            this.btnAbono.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbono.Location = new System.Drawing.Point(572, 30);
            this.btnAbono.Name = "btnAbono";
            this.btnAbono.Size = new System.Drawing.Size(35, 35);
            this.btnAbono.TabIndex = 6;
            this.btnAbono.UseVisualStyleBackColor = true;
            this.btnAbono.Visible = false;
            // 
            // AgendamientoSmall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnAbono);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AgendamientoSmall";
            this.Size = new System.Drawing.Size(612, 87);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtInfoCliente;
        private System.Windows.Forms.Button btnAbono;
    }
}
