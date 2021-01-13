namespace CapaNegocio
{
    using CapaDatos;
    using CapaEntidades;
    using System.Data;
    using System.Threading.Tasks;

    public class NProveedores
    {
        public static async Task<(string rpta, int id_proveedor)> InsertarProveedor(Proveedores proveedor)
        {
            DProveedores DProveedores = new DProveedores();
            return await DProveedores.InsertarProveedores(proveedor);
        }

        public static async Task<string> EditarProveedor(int id_proveedor, Proveedores proveedor)
        {
            DProveedores DProveedores = new DProveedores();
            return await DProveedores.EditarProveedores(id_proveedor, proveedor);
        }

        public static async Task<(DataTable dtProveedores, string rpta)> BuscarProveedores(string tipo_busqueda, string texto_busqueda)
        {
            DProveedores DProveedores = new DProveedores();
            return await DProveedores.BuscarProveedores(tipo_busqueda, texto_busqueda);
        }
    }
}
