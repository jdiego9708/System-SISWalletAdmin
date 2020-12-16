
namespace CapaPresentacion.Formularios.FormsArticulos
{
    partial class FrmArticulos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmArticulos));
            this.lblRespuesta = new System.Windows.Forms.Label();
            this.txtBusqueda = new CapaPresentacion.CustomTextBox();
            this.panelArticulos = new CapaPresentacion.CustomGridPanel();
            this.btnNuevoArticulo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblRespuesta
            // 
            this.lblRespuesta.AutoSize = true;
            this.lblRespuesta.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRespuesta.Location = new System.Drawing.Point(12, 46);
            this.lblRespuesta.Name = "lblRespuesta";
            this.lblRespuesta.Size = new System.Drawing.Size(116, 19);
            this.lblRespuesta.TabIndex = 0;
            this.lblRespuesta.Text = "Stock de artículos";
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBusqueda.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.txtBusqueda.BackColor = System.Drawing.Color.White;
            this.txtBusqueda.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusqueda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBusqueda.Imagen = null;
            this.txtBusqueda.Location = new System.Drawing.Point(53, 13);
            this.txtBusqueda.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBusqueda.MaxLenght = 0;
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(635, 20);
            this.txtBusqueda.TabIndex = 1;
            this.txtBusqueda.Texto = "Búsqueda de artículos";
            this.txtBusqueda.Texto_inicial = "Búsqueda de artículos";
            this.txtBusqueda.Tipo_txt = null;
            this.txtBusqueda.Visible_px = true;
            // 
            // panelArticulos
            // 
            this.panelArticulos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelArticulos.AutoScroll = true;
            this.panelArticulos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelArticulos.Location = new System.Drawing.Point(12, 76);
            this.panelArticulos.Name = "panelArticulos";
            this.panelArticulos.PageSize = 10;
            this.panelArticulos.Size = new System.Drawing.Size(676, 370);
            this.panelArticulos.TabIndex = 0;
            // 
            // btnNuevoArticulo
            // 
            this.btnNuevoArticulo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevoArticulo.BackgroundImage")));
            this.btnNuevoArticulo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNuevoArticulo.FlatAppearance.BorderColor = System.Drawing.Color.Teal;
            this.btnNuevoArticulo.FlatAppearance.BorderSize = 0;
            this.btnNuevoArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoArticulo.Location = new System.Drawing.Point(12, 5);
            this.btnNuevoArticulo.Name = "btnNuevoArticulo";
            this.btnNuevoArticulo.Size = new System.Drawing.Size(35, 35);
            this.btnNuevoArticulo.TabIndex = 4;
            this.btnNuevoArticulo.UseVisualStyleBackColor = true;
            // 
            // FrmArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(700, 458);
            this.Controls.Add(this.btnNuevoArticulo);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.lblRespuesta);
            this.Controls.Add(this.panelArticulos);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmArticulos";
            this.Text = "Artículos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomGridPanel panelArticulos;
        private System.Windows.Forms.Label lblRespuesta;
        private CustomTextBox txtBusqueda;
        private System.Windows.Forms.Button btnNuevoArticulo;
    }
}