namespace CapaNegocio
{
    using CapaDatos;
    using CapaEntidades;
    using System.Data;

    public class NTipo_gastos
    {
        public static string InsertarTipoGasto(out int id_tipo_gasto, Tipo_gastos gasto)
        {
            DTipo_gastos DTipo_gastos = new DTipo_gastos();
            return DTipo_gastos.InsertarTipoGastos(out id_tipo_gasto, gasto);
        }

        public static string EditarTipoGasto(int id_tipo_gasto, Tipo_gastos gasto)
        {
            DTipo_gastos DTipo_gastos = new DTipo_gastos();
            return DTipo_gastos.EditarTipoGastos(id_tipo_gasto, gasto);
        }

        public static DataTable BuscarTipoGastos(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            DTipo_gastos DTipo_gastos = new DTipo_gastos();
            return DTipo_gastos.BuscarGastos(tipo_busqueda, texto_busqueda, out rpta);
        }
    }
}
