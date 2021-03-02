
namespace CapaPresentacion.Formularios.FormsClientes
{
    partial class FrmAgendamientoVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAgendamientoVentas));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelPagos = new CapaPresentacion.Controles.CustomGridPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rdNoPagos = new System.Windows.Forms.RadioButton();
            this.rdTerminados = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtInformacion = new System.Windows.Forms.TextBox();
            this.btnAbono = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.panelPagos);
            this.groupBox1.Location = new System.Drawing.Point(12, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(635, 454);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información de pagos";
            // 
            // panelPagos
            // 
            this.panelPagos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPagos.AutoScroll = true;
            this.panelPagos.Location = new System.Drawing.Point(3, 21);
            this.panelPagos.Name = "panelPagos";
            this.panelPagos.PageSize = 10;
            this.panelPagos.Size = new System.Drawing.Size(626, 427);
            this.panelPagos.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.rdNoPagos);
            this.groupBox2.Controls.Add(this.rdTerminados);
            this.groupBox2.Location = new System.Drawing.Point(12, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(143, 103);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtros";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButton1.Location = new System.Drawing.Point(6, 72);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(122, 21);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Todos por fecha";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // rdNoPagos
            // 
            this.rdNoPagos.AutoSize = true;
            this.rdNoPagos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdNoPagos.Location = new System.Drawing.Point(6, 45);
            this.rdNoPagos.Name = "rdNoPagos";
            this.rdNoPagos.Size = new System.Drawing.Size(85, 21);
            this.rdNoPagos.TabIndex = 3;
            this.rdNoPagos.Text = "No pagos";
            this.rdNoPagos.UseVisualStyleBackColor = true;
            // 
            // rdTerminados
            // 
            this.rdTerminados.AutoSize = true;
            this.rdTerminados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdTerminados.Location = new System.Drawing.Point(6, 18);
            this.rdTerminados.Name = "rdTerminados";
            this.rdTerminados.Size = new System.Drawing.Size(94, 21);
            this.rdTerminados.TabIndex = 2;
            this.rdTerminados.Text = "Terminados";
            this.rdTerminados.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnAbono);
            this.groupBox3.Controls.Add(this.txtInformacion);
            this.groupBox3.Location = new System.Drawing.Point(161, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(480, 103);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Información";
            // 
            // txtInformacion
            // 
            this.txtInformacion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInformacion.BackColor = System.Drawing.Color.White;
            this.txtInformacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInformacion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtInformacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtInformacion.Location = new System.Drawing.Point(47, 18);
            this.txtInformacion.Multiline = true;
            this.txtInformacion.Name = "txtInformacion";
            this.txtInformacion.ReadOnly = true;
            this.txtInformacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInformacion.Size = new System.Drawing.Size(427, 79);
            this.txtInformacion.TabIndex = 2;
            this.txtInformacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnAbono
            // 
            this.btnAbono.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAbono.BackgroundImage")));
            this.btnAbono.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAbono.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnAbono.FlatAppearance.BorderSize = 0;
            this.btnAbono.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbono.Location = new System.Drawing.Point(6, 24);
            this.btnAbono.Name = "btnAbono";
            this.btnAbono.Size = new System.Drawing.Size(35, 35);
            this.btnAbono.TabIndex = 8;
            this.btnAbono.UseVisualStyleBackColor = true;
            // 
            // FrmAgendamientoVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(659, 573);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmAgendamientoVentas";
            this.Text = "Agendamientos";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Controles.CustomGridPanel panelPagos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdTerminados;
        private System.Windows.Forms.RadioButton rdNoPagos;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtInformacion;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button btnAbono;
    }
}