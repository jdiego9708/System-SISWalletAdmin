namespace CapaNegocio
{
    using CapaEntidades;
    using CapaDatos;
    using System.Data;
    using System.Threading.Tasks;

    public class NUsuarios
    {
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

        public static async Task<(DataTable dtUsuarios, string rpta)>BuscarUsuarios(string tipo_busqueda, string texto_busqueda)
        {
            DUsuarios DUsuarios = new DUsuarios();
            return await DUsuarios.BuscarUsuarios(tipo_busqueda, texto_busqueda);
        }

         public static async Task<(DataTable dtUsuarios, string rpta)>BuscarClientes(string tipo_busqueda, string texto_busqueda1,
            string texto_busqueda2)
        {
            DUsuarios DUsuarios = new DUsuarios();
            return await DUsuarios.BuscarClientes(tipo_busqueda, texto_busqueda1, texto_busqueda2);
        }
    }
}
