namespace CapaPresentacion.Formularios.FormsClientes
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using Syncfusion.WinForms.Controls;
    using CapaEntidades;
    using System.Data;
    using CapaNegocio;
    using System.Linq;
    using CapaPresentacion.Formularios.FormsPrincipales;
    using System;

    public partial class FrmConfiguracionCargaClientes : SfForm
    {
        public FrmConfiguracionCargaClientes()
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

            this.Load += FrmConfiguracionCargaClientes_Load;
            this.btnIniciarImportacion.Click += BtnIniciarImportacion_Click;
        }

        public event EventHandler OnBtnContinuarClick;

        private void BtnIniciarImportacion_Click(object sender, System.EventArgs e)
        {
            if (!int.TryParse(this.listaCobro.SelectedValue.ToString(), out int id_cobro))
            {
                Mensajes.MensajeInformacion("Compruebe el cobro seleccionado", "Entendido");
                return;
            }

            int id_zona = 0;
            DataTable dtCobros = 
                NCobros.BuscarCobros("ID COBRO", id_cobro.ToString(), "", out string rpta);
            if (dtCobros != null)
            {
                Cobros co = new Cobros(dtCobros.Rows[0]);
                id_zona = co.Id_zona;
            }

            if (id_zona == 0)
            {
                Mensajes.MensajeInformacion("Compruebe la zona del cobro", "Entendido");
                return;
            }

            if (!int.TryParse(this.listaProductos.SelectedValue.ToString(), out int id_producto))
            {
                Mensajes.MensajeInformacion("Compruebe el producto seleccionado", "Entendido");
                return;
            }

            if (!decimal.TryParse(this.listaInteres.SelectedValue.ToString(), out decimal valor_interes))
            {
                Mensajes.MensajeInformacion("Compruebe el interes seleccionado", "Entendido");
                return;
            }

            if (string.IsNullOrWhiteSpace(this.listaFrecuencia.Text))
            {
                Mensajes.MensajeInformacion("Compruebe la frecuencia", "Entendido");
                return;
            }

            object[] objs = new object[]
            {
                id_cobro,
                id_producto,
                valor_interes,
                this.listaFrecuencia.Text,
                id_zona,
            };

            this.OnBtnContinuarClick.Invoke(objs, e);
            this.Close();
        }

        private void FrmConfiguracionCargaClientes_Load(object sender, System.EventArgs e)
        {
            this.listaFrecuencia.DataSource = this.CargarListaFrecuencia();

            List<InteresItem> intereses = this.CargarListaIntereses();
            if (intereses != null)
            {
                this.listaInteres.DataSource = intereses;
                this.listaInteres.ValueMember = "Valor_interes";
                this.listaInteres.DisplayMember = "Texto_interes";
            }

            List<Tipo_productos> productos = this.CargarListaProductos();
            if (productos != null)
            {
                this.listaProductos.DataSource = productos;
                this.listaProductos.ValueMember = "Id_tipo_producto";
                this.listaProductos.DisplayMember = "Nombre_producto";
            }

            List<Cobros> cobros = this.CargarListaCobros();
            if (cobros != null)
            {
                this.listaCobro.DataSource = cobros;
                this.listaCobro.ValueMember = "Id_cobro";
                this.listaCobro.DisplayMember = "Observaciones";
            }
        }

        private List<Cobros> CargarListaCobros()
        {
            MainController main = MainController.GetInstance();
            DataTable dtCobros = NCobros.BuscarCobros("ID USUARIO", main.Usuario.Id_usuario.ToString(), "", out string rpta);
            if (dtCobros != null)
            {
                List<Cobros> cobros = (from DataRow dr in dtCobros.Rows
                                                  select new Cobros(dr)).ToList();
                return cobros;
            }
            else
                return null;
        }

        private List<Tipo_productos> CargarListaProductos()
        {
            DataTable dtProductos = NTipo_productos.BuscarTipoProducto("COMPLETO", "", out string rpta);
            if (dtProductos != null)
            {
                List<Tipo_productos> productos = (from DataRow dr in dtProductos.Rows
                                                  select new Tipo_productos(dr)).ToList();
                return productos;
            }
            else
                return null;
        }

        private List<string> CargarListaFrecuencia()
        {
            return new List<string>
            {
                "DIARIA",
                "SEMANAL",
                "QUINCENAL",
                "MENSUAL",
            };
        }

        private List<InteresItem> CargarListaIntereses()
        {
            return new List<InteresItem>
            {
                new InteresItem {Texto_interes = "20%", Valor_interes = 0.20m},
                new InteresItem {Texto_interes = "0%", Valor_interes = 0m},
            };
        }

        public class InteresItem
        {
            public string Texto_interes { get; set; }
            public decimal Valor_interes { get; set; }
        }
    }
}
