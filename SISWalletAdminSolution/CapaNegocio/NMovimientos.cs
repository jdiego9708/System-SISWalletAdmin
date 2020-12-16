namespace CapaNegocio
{
    using CapaEntidades;
    using CapaDatos;
    using System.Threading.Tasks;
    using System.Data;

    public class NMovimientos
    {
        public static async Task<(string rpta, int id_movimiento)> InsertarMovimiento(Movimientos movimiento)
        {
            DMovimientos DMovimientos = new DMovimientos();
            return await DMovimientos.InsertarMovimiento(movimiento);
        }

        public static async Task<string> EditarMovimientos(int id_movimiento, Movimientos movimiento)
        {
            DMovimientos DMovimientos = new DMovimientos();
            return await DMovimientos.EditarMovimiento(id_movimiento, movimiento);
        }

        public static async Task<(DataTable dtMovimientos, string rpta)> BuscarMovimientos(string tipo_busqueda, string texto_busqueda)
        {
            DMovimientos DMovimientos = new DMovimientos();
            return await DMovimientos.BuscarMovimientos(tipo_busqueda, texto_busqueda);
        }
    }
}
