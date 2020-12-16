using CapaEntidades;
using CapaEntidades.Helpers;
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
    public partial class FrmArticulos : Form
    {
        public FrmArticulos()
        {
            InitializeComponent();
            this.btnNuevoArticulo.Click += BtnNuevoArticulo_Click;
        }

        private void BtnNuevoArticulo_Click(object sender, EventArgs e)
        {
           
        }

        public void LoadArticulos(DataTable dtArticulos)
        {
            try
            {
                if (this.ArticulosList != null)
                    this.ArticulosList.Clear();

                if (dtArticulos != null)
                {
                    List<Articulos> articulos = (from DataRow dr in dtArticulos.Rows
                                                 select new Articulos(dr)).ToList();

                    this.ArticulosList = articulos;

                    List<UserControl> controls = new List<UserControl>();
                    foreach (Articulos art in articulos)
                    {
                        ArticuloItem artItem = new ArticuloItem
                        {
                            Articulo = art,
                        };
                        artItem.OnBtnAddStock += ArtItem_OnBtnAddStock;
                        controls.Add(artItem);
                    }

                    this.panelArticulos.AddArrayControl(controls);

                    if (this.ArticulosList.Count <= 0)
                        this.lblRespuesta.Text = "No hay articulos";
                    else if (this.ArticulosList.Count == 1)
                        this.lblRespuesta.Text = "Hay un articulo";
                    else if (this.ArticulosList.Count > 1)
                        this.lblRespuesta.Text = "Se encontraron " + this.ArticulosList.Count + " articulos.";
                }
                else
                {
                    this.lblRespuesta.Text = "No hay articulos";
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "public async Task LoadArticulos",
                    "Hubo un error al buscar artículos", ex.Message);
            }
        }

        public async Task LoadArticulos(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                //Verificamos conexión
                Response connection = await ConnectionHelper.CheckConnection();
                //Si la conexión es false mostraremos un mensaje
                if (connection.IsSuccess)
                {
                    var Comprobaciones =
                        await NArticulos.BuscarArticulos(tipo_busqueda, texto_busqueda);

                    if (this.ArticulosList != null)
                        this.ArticulosList.Clear();

                    if (Comprobaciones.dtArticulos != null)
                    {
                        List<Articulos> articulos = (from DataRow dr in Comprobaciones.dtArticulos.Rows
                                                     select new Articulos(dr)).ToList();

                        List<UserControl> controls = new List<UserControl>();
                        foreach (Articulos art in articulos)
                        {
                            ArticuloItem artItem = new ArticuloItem
                            {
                                Articulo = art,
                            };
                            artItem.OnBtnAddStock += ArtItem_OnBtnAddStock;
                            controls.Add(artItem);
                        }

                        if (this.ArticulosList.Count <= 0)
                            this.lblRespuesta.Text = "No hay articulos";
                        else if (this.ArticulosList.Count == 1)
                            this.lblRespuesta.Text = "Hay un articulo";
                        else if (this.ArticulosList.Count > 1)
                            this.lblRespuesta.Text = "Se encontraron " + this.ArticulosList.Count + " articulos.";
                    }
                    else
                    {
                        this.lblRespuesta.Text = "No hay articulos";

                        if (!Comprobaciones.rpta.Equals("OK"))
                            throw new Exception(Comprobaciones.rpta);
                    }
                }
                else
                    Mensajes.MensajeInformacion("Verifique la conexión a internet", "Entendido");
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "public async Task LoadArticulos",
                    "Hubo un error al buscar artículos", ex.Message);
            }
        }

        private void ArtItem_OnBtnAddStock(object sender, EventArgs e)
        {
            Mensajes.MensajeInformacion("Adicionar stock a este articulo", "Entendido");
        }

        private List<Articulos> _articulosList;

        public List<Articulos> ArticulosList { get => _articulosList; set => _articulosList = value; }
    }
}
