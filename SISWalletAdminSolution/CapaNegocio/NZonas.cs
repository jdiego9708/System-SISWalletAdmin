namespace CapaNegocio
{
    using CapaDatos;
    using CapaEntidades;
    using System.Data;

    public class NZonas
    {
        public static string InsertarZona(out int id_zona, Zonas zona)
        {
            DZonas DZonas = new DZonas();
            return DZonas.InsertarZona(out id_zona, zona);
        }

        public static string EditarZona(int id_zona, Zonas zona)
        {
            DZonas DZonas = new DZonas();
            return DZonas.EditarZona(id_zona, zona);
        }

        public static DataTable BuscarZonas(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            DZonas DZonas = new DZonas();
            return DZonas.BuscarZonas(tipo_busqueda, texto_busqueda, out rpta);
        }
    }
}
