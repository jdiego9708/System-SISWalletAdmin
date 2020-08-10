namespace CapaNegocio
{
    using CapaDatos;
    using CapaEntidades;
    using System.Data;

    public class NSolicitudes
    {
        public static string InsertarSolicitud(out int id_solicitud, Solicitudes solicitud)
        {
            DSolicitudes DSolicitudes = new DSolicitudes();
            return DSolicitudes.InsertarSolicitud(out id_solicitud, solicitud);
        }

        public static string EditarSolicitud(int id_solicitud, Solicitudes solicitud)
        {
            DSolicitudes DSolicitudes = new DSolicitudes();
            return DSolicitudes.EditarSolicitud(id_solicitud, solicitud);
        }

        public static DataTable BuscarSolicitudes(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            DSolicitudes DSolicitudes = new DSolicitudes();
            return DSolicitudes.BuscarSolicitudes(tipo_busqueda, texto_busqueda, out rpta);
        }
    }
}
