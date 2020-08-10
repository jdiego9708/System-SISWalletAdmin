namespace CapaDatos
{
    using CapaEntidades;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;

    public class DCredenciales
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
        public DCredenciales()
        {

        }

        #endregion

        #region METODO INSERTAR
        public string InsertarCredencial(out int id_credencial, Credenciales credencial)
        {
            id_credencial = 0;
            int contador = 0;
            string rpta = "";

            string consulta = "INSERT INTO Credenciales (Id_usuario, Fecha_credencial, Hora_credencial, " +
                "Password, Estado_credencial) " +
                "VALUES(@Id_usuario, @Fecha_credencial, @Hora_credencial, " +
                "@Password, @Estado_credencial) " +
                "SET @Id_credencial = SCOPE_IDENTITY() ";

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

                SqlParameter Id_credencial = new SqlParameter
                {
                    ParameterName = "@Id_credencial",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_credencial);

                SqlParameter Id_usuario = new SqlParameter
                {
                    ParameterName = "@Id_usuario",
                    SqlDbType = SqlDbType.Int,
                    Value = credencial.Id_usuario
                };
                SqlCmd.Parameters.Add(Id_usuario);
                contador += 1;

                SqlParameter Fecha_credencial = new SqlParameter
                {
                    ParameterName = "@Fecha_credencial",
                    SqlDbType = SqlDbType.Date,
                    Value = credencial.Fecha_credencial,
                };
                SqlCmd.Parameters.Add(Fecha_credencial);
                contador += 1;

                SqlParameter Hora_credencial = new SqlParameter
                {
                    ParameterName = "@Hora_credencial",
                    SqlDbType = SqlDbType.Time,
                    Value = credencial.Hora_credencial,
                };
                SqlCmd.Parameters.Add(Hora_credencial);
                contador += 1;
             
                SqlParameter Password = new SqlParameter
                {
                    ParameterName = "@Password",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 20,
                    Value = credencial.Password.Trim()
                };
                SqlCmd.Parameters.Add(Password);
                contador += 1;

                SqlParameter Estado_credencial = new SqlParameter
                {
                    ParameterName = "@Estado_credencial",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = credencial.Estado_credencial.Trim()
                };
                SqlCmd.Parameters.Add(Estado_credencial);
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
                    id_credencial = Convert.ToInt32(SqlCmd.Parameters["@Id_credencial"].Value);
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
        public string EditarCredencial(int id_credencial, Credenciales credencial)
        {
            int contador = 0;
            string rpta = "";

            string consulta = "UPDATE Credenciales SET" +
                "Id_usuario = @Id_usuario, " +
                "Fecha_credencial = @Fecha_credencial, " +
                "Hora_credencial = @Hora_credencial, " +
                "Password = @Password, " +
                "Estado_credencial = @Estado_credencial " +
                "WHERE Id_credencial = @Id_credencial ";

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

                SqlParameter Id_credencial = new SqlParameter
                {
                    ParameterName = "@Id_credencial",
                    SqlDbType = SqlDbType.Int,
                    Value = id_credencial,
                };
                SqlCmd.Parameters.Add(Id_credencial);

                SqlParameter Id_usuario = new SqlParameter
                {
                    ParameterName = "@Id_usuario",
                    SqlDbType = SqlDbType.Int,
                    Value = credencial.Id_usuario
                };
                SqlCmd.Parameters.Add(Id_usuario);
                contador += 1;

                SqlParameter Fecha_credencial = new SqlParameter
                {
                    ParameterName = "@Fecha_credencial",
                    SqlDbType = SqlDbType.Date,
                    Value = credencial.Fecha_credencial,
                };
                SqlCmd.Parameters.Add(Fecha_credencial);
                contador += 1;

                SqlParameter Hora_credencial = new SqlParameter
                {
                    ParameterName = "@Hora_credencial",
                    SqlDbType = SqlDbType.Time,
                    Value = credencial.Hora_credencial,
                };
                SqlCmd.Parameters.Add(Hora_credencial);
                contador += 1;

                SqlParameter Password = new SqlParameter
                {
                    ParameterName = "@Password",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 20,
                    Value = credencial.Password.Trim()
                };
                SqlCmd.Parameters.Add(Password);
                contador += 1;

                SqlParameter Estado_credencial = new SqlParameter
                {
                    ParameterName = "@Estado_credencial",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = credencial.Estado_credencial.Trim()
                };
                SqlCmd.Parameters.Add(Estado_credencial);
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
      
        #region METODO BUSCAR CREDENCIALES
        public DataTable BuscarCredenciales(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            rpta = "OK";

            StringBuilder consulta = new StringBuilder();

            consulta.Append("SELECT * FROM Credenciales cr " +
                "INNER JOIN Usuarios us ON cr.Id_usuario = us.Id_usuario ");

            if (tipo_busqueda.Equals("ID USUARIO"))
            {
                consulta.Append("WHERE cr.Id_usuario = @Texto_busqueda ");
            }
            else if (tipo_busqueda.Equals("CELULAR"))
            {
                consulta.Append("WHERE us.Celular = @Texto_busqueda ");
            }

            consulta.Append("ORDER BY cr.Id_credencial DESC");

            DataTable DtResultado = new DataTable("Credenciales");
            SqlConnection SqlCon = new SqlConnection();
            SqlCon.InfoMessage += new SqlInfoMessageEventHandler(SqlCon_InfoMessage);
            SqlCon.FireInfoMessageEventOnUserErrors = true;
            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
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
            return DtResultado;
        }
        #endregion
    }
}
