namespace CapaDatos
{
    using CapaEntidades;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;
    using System.Threading.Tasks;

    public class DProveedores
    {
        #region MENSAJE
        private void SqlCon_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            this.Mensaje_respuesta = e.Message;
        }
        #endregion

        #region VARIABLES

        string _mensaje_respuesta;

        public string Mensaje_respuesta
        {
            get
            {
                return _mensaje_respuesta;
            }

            set
            {
                _mensaje_respuesta = value;
            }
        }


        #endregion

        #region CONSTRUCTOR
        public DProveedores()
        {

        }

        #endregion

        #region METODO INSERTAR
        public async Task<(string rpta, int id_proveedor)> InsertarProveedores(Proveedores proveedor)
        {
            int id_proveedor = 0;
            int contador = 0;
            string rpta = "";

            string consulta = "INSERT INTO Proveedores (Fecha_ingreso, Nombre_proveedor, Descripcion_proveedor, " +
                "Contacto_proveedor, Estado_proveedor) " +
                "VALUES(@Fecha_ingreso, @Nombre_proveedor, @Descripcion_proveedor, " +
                "@Contacto_proveedor, @Estado_proveedor) " +
                "SET @Id_proveedor = SCOPE_IDENTITY() ";

            SqlConnection SqlCon = new SqlConnection();
            SqlCon.InfoMessage += new SqlInfoMessageEventHandler(SqlCon_InfoMessage);
            SqlCon.FireInfoMessageEventOnUserErrors = true;
            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                await SqlCon.OpenAsync();
                SqlTransaction tran = SqlCon.BeginTransaction();
                SqlCommand SqlCmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = consulta,
                    CommandType = CommandType.Text,
                    Transaction = tran,
                };

                SqlParameter Id_proveedor = new SqlParameter
                {
                    ParameterName = "@Id_proveedor",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_proveedor);

                SqlParameter Fecha_ingreso = new SqlParameter
                {
                    ParameterName = "@Fecha_ingreso",
                    SqlDbType = SqlDbType.Date,
                    Value = proveedor.Fecha_ingreso,
                };
                SqlCmd.Parameters.Add(Fecha_ingreso);
                contador += 1;
               
                SqlParameter Nombre_proveedor = new SqlParameter
                {
                    ParameterName = "@Nombre_proveedor",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = proveedor.Nombre_proveedor.Trim()
                };
                SqlCmd.Parameters.Add(Nombre_proveedor);
                contador += 1;

                SqlParameter Descripcion_proveedor = new SqlParameter
                {
                    ParameterName = "@Descripcion_proveedor",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 500,
                    Value = proveedor.Descripcion_proveedor.Trim()
                };
                SqlCmd.Parameters.Add(Descripcion_proveedor);
                contador += 1;

                SqlParameter Contacto_proveedor = new SqlParameter
                {
                    ParameterName = "@Contacto_proveedor",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = proveedor.Contacto_proveedor.Trim()
                };
                SqlCmd.Parameters.Add(Contacto_proveedor);
                contador += 1;

                SqlParameter Estado_proveedor = new SqlParameter
                {
                    ParameterName = "@Estado_proveedor",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = proveedor.Estado_proveedor.Trim()
                };
                SqlCmd.Parameters.Add(Estado_proveedor);
                contador += 1;
               
                //Ejecutamos nuestro comando
                rpta = await SqlCmd.ExecuteNonQueryAsync() >= 1 ? "OK" : "NO SE INGRESÓ";
                if (!rpta.Equals("OK"))
                {
                    tran.Rollback();
                    if (this.Mensaje_respuesta != null)
                    {
                        rpta = this.Mensaje_respuesta;
                    }
                }
                else
                {
                    tran.Commit();
                    id_proveedor = Convert.ToInt32(SqlCmd.Parameters["@Id_proveedor"].Value);
                }
                tran.Dispose();
            }
            //Mostramos posible error que tengamos
            catch (SqlException ex)
            {
                rpta = ex.Message;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                //Si la cadena SqlCon esta abierta la cerramos
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }
            return (rpta, id_proveedor);
        }
        #endregion

        #region METODO EDITAR
        public async Task<string> EditarProveedores(int id_proveedor, Proveedores proveedor)
        {
            int contador = 0;
            string rpta = "";

            string consulta = "UPDATE Proveedores SET " +
                "Fecha_ingreso = @Fecha_ingreso, " +
                "Nombre_proveedor = @Nombre_proveedor, " +
                "Descripcion_proveedor = @Descripcion_proveedor, " +
                "Contacto_proveedor = @Contacto_proveedor, " +
                "Estado_proveedor = @Estado_proveedor " +
                "WHERE Id_proveedor = @Id_proveedor ";

            SqlConnection SqlCon = new SqlConnection();
            SqlCon.InfoMessage += new SqlInfoMessageEventHandler(SqlCon_InfoMessage);
            SqlCon.FireInfoMessageEventOnUserErrors = true;
            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                await SqlCon.OpenAsync();
                SqlTransaction tran = SqlCon.BeginTransaction();
                SqlCommand SqlCmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = consulta,
                    CommandType = CommandType.Text,
                    Transaction = tran,
                };

                SqlParameter Id_proveedor = new SqlParameter
                {
                    ParameterName = "@Id_proveedor",
                    SqlDbType = SqlDbType.Int,
                    Value = id_proveedor,
                };
                SqlCmd.Parameters.Add(Id_proveedor);

                SqlParameter Fecha_ingreso = new SqlParameter
                {
                    ParameterName = "@Fecha_ingreso",
                    SqlDbType = SqlDbType.Date,
                    Value = proveedor.Fecha_ingreso,
                };
                SqlCmd.Parameters.Add(Fecha_ingreso);
                contador += 1;

                SqlParameter Nombre_proveedor = new SqlParameter
                {
                    ParameterName = "@Nombre_proveedor",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = proveedor.Nombre_proveedor.Trim()
                };
                SqlCmd.Parameters.Add(Nombre_proveedor);
                contador += 1;

                SqlParameter Descripcion_proveedor = new SqlParameter
                {
                    ParameterName = "@Descripcion_proveedor",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 500,
                    Value = proveedor.Descripcion_proveedor.Trim()
                };
                SqlCmd.Parameters.Add(Descripcion_proveedor);
                contador += 1;

                SqlParameter Contacto_proveedor = new SqlParameter
                {
                    ParameterName = "@Contacto_proveedor",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = proveedor.Contacto_proveedor.Trim()
                };
                SqlCmd.Parameters.Add(Descripcion_proveedor);
                contador += 1;

                SqlParameter Estado_proveedor = new SqlParameter
                {
                    ParameterName = "@Estado_proveedor",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = proveedor.Estado_proveedor.Trim()
                };
                SqlCmd.Parameters.Add(Estado_proveedor);
                contador += 1;

                //Ejecutamos nuestro comando
                rpta = await SqlCmd.ExecuteNonQueryAsync() >= 1 ? "OK" : "NO SE INGRESÓ";
                if (!rpta.Equals("OK"))
                {
                    tran.Rollback();
                    if (this.Mensaje_respuesta != null)
                    {
                        rpta = this.Mensaje_respuesta;
                    }
                }
                else
                {
                    tran.Commit();
                }
                tran.Dispose();
            }
            //Mostramos posible error que tengamos
            catch (SqlException ex)
            {
                rpta = ex.Message;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                //Si la cadena SqlCon esta abierta la cerramos
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }
            return rpta;
        }
        #endregion

        #region METODO BUSCAR PROVEEDORES
        public async Task<(DataTable dtProveedores, string rpta)> BuscarProveedores(string tipo_busqueda, string texto_busqueda)
        {
            string rpta = "OK";

            StringBuilder consulta = new StringBuilder();

            consulta.Append("SELECT * FROM Proveedores pro ");

            if (tipo_busqueda.Equals("ID PROVEEDOR"))
            {
                consulta.Append("WHERE pro.Id_proveedor = @Texto_busqueda ");
            }
            else if (tipo_busqueda.Equals("ESTADO"))
            {
                consulta.Append("WHERE pro.Estado_proveedor = '@Texto_busqueda' ");
            }

            consulta.Append("ORDER BY pro.Id_proveedor DESC");

            DataTable DtResultado = new DataTable("Proveedores");
            SqlConnection SqlCon = new SqlConnection();
            SqlCon.InfoMessage += new SqlInfoMessageEventHandler(SqlCon_InfoMessage);
            SqlCon.FireInfoMessageEventOnUserErrors = true;
            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                await SqlCon.OpenAsync();
                SqlCommand Sqlcmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = consulta.ToString(),
                    CommandType = CommandType.Text
                };

                SqlParameter Texto_busqueda = new SqlParameter
                {
                    ParameterName = "@Texto_busqueda",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = texto_busqueda.Trim()
                };
                Sqlcmd.Parameters.Add(Texto_busqueda);

                SqlDataAdapter SqlData = new SqlDataAdapter(Sqlcmd);
                await Task.Run(() => SqlData.Fill(DtResultado));

                if (DtResultado.Rows.Count < 1)
                {
                    DtResultado = null;
                }
            }
            catch (SqlException ex)
            {
                rpta = ex.Message;
                DtResultado = null;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
                DtResultado = null;
            }
            return (DtResultado, rpta);
        }
        #endregion
    }
}
