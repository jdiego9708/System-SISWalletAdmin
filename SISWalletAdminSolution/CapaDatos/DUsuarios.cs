namespace CapaDatos
{
    using CapaEntidades;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;
    using System.Threading.Tasks;

    public class DUsuarios
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
        public DUsuarios()
        {

        }

        #endregion

        #region METODO INSERTAR
        public string InsertarUsuario(out int id_usuario, Usuarios usuario)
        {
            id_usuario = 0;
            int contador = 0;
            string rpta = "";

            string consulta = "INSERT INTO Usuarios (Fecha_ingreso, Alias, Nombres, Apellidos, Identificacion, " +
                "Celular, Email, Tipo_usuario, Estado_usuario) " +
                "VALUES(@Fecha_ingreso, @Alias, @Nombres, @Apellidos, @Identificacion, " +
                "@Celular, @Email, @Tipo_usuario, @Estado_usuario) " +
                "SET @Id_usuario = SCOPE_IDENTITY() ";

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

                SqlParameter Id_usuario = new SqlParameter
                {
                    ParameterName = "@Id_usuario",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_usuario);

                SqlParameter Fecha_ingreso = new SqlParameter
                {
                    ParameterName = "@Fecha_ingreso",
                    SqlDbType = SqlDbType.Date,
                    Value = usuario.Fecha_ingreso,
                };
                SqlCmd.Parameters.Add(Fecha_ingreso);
                contador += 1;

                SqlParameter Alias = new SqlParameter
                {
                    ParameterName = "@Alias",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = usuario.Alias.Trim().ToUpper(),
                };
                SqlCmd.Parameters.Add(Alias);
                contador += 1;

                SqlParameter Nombres = new SqlParameter
                {
                    ParameterName = "@Nombres",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = usuario.Nombres.Trim().ToUpper(),
                };
                SqlCmd.Parameters.Add(Nombres);
                contador += 1;

                SqlParameter Apellidos = new SqlParameter
                {
                    ParameterName = "@Apellidos",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = usuario.Apellidos.Trim().ToUpper(),
                };
                SqlCmd.Parameters.Add(Apellidos);
                contador += 1;

                SqlParameter Identificacion = new SqlParameter
                {
                    ParameterName = "@Identificacion",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = usuario.Identificacion.Trim()
                };
                SqlCmd.Parameters.Add(Identificacion);
                contador += 1;

                SqlParameter Celular = new SqlParameter
                {
                    ParameterName = "@Celular",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = usuario.Celular.Trim().ToUpper(),
                };
                SqlCmd.Parameters.Add(Celular);
                contador += 1;

                SqlParameter Email = new SqlParameter
                {
                    ParameterName = "@Email",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = usuario.Email.Trim()
                };
                SqlCmd.Parameters.Add(Email);
                contador += 1;

                SqlParameter Tipo_usuario = new SqlParameter
                {
                    ParameterName = "@Tipo_usuario",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = usuario.Tipo_usuario.Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Tipo_usuario);
                contador += 1;

                SqlParameter Estado_usuario = new SqlParameter
                {
                    ParameterName = "@Estado_usuario",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = usuario.Estado_usuario.Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Estado_usuario);
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
                    id_usuario = Convert.ToInt32(SqlCmd.Parameters["@Id_usuario"].Value);
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
        public string EditarUsuario(int id_usuario, Usuarios usuario)
        {
            int contador = 0;
            string rpta = "";

            string consulta = "UPDATE Usuarios SET " +
                "Fecha_ingreso = @Fecha_ingreso, " +
                "Alias = @Alias, " +
                "Nombres = @Nombres, " +
                "Apellidos = @Apellidos, " +
                "Identificacion = @Identificacion, " +
                "Celular = @Celular, " +
                "Email = @Email, " +
                "Tipo_usuario = @Tipo_usuario, " +
                "Estado_usuario = @Estado_usuario " +
                "WHERE Id_usuario = @Id_usuario ";

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

                SqlParameter Id_usuario = new SqlParameter
                {
                    ParameterName = "@Id_usuario",
                    SqlDbType = SqlDbType.Int,
                    Value = id_usuario,
                };
                SqlCmd.Parameters.Add(Id_usuario);

                SqlParameter Fecha_ingreso = new SqlParameter
                {
                    ParameterName = "@Fecha_ingreso",
                    SqlDbType = SqlDbType.Date,
                    Value = usuario.Fecha_ingreso,
                };
                SqlCmd.Parameters.Add(Fecha_ingreso);
                contador += 1;

                SqlParameter Alias = new SqlParameter
                {
                    ParameterName = "@Alias",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = usuario.Alias.Trim().ToUpper(),
                };
                SqlCmd.Parameters.Add(Alias);
                contador += 1;

                SqlParameter Nombres = new SqlParameter
                {
                    ParameterName = "@Nombres",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = usuario.Nombres.Trim().ToUpper(),
                };
                SqlCmd.Parameters.Add(Nombres);
                contador += 1;

                SqlParameter Apellidos = new SqlParameter
                {
                    ParameterName = "@Apellidos",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = usuario.Apellidos.Trim().ToUpper(),
                };
                SqlCmd.Parameters.Add(Apellidos);
                contador += 1;

                SqlParameter Identificacion = new SqlParameter
                {
                    ParameterName = "@Identificacion",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = usuario.Identificacion.Trim()
                };
                SqlCmd.Parameters.Add(Identificacion);
                contador += 1;

                SqlParameter Celular = new SqlParameter
                {
                    ParameterName = "@Celular",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = usuario.Celular.Trim().ToUpper(),
                };
                SqlCmd.Parameters.Add(Celular);
                contador += 1;

                SqlParameter Email = new SqlParameter
                {
                    ParameterName = "@Email",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = usuario.Email.Trim()
                };
                SqlCmd.Parameters.Add(Email);
                contador += 1;

                SqlParameter Tipo_usuario = new SqlParameter
                {
                    ParameterName = "@Tipo_usuario",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = usuario.Tipo_usuario.Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Tipo_usuario);
                contador += 1;

                SqlParameter Estado_usuario = new SqlParameter
                {
                    ParameterName = "@Estado_usuario",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = usuario.Estado_usuario.Trim().ToUpper()
                };
                SqlCmd.Parameters.Add(Estado_usuario);
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

        #region METODO BUSCAR USUARIOS
        public async Task<(DataTable dtUsuarios, string rpta)> BuscarUsuarios(string tipo_busqueda, string texto_busqueda)
        {
            string rpta = "OK";

            StringBuilder consulta = new StringBuilder();

            consulta.Append("SELECT us.Id_usuario, us.Fecha_ingreso, us.Alias, us.Nombres, us.Apellidos, " +
                "us.Identificacion, us.Celular, us.Email, us.Tipo_usuario, us.Estado_usuario, " +
                "(us.Nombres + ' ' + us.Apellidos) as Nombre_completo " +
                "FROM Usuarios us ");

            if (tipo_busqueda.Equals("ID USUARIO"))
            {
                consulta.Append("WHERE us.Id_usuario = @Texto_busqueda ");
            }
            else if (tipo_busqueda.Equals("TIPO USUARIO"))
            {
                if (texto_busqueda.Equals("CARTERAS"))
                    consulta.Append("WHERE us.Tipo_usuario = 'TRABAJADOR CARTERAS' or " +
                        "us.Tipo_usuario = 'ADMINISTRADOR' ");
                else
                    consulta.Append("WHERE us.Tipo_usuario = @Texto_busqueda ");
            }

            consulta.Append("ORDER BY us.Id_usuario DESC");

            DataTable DtResultado = new DataTable("Usuarios");
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

        public async Task<(DataTable dtClientes, string rpta)> BuscarClientes(string tipo_busqueda, string texto_busqueda1,
            string texto_busqueda2)
        {
            string rpta = "OK";
            DataTable DtResultado = new DataTable("Clientes");
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
                    CommandText = "sp_Buscar_clientes",
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter Tipo_busqueda = new SqlParameter
                {
                    ParameterName = "@Tipo_busqueda",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = tipo_busqueda.Trim()
                };
                Sqlcmd.Parameters.Add(Tipo_busqueda);

                SqlParameter Texto_busqueda1 = new SqlParameter
                {
                    ParameterName = "@Texto_busqueda1",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = texto_busqueda1.Trim()
                };
                Sqlcmd.Parameters.Add(Texto_busqueda1);

                SqlParameter Texto_busqueda2 = new SqlParameter
                {
                    ParameterName = "@Texto_busqueda2",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = texto_busqueda2.Trim()
                };
                Sqlcmd.Parameters.Add(Texto_busqueda2);

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

        #region METODO INACTIVAR CLIENTE
        public async Task<string> InactivarUsuario(int id_usuario)
        {
            string rpta = "";

            SqlConnection SqlCon = new SqlConnection();
            SqlCon.InfoMessage += new SqlInfoMessageEventHandler(SqlCon_InfoMessage);
            SqlCon.FireInfoMessageEventOnUserErrors = true;
            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                await SqlCon.OpenAsync();
                SqlCommand SqlCmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = "sp_Inactivar_cliente",
                    CommandType = CommandType.StoredProcedure,
                };

                SqlParameter Id_usuario = new SqlParameter
                {
                    ParameterName = "@Id_usuario",
                    SqlDbType = SqlDbType.Int,
                    Value = id_usuario,
                };
                SqlCmd.Parameters.Add(Id_usuario);
             
                //Ejecutamos nuestro comando
                rpta = await SqlCmd.ExecuteNonQueryAsync() >= 1 ? "OK" : "NO SE INGRESÓ";
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
    }
}
