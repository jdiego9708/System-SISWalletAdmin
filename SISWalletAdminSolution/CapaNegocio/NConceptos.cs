namespace CapaNegocio
{
    using CapaEntidades;
    using CapaDatos;
    using System.Threading.Tasks;
    using System.Data;

    public class NConceptos
    {
        public static async Task<(string rpta, int id_concepto)> InsertarConcepto(Conceptos concepto)
        {
            DConceptos DConceptos = new DConceptos();
            return await DConceptos.InsertarConcepto(concepto);
        }

        public static async Task<string> EditarConcepto(int id_concepto, Conceptos concepto)
        {
            DConceptos DConceptos = new DConceptos();
            return await DConceptos.EditarConcepto(id_concepto, concepto);
        }

        public static async Task<(DataTable dtConceptos, string rpta)> BuscarConceptos(string tipo_busqueda, string texto_busqueda)
        {
            DConceptos DConceptos = new DConceptos();
            return await DConceptos.BuscarConceptos(tipo_busqueda, texto_busqueda);
        }
    }
}
