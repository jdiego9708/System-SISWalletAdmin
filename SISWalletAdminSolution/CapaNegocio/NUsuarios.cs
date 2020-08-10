namespace CapaNegocio
{
    using CapaDatos;
    using CapaEntidades;
    using System.Data;

    public class NUsuarios
    {
        public static string InsertarUsuarios(string consulta)
        {
            DUsuarios DUsuarios = new DUsuarios();
            return DUsuarios.InsertarUsuarios(consulta);
        }

        public static string InsertarUsuario(out int id_usuario, Usuarios usuario)
        {
            DUsuarios DUsuarios = new DUsuarios();
            return DUsuarios.InsertarUsuario(out id_usuario, usuario);
        }

        public static string EditarUsuario(int id_usuario, Usuarios usuario)
        {
            DUsuarios DUsuarios = new DUsuarios();
            return DUsuarios.EditarUsuario(id_usuario, usuario);
        }

        public static DataTable BuscarUsuarios(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            DUsuarios DUsuarios = new DUsuarios();
            return DUsuarios.BuscarUsuarios(tipo_busqueda, texto_busqueda, out rpta);
        }
    }
}
