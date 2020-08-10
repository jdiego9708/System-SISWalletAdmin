namespace CapaNegocio
{
    using CapaDatos;
    using CapaEntidades;
    using System.Data;

    public class NPaises
    {
        public static string InsertarPais(out int id_pais, Paises pais)
        {
            DPaises DPaises = new DPaises();
            return DPaises.InsertarPais(out id_pais, pais);
        }

        public static string EditarPais(int id_pais, Paises pais)
        {
            DPaises DPaises = new DPaises();
            return DPaises.EditarPais(id_pais, pais);
        }

        public static DataTable BuscarPaises(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            DPaises DPaises = new DPaises();
            return DPaises.BuscarPaises(tipo_busqueda, texto_busqueda, out rpta);
        }
    }
}
