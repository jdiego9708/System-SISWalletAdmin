namespace CapaNegocio
{
    using CapaDatos;
    using CapaEntidades;
    using System.Data;

    public class NTurnos
    {
        public static string InsertarTurno(out int id_turno, Turnos turno)
        {
            DTurnos DTurnos = new DTurnos();
            return DTurnos.InsertarTurno(out id_turno, turno);
        }

        public static string EditarTurno( int id_turno, Turnos turno)
        {
            DTurnos DTurnos = new DTurnos();
            return DTurnos.EditarVentas(id_turno, turno);
        }

        public static DataTable BuscarTurnos(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            DTurnos DTurnos = new DTurnos();
            return DTurnos.BuscarTurnos(tipo_busqueda, texto_busqueda, out rpta);
        }
    }
}
