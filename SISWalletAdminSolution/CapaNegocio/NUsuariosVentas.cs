namespace CapaNegocio
{
    using CapaDatos;
    using CapaEntidades;
    using System.Collections.Generic;
    using System.Data;

    public class NUsuariosVentas
    {
        public static string InsertarUsuarioVenta(Usuarios_ventas usuarios)
        {
            DUsuarios_ventas DUsuarios_ventas = new DUsuarios_ventas();
            return DUsuarios_ventas.InsertarUsuarioVenta(usuarios);
        }

        public static string InsertarUsuarioVenta(List<Usuarios_ventas> usuarios)
        {
            DUsuarios_ventas DUsuarios_ventas = new DUsuarios_ventas();
            return DUsuarios_ventas.InsertarUsuarioVenta(usuarios);
        }

        public static DataTable BuscarUsuariosVentas(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            DUsuarios_ventas DUsuarios_ventas = new DUsuarios_ventas();
            return DUsuarios_ventas.BuscarUsuariosVentas(tipo_busqueda, texto_busqueda, out rpta);
        }
    }
}
