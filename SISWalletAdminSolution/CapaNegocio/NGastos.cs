namespace CapaNegocio
{
    using CapaDatos;
    using CapaEntidades;
    using System.Data;

    public class NGastos
    {
        public static string InsertarGastos(out int id_gasto, Gastos gasto)
        {
            DGastos DGastos = new DGastos();
            return DGastos.InsertarGastos(out id_gasto, gasto);
        }

        public static string EditarGastos(int id_gasto, Gastos gasto)
        {
            DGastos DGastos = new DGastos();
            return DGastos.EditarGastos(id_gasto, gasto);
        }

        public static DataTable BuscarGastos(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            DGastos DGastos = new DGastos();
            return DGastos.BuscarGastos(tipo_busqueda, texto_busqueda, out rpta);
        }
    }
}
