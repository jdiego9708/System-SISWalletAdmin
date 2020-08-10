namespace CapaNegocio
{
    using CapaDatos;
    using CapaEntidades;
    using System.Data;

    public class NTipo_productos
    {
        public static string InsertarTipoProducto(out int id_tipo, Tipo_productos tipo)
        {
            DTipo_productos DTipo_productos = new DTipo_productos();
            return DTipo_productos.InsertarTipoProductos(out id_tipo, tipo);
        }

        public static string EditarTipoProducto(int id_tipo, Tipo_productos tipo)
        {
            DTipo_productos DTipo_productos = new DTipo_productos();
            return DTipo_productos.EditarTipoProductos(id_tipo, tipo);
        }

        public static DataTable BuscarTipoProducto(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            DTipo_productos DTipo_productos = new DTipo_productos();
            return DTipo_productos.BuscarTiposProductos(tipo_busqueda, texto_busqueda, out rpta);
        }
    }
}
