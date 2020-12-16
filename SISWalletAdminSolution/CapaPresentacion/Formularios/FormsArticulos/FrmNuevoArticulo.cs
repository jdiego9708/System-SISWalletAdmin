using CapaEntidades;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.FormsArticulos
{
    public partial class FrmNuevoArticulo : Form
    {
        public FrmNuevoArticulo()
        {
            InitializeComponent();
            this.Load += FrmNuevoArticulo_Load;
            this.txtValor.KeyPress += TxtValor_KeyPress;
            this.btnGuardar.Click += BtnGuardar_Click;
        }

        public event EventHandler OnArticuloSuccess;

        private void Limpiar()
        {
            this.txtReferencia.Clear();
            this.txtDescripcion.Clear();
            this.numericCantidad.Value = 1;
            this.txtValor.Text = "0";
        }

        private bool Comprobaciones(out Articulos articulo)
        {
            if (this.IsEditar)
                articulo = this.Articulo;
            else
                articulo = new Articulos();

            if (string.IsNullOrWhiteSpace(this.txtReferencia.Text))
            {
                Mensajes.MensajeInformacion("La referencia no puede estar vacía", "Entendido");
                return false;
            }

            if (this.numericCantidad.Value == 0)
            {
                Mensajes.MensajeInformacion("Verifique la cantidad no puede ser 0", "Entendido");
                return false;
            }

            if (string.IsNullOrWhiteSpace(this.listaTipoCantidad.Text))
            {
                Mensajes.MensajeInformacion("El tipo de cantidad no puede estar vacío", "Entendido");
                return false;
            }

            if (!decimal.TryParse(this.txtValor.Text, out decimal valor))
            {
                Mensajes.MensajeInformacion("Verifique el valor", "Entendido");
                return false;
            }
            else
            {
                if (valor == 0)
                {
                    Mensajes.MensajeInformacion("Verifique el valor no puede ser 0", "Entendido");
                    return false;
                }
            }

            articulo.Referencia_articulo = this.txtReferencia.Text.ToUpper();
            articulo.Tipo_cantidad = this.listaTipoCantidad.Text.ToUpper();
            articulo.Cantidad_articulo = this.numericCantidad.Value;
            articulo.Valor_articulo = valor;
            articulo.Descripcion_articulo = this.txtDescripcion.Text;
            articulo.Estado_articulo = "ACTIVO";
            return true;
        }

        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Comprobaciones(out Articulos articulo))
                {
                    MensajeEspera.ShowWait("Guardando...");
                    string rpta = "OK";

                    if (this.IsEditar)
                    {
                        rpta = await NArticulos.EditarArticulos(articulo.Id_articulo, articulo);
                    }
                    else
                    {
                        var (rptaArticulo, id_articulo) = await NArticulos.InsertarArticulo(articulo);
                        rpta = rptaArticulo;
                        articulo.Id_articulo = id_articulo;
                    }

                    MensajeEspera.CloseForm();
                    if (rpta.Equals("OK"))
                    {
                        this.Limpiar();
                        Mensajes.MensajeInformacion("Se guardó correctamente el artículo", "Entendido");
                        this.OnArticuloSuccess?.Invoke(articulo, e);
                    }
                    else
                        throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                MensajeEspera.CloseForm();
                Mensajes.MensajeErrorCompleto(this.Name, "BtnGuardar_Click",
                    "Hubo un error con el botón guardar", ex.Message);
            }
        }

        private void TxtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void TxtStockInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void ListaTipoCantidad()
        {
            this.listaTipoCantidad.Items.Clear();
            this.listaTipoCantidad.Items.Add("UNIDADES");
        }

        private void FrmNuevoArticulo_Load(object sender, EventArgs e)
        {
            this.ListaTipoCantidad();
        }

        public void AsignarDatos(Articulos articulo)
        {
            this.txtValor.Text = ((int)articulo.Valor_articulo).ToString();
            this.txtReferencia.Text = articulo.Referencia_articulo;
            this.numericCantidad.Value = articulo.Cantidad_articulo;
            this.txtDescripcion.Text = articulo.Descripcion_articulo;
            this.ListaTipoCantidad();
            this.listaTipoCantidad.SelectedIndex = listaTipoCantidad.FindStringExact(articulo.Tipo_cantidad);
        }

        private bool isEditar;
        private Articulos _articulo;

        public bool IsEditar
        {
            get => isEditar;
            set
            {
                isEditar = value;
                this.Text = "Editar un artículo";
                this.txtReferencia.ReadOnly = true;
                this.txtDescripcion.ReadOnly = true;
                this.txtValor.ReadOnly = true;
                this.listaTipoCantidad.Enabled = false;
            }
        }

        public Articulos Articulo
        {
            get => _articulo;
            set
            {
                _articulo = value;
                this.IsEditar = true;
            }
        }
    }
}
