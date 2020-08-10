namespace CapaEntidades
{
    using System;
    using System.Data;

    public class Direccion_clientes
    {
        public Direccion_clientes()
        {

        }

        public Direccion_clientes(DataRow row)
        {
            try
            {
                this.Id_direccion = Convert.ToInt32(row["Id_direccion"]);
                this.Id_usuario = Convert.ToInt32(row["Id_usuario"]);
                this.Usuario = new Usuarios(row);
                this.Direccion = Convert.ToString(row["Direccion"]);
                this.Estado_dirección = Convert.ToString(row["Estado_dirección"]);
            }
            catch (Exception)
            {

            }
        }

        public int Id_direccion { get; set; }

        public int Id_usuario { get; set; }
        public virtual Usuarios Usuario { get; set; }
        public string Direccion { get; set; }
        public string Estado_dirección { get; set; } = "ACTIVO";
    }
}
