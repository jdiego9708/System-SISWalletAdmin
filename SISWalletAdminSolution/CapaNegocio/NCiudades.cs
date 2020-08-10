namespace CapaNegocio
{
    using CapaDatos;
    using CapaEntidades;
    using System.Data;

    public class NCiudades
    {
        public static string InsertarCiudad(out int id_ciudad, Ciudades ciudad)
        {
            DCiudades DCiudades = new DCiudades();
            return DCiudades.InsertarCiudad(out id_ciudad, ciudad);
        }

        public static string EditarCiudad(int id_ciudad, Ciudades ciudad)
        {
            DCiudades DCiudades = new DCiudades();
            return DCiudades.EditarCiudad(id_ciudad, ciudad);
        }

        public static DataTable BuscarCiudades(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            DCiudades DCiudades = new DCiudades();
            return DCiudades.BuscarCiudades(tipo_busqueda, texto_busqueda, out rpta);
        }
    }
}
