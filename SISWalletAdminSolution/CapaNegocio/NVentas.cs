namespace CapaNegocio
{
    using CapaDatos;
    using CapaEntidades;
    using System.Data;

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

        public static DataTable BuscarVentas(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            DVentas DVentas = new DVentas();
            return DVentas.BuscarVentas(tipo_busqueda, texto_busqueda, out rpta);
        }
    }
}
