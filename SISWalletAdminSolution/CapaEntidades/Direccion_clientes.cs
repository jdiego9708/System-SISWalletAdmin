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
                this.Id_zona = Convert.ToInt32(row["Id_zona"]);
                this.Zona = new Zonas(row);
                this.Direccion = Convert.ToString(row["Direccion"]);
                this.Estado_direccion = Convert.ToString(row["Estado_direccion"]);
            }
            catch (Exception ex)
            {

            }
        }

        public int Id_direccion { get; set; }

        public int Id_usuario { get; set; }
        public virtual Usuarios Usuario { get; set; }
        public int Id_zona { get; set; }
        public virtual Zonas Zona { get; set; }
        public string Direccion { get; set; }
        public string Estado_direccion { get; set; } = "ACTIVO";
    }
}
