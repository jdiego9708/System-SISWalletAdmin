namespace CapaNegocio
{
    using CapaDatos;
    using CapaEntidades;
    using System.Data;
    using System.Threading.Tasks;

    public class NVentas
    {
        public static string InsertarVenta(out int id_venta, Ventas venta)
        {
            DVentas DVentas = new DVentas();
            return DVentas.InsertarVentas(out id_venta, venta);
        }

        public static string EditarVenta(int id_venta, Ventas venta)
        {
            DVentas DVentas = new DVentas();
            return DVentas.EditarVentas(id_venta, venta);
        }

        public static async Task<(string rpta, DataTable dtVentas)> BuscarVentas(string tipo_busqueda, string texto_busqueda)
        {
            DVentas DVentas = new DVentas();
            return await DVentas.BuscarVentas(tipo_busqueda, texto_busqueda);
        }
    }
}
