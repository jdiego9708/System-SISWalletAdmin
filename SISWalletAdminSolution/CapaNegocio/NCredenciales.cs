namespace CapaNegocio
{
    using CapaDatos;
    using CapaEntidades;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;

    public class NCredenciales
    {
        public static string InsertarCredencial(out int id_credencial, Credenciales credencial)
        {
            DCredenciales DCredenciales = new DCredenciales();
            return DCredenciales.InsertarCredencial(out id_credencial, credencial);
        }

        public static string EditarCredencial(int id_credencial, Credenciales credencial)
        {
            DCredenciales DCredenciales = new DCredenciales();
            return DCredenciales.EditarCredencial(id_credencial, credencial);
        }

        public static DataTable BuscarCredenciales(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            DCredenciales DCredenciales = new DCredenciales();
            return DCredenciales.BuscarCredenciales(tipo_busqueda, texto_busqueda, out rpta);
        }

        public static async Task<(string rpta, List<object> objects)> Login(string usuario, string pass, string fecha)
        {
            DCredenciales DCredenciales = new DCredenciales();
            return await DCredenciales.Login(usuario, pass, fecha);
        }
    }
}
