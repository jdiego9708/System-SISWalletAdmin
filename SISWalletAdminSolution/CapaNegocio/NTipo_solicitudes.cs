namespace CapaNegocio
{
    using CapaDatos;
    using CapaEntidades;
    using System.Data;

    public class NTipo_solicitudes
    {
        public static string InsertarTipoSolicitud(out int id_tipo, Tipo_solicitudes tipo)
        {
            DTipo_solicitudes DTipo_solicitudes = new DTipo_solicitudes();
            return DTipo_solicitudes.InsertarTipoSolicitudes(out id_tipo, tipo);
        }

        public static string EditarTipoSolicitud(int id_tipo, Tipo_solicitudes tipo)
        {
            DTipo_solicitudes DTipo_solicitudes = new DTipo_solicitudes();
            return DTipo_solicitudes.EditarTipoSolicitudes(id_tipo, tipo);
        }

        public static DataTable BuscarTipoSolicitudes(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            DTipo_solicitudes DTipo_solicitudes = new DTipo_solicitudes();
            return DTipo_solicitudes.BuscarTiposSolicitudes(tipo_busqueda, texto_busqueda, out rpta);
        }
    }
}
