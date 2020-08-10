namespace CapaNegocio
{
    using CapaDatos;
    using CapaEntidades;
    using System.Data;

    public class NDireccion_clientes
    {
        public static string InsertarDireccion(out int id_direccion, Direccion_clientes direccion)
        {
            DDireccion_clientes DDireccion_clientes = new DDireccion_clientes();
            return DDireccion_clientes.InsertarDireccion(out id_direccion, direccion);
        }

        public static string EditarDireccion(int id_direccion, Direccion_clientes direccion)
        {
            DDireccion_clientes DDireccion_clientes = new DDireccion_clientes();
            return DDireccion_clientes.EditarDireccion(id_direccion, direccion);
        }

        public static DataTable BuscarDirecciones(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            DDireccion_clientes DDireccion_clientes = new DDireccion_clientes();
            return DDireccion_clientes.BuscarDirecciones(tipo_busqueda, texto_busqueda, out rpta);
        }
    }
}
