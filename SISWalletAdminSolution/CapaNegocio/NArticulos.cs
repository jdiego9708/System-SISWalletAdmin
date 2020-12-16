namespace CapaNegocio
{
    using CapaEntidades;
    using CapaDatos;
    using System.Threading.Tasks;
    using System.Data;

    public class NArticulos
    {
        public static async Task<(string rpta, int id_articulo)> InsertarArticulo(Articulos articulo)
        {
            DArticulos DArticulos = new DArticulos();
            return await DArticulos.InsertarArticulo(articulo);
        }

        public static async Task<string> EditarArticulos(int id_articulo, Articulos articulo)
        {
            DArticulos DArticulos = new DArticulos();
            return await DArticulos.EditarArticulo(id_articulo, articulo);
        }

        public static async Task<(DataTable dtArticulos, string rpta)> BuscarArticulos(string tipo_busqueda, string texto_busqueda)
        {
            DArticulos DArticulos = new DArticulos();
            return await DArticulos.BuscarArticulos(tipo_busqueda, texto_busqueda);
        }
    }
}
