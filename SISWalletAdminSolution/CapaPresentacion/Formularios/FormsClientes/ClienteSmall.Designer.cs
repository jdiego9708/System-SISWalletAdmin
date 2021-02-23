
namespace CapaPresentacion.Formularios.FormsClientes
{
    partial class ClienteSmall
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClienteSmall));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtInfoCliente = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtInfoPago = new System.Windows.Forms.TextBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnAbono = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnRemove = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(445, 5);
            this.panel1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtInfoCliente);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.groupBox2.Location = new System.Drawing.Point(3, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(439, 78);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Información del cliente";
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
            this.txtInfoCliente.Location = new System.Drawing.Point(7, 21);
            this.txtInfoCliente.Multiline = true;
            this.txtInfoCliente.Name = "txtInfoCliente";
            this.txtInfoCliente.ReadOnly = true;
            this.txtInfoCliente.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInfoCliente.Size = new System.Drawing.Size(426, 51);
            this.txtInfoCliente.TabIndex = 0;
            this.txtInfoCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtInfoPago);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.groupBox1.Location = new System.Drawing.Point(3, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(439, 83);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información de última venta";
            // 
            // txtInfoPago
            // 
            this.txtInfoPago.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInfoPago.BackColor = System.Drawing.Color.White;
            this.txtInfoPago.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInfoPago.Enabled = false;
            this.txtInfoPago.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtInfoPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtInfoPago.Location = new System.Drawing.Point(6, 16);
            this.txtInfoPago.Multiline = true;
            this.txtInfoPago.Name = "txtInfoPago";
            this.txtInfoPago.ReadOnly = true;
            this.txtInfoPago.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInfoPago.Size = new System.Drawing.Size(426, 61);
            this.txtInfoPago.TabIndex = 1;
            this.txtInfoPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnNext
            // 
            this.btnNext.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNext.BackgroundImage")));
            this.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNext.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Location = new System.Drawing.Point(404, 178);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(35, 35);
            this.btnNext.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnNext, "Observar historial");
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // btnAbono
            // 
            this.btnAbono.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAbono.BackgroundImage")));
            this.btnAbono.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAbono.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnAbono.FlatAppearance.BorderSize = 0;
            this.btnAbono.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbono.Location = new System.Drawing.Point(363, 178);
            this.btnAbono.Name = "btnAbono";
            this.btnAbono.Size = new System.Drawing.Size(35, 35);
            this.btnAbono.TabIndex = 5;
            this.toolTip1.SetToolTip(this.btnAbono, "Realizar abono");
            this.btnAbono.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRemove.BackgroundImage")));
            this.btnRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemove.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnRemove.FlatAppearance.BorderSize = 0;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Location = new System.Drawing.Point(3, 178);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(35, 35);
            this.btnRemove.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btnRemove, "Inactivar/Borrar cliente");
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // ClienteSmall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAbono);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ClienteSmall";
            this.Size = new System.Drawing.Size(445, 216);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtInfoCliente;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtInfoPago;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnAbono;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnRemove;
    }
}
