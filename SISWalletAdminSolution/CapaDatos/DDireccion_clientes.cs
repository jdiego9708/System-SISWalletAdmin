namespace CapaDatos
{
    using CapaEntidades;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;
    using System.Threading.Tasks;

    public class DDireccion_clientes
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
        public DDireccion_clientes()
        {

        }

        #endregion

        #region METODO INSERTAR
        public string InsertarDireccion(out int id_direccion, Direccion_clientes direccion)
        {
            id_direccion = 0;
            int contador = 0;
            string rpta = "";

            string consulta = "INSERT INTO Direccion_clientes (Id_usuario, Id_zona, Direccion, Estado_direccion) " +
                "VALUES(@Id_usuario, @Id_zona ,@Direccion, @Estado_direccion) " +
                "SET @Id_direccion = SCOPE_IDENTITY() ";

            SqlConnection SqlCon = new SqlConnection();
            SqlCon.InfoMessage += new SqlInfoMessageEventHandler(SqlCon_InfoMessage);
            SqlCon.FireInfoMessageEventOnUserErrors = true;
            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = consulta,
                    CommandType = CommandType.Text
                };

                SqlParameter Id_direccion = new SqlParameter
                {
                    ParameterName = "@Id_direccion",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_direccion);

                SqlParameter Id_usuario = new SqlParameter
                {
                    ParameterName = "@Id_usuario",
                    SqlDbType = SqlDbType.Int,
                    Value = direccion.Id_usuario
                };
                SqlCmd.Parameters.Add(Id_usuario);
                contador += 1;

                SqlParameter Id_zona = new SqlParameter
                {
                    ParameterName = "@Id_zona",
                    SqlDbType = SqlDbType.Int,
                    Value = direccion.Id_zona
                };
                SqlCmd.Parameters.Add(Id_zona);
                contador += 1;

                SqlParameter Direccion = new SqlParameter
                {
                    ParameterName = "@Direccion",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 200,
                    Value = direccion.Direccion.Trim().ToUpper(),
                };
                SqlCmd.Parameters.Add(Direccion);
                contador += 1;

                SqlParameter Estado_direccion = new SqlParameter
                {
                    ParameterName = "@Estado_direccion",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = direccion.Estado_direccion.Trim()
                };
                SqlCmd.Parameters.Add(Estado_direccion);
                contador += 1;
            
                //Ejecutamos nuestro comando
                rpta = SqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "NO SE INGRESÓ";
                if (!rpta.Equals("OK"))
                {
                    if (this.Mensaje_respuesta != null)
                    {
                        rpta = this.Mensaje_respuesta;
                    }
                }
                else
                {
                    id_direccion = Convert.ToInt32(SqlCmd.Parameters["@Id_direccion"].Value);
                }
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

        #region METODO EDITAR
        public string EditarDireccion(int id_direccion, Direccion_clientes direccion)
        {
            int contador = 0;
            string rpta = "";

            string consulta = "UPDATE Direccion_clientes SET " +
                "Id_usuario = @Id_usuario, " +
                "Id_zona = @Id_zona, " +
                "Direccion = @Direccion, " +
                "Estado_direccion = @Estado_direccion " +
                "WHERE Id_direccion = @Id_direccion ";

            SqlConnection SqlCon = new SqlConnection();
            SqlCon.InfoMessage += new SqlInfoMessageEventHandler(SqlCon_InfoMessage);
            SqlCon.FireInfoMessageEventOnUserErrors = true;
            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = consulta,
                    CommandType = CommandType.Text
                };

                SqlParameter Id_direccion = new SqlParameter
                {
                    ParameterName = "@Id_direccion",
                    SqlDbType = SqlDbType.Int,
                    Value = id_direccion,
                };
                SqlCmd.Parameters.Add(Id_direccion);

                SqlParameter Id_usuario = new SqlParameter
                {
                    ParameterName = "@Id_usuario",
                    SqlDbType = SqlDbType.Int,
                    Value = direccion.Id_usuario
                };
                SqlCmd.Parameters.Add(Id_usuario);
                contador += 1;

                SqlParameter Id_zona = new SqlParameter
                {
                    ParameterName = "@Id_zona",
                    SqlDbType = SqlDbType.Int,
                    Value = direccion.Id_zona
                };
                SqlCmd.Parameters.Add(Id_zona);
                contador += 1;

                SqlParameter Direccion = new SqlParameter
                {
                    ParameterName = "@Direccion",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 200,
                    Value = direccion.Direccion.Trim().ToUpper(),
                };
                SqlCmd.Parameters.Add(Direccion);
                contador += 1;

                SqlParameter Estado_direccion = new SqlParameter
                {
                    ParameterName = "@Estado_direccion",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = direccion.Estado_direccion.Trim()
                };
                SqlCmd.Parameters.Add(Estado_direccion);
                contador += 1;

                //Ejecutamos nuestro comando
                rpta = SqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "NO SE INGRESÓ";
                if (!rpta.Equals("OK"))
                {
                    if (this.Mensaje_respuesta != null)
                    {
                        rpta = this.Mensaje_respuesta;
                    }
                }
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

        #region METODO BUSCAR DIRECCIONES
        public async Task<(string rpta, DataTable dt)>BuscarDirecciones(string tipo_busqueda, string texto_busqueda)
        {
            string rpta = "OK";

            StringBuilder consulta = new StringBuilder();

            consulta.Append("SELECT * FROM Direccion_clientes dcl " +
                "INNER JOIN Usuarios us ON dcl.Id_usuario = us.Id_usuario ");

            if (tipo_busqueda.Equals("ID USUARIO"))
            {
                consulta.Append("WHERE us.Id_usuario = " + texto_busqueda + " ");
            }
            else if (tipo_busqueda.Equals("IDENTIFICACION CLIENTE"))
            {
                consulta.Append("WHERE us.Identificacion = '" + texto_busqueda + "' ");
            }

            consulta.Append("ORDER BY dcl.Id_direccion DESC");

            DataTable DtResultado = new DataTable("Direcciones");
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
                SqlData.Fill(DtResultado);

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
            return (rpta, DtResultado);
        }
        #endregion
    }
}
