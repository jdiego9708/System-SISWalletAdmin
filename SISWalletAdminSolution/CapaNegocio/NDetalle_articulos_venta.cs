namespace CapaNegocio
{
    using CapaEntidades;
    using CapaDatos;
    using System.Data;
    using System.Threading.Tasks;


    public class NDetalle_articulos_venta
    {
        public static async Task<(string rpta, int id_detalle)> InsertarDetalle(Detalle_articulos_venta detalle)
        {
            DDetalle_articulos_venta DDetalle_articulos_venta = new DDetalle_articulos_venta();
            return await DDetalle_articulos_venta.InsertarDetalle(detalle);
        }

        public static async Task<(DataTable dtDetalle, string rpta)> BuscarDetalle(string tipo_busqueda, string texto_busqueda)
        {
            DDetalle_articulos_venta DDetalle_articulos_venta = new DDetalle_articulos_venta();
            return await DDetalle_articulos_venta.BuscarDetalle(tipo_busqueda, texto_busqueda);
        }
    }
}
