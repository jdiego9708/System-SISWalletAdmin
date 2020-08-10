namespace CapaNegocio
{
    using CapaDatos;
    using CapaEntidades;
    using System.Collections.Generic;
    using System.Data;

    public class NUsuariosCobros
    {
        public static string InsertarUsuarioCobro(Usuarios_cobros usuarios)
        {
            DUsuarios_cobros DUsuarios_cobros = new DUsuarios_cobros();
            return DUsuarios_cobros.InsertarUsuarioCobro(usuarios);
        }

        public static DataTable BuscarUsuariosCobros(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            DUsuarios_cobros DUsuarios_cobros = new DUsuarios_cobros(); ;
            return DUsuarios_cobros.BuscarUsuariosCobros(tipo_busqueda, texto_busqueda, out rpta);
        }
    }
}
