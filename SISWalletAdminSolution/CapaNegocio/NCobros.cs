namespace CapaNegocio
{
    using CapaDatos;
    using CapaEntidades;
    using System.Data;

    public class NCobros
    {
        public static string InsertarCobro(out int id_cobro, Cobros cobro)
        {
            DCobros DCobros = new DCobros();
            return DCobros.InsertarCobros(out id_cobro, cobro);
        }

        public static string EditarCobro(int id_cobro, Cobros cobro)
        {
            DCobros DCobros = new DCobros();
            return DCobros.EditarCobros(id_cobro, cobro);
        }

        public static DataTable BuscarCobros(string tipo_busqueda, string texto_busqueda1, string texto_busqueda2, out string rpta)
        {
            DCobros DCobros = new DCobros();
            return DCobros.BuscarCobros(tipo_busqueda, texto_busqueda1, texto_busqueda2, out rpta);
        }

        public static DataTable BuscarEstadisticaCobroDiario(string texto_busqueda1, string texto_busqueda2, out string rpta)
        {
            DCobros DCobros = new DCobros();
            return DCobros.BuscarEstadisticaCobroDiario(texto_busqueda1, texto_busqueda2, out rpta);
        }
    }
}
