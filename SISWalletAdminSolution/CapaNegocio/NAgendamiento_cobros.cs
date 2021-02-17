namespace CapaNegocio
{
    using CapaDatos;
    using CapaEntidades;
    using System.Data;
    using System.Threading.Tasks;

    public class NAgendamiento_cobros
    {
        public static string InsertarAgendamiento(out int id_agendamiento, Agendamiento_cobros agendamiento)
        {
            DAgendamiento_cobros DAgendamiento_cobros = new DAgendamiento_cobros();
            return DAgendamiento_cobros.InsertarAgendamiento(out id_agendamiento, agendamiento);
        }

        public static async Task<string>EditarAgendamiento(int id_agendamiento, Agendamiento_cobros agendamiento)
        {
            DAgendamiento_cobros DAgendamiento_cobros = new DAgendamiento_cobros();
            return await DAgendamiento_cobros.EditarAgendamiento(id_agendamiento, agendamiento);
        }

        public static async Task<(string rpta, DataTable dtAgendamientos)>BuscarAgendamientos(string tipo_busqueda, string texto_busqueda)
        {
            DAgendamiento_cobros DAgendamiento_cobros = new DAgendamiento_cobros();
            return await DAgendamiento_cobros.BuscarAgendamiento(tipo_busqueda, texto_busqueda);
        }
    }
}
