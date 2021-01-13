namespace CapaDatos
{
    using CapaDatos;
    using CapaEntidades;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;
    using System.Threading.Tasks;

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

            consulta.Append("SELECT * " +
                "FROM Credenciales cr " +
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

        public async Task<(string rpta, List<object> objects)> Login(string usuario, string pass, string fecha)
        {
            string rpta = "OK";

            List<object> objects = new List<object>();
            DataTable dtArticulos = new DataTable();
            Credenciales credencial = new Credenciales();

            DataSet ds = new DataSet("Login");
            SqlConnection SqlCon = new SqlConnection();
            SqlCon.InfoMessage += new SqlInfoMessageEventHandler(SqlCon_InfoMessage);
            SqlCon.FireInfoMessageEventOnUserErrors = true;
            try
            {
                StringBuilder consulta = new StringBuilder();
                SqlCommand Sqlcmd;
                SqlCon.ConnectionString = DConexion.Cn;
                await SqlCon.OpenAsync();
                Sqlcmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = "sp_Login",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter Usuario = new SqlParameter
                {
                    ParameterName = "@Usuario",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = usuario.Trim()
                };
                Sqlcmd.Parameters.Add(Usuario);

                SqlParameter Pass = new SqlParameter
                {
                    ParameterName = "@Pass",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = pass.Trim()
                };
                Sqlcmd.Parameters.Add(Pass);

                SqlParameter Fecha = new SqlParameter
                {
                    ParameterName = "@Fecha",
                    SqlDbType = SqlDbType.Date,
                    Value = fecha.Trim()
                };
                Sqlcmd.Parameters.Add(Fecha);

                SqlDataAdapter SqlData = new SqlDataAdapter(Sqlcmd);
                SqlData.Fill(ds);

                bool result = false;
                string tipo_usuario = "";
                //1->Primer tabla es la respuesta
                DataTable dtRespuesta = ds.Tables[0];
                if (dtRespuesta.Rows.Count > 0)
                {
                    //Comprobar respuesta
                    string respuestaSQL = Convert.ToString(dtRespuesta.Rows[0]["Respuesta"]);
                    if (respuestaSQL.Equals("OK"))
                    {
                        tipo_usuario = Convert.ToString(dtRespuesta.Rows[0]["Tipo_usuario"]);
                        result = true;
                    }
                    else
                        throw new Exception(respuestaSQL);
                }
                else
                    throw new Exception("No se encontró la respuesta del procedimiento");

                if (result)
                {
                    if (tipo_usuario.Equals("ADMINISTRADOR"))
                    {
                        DataTable dtCredencial = ds.Tables[1];

                        //Obtener la credencial
                        if (dtCredencial.Rows.Count > 0)
                            credencial = new Credenciales(dtCredencial.Rows[0]);

                        DataTable dtSolicitudes = ds.Tables[2];

                        DataTable dtCobros = ds.Tables[3];

                        objects.Add(credencial);
                        objects.Add(dtSolicitudes);
                        objects.Add(dtCobros);
                    }
                    else if (tipo_usuario.Equals("TRABAJADOR CARTERAS"))
                    {
                        DataTable dtCredencial = ds.Tables[1];

                        //Obtener la credencial
                        if (dtCredencial.Rows.Count > 0)
                            credencial = new Credenciales(dtCredencial.Rows[0]);

                        dtArticulos = ds.Tables[2];

                        objects.Add(credencial);
                        objects.Add(dtArticulos);
                    }
                }
                else
                {
                    throw new Exception("No se pudo iniciar sesión");
                }
            }
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
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }

            return (rpta, objects);
        }
        #endregion
    }
}
