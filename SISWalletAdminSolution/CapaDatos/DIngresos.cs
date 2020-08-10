namespace CapaDatos
{
    using CapaEntidades;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;

    public class DIngresos
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
        public DIngresos()
        {

        }

        #endregion

        #region METODO INSERTAR
        public string InsertarIngresos(out int id_ingreso, Ingresos ingreso)
        {
            id_ingreso = 0;
            int contador = 0;
            string rpta = "";

            string consulta = "INSERT INTO Ingresos (Id_usuario, Id_turno, Fecha_ingreso, Hora_ingreso, " +
                "Valor_ingreso, Observaciones_ingreso, Estado_ingreso) " +
                "VALUES(@Id_usuario, @Id_turno, @Fecha_ingreso, @Hora_ingreso, " +
                "@Valor_ingreso, @Observaciones_ingreso, @Estado_ingreso) " +
                "SET @Id_ingreso = SCOPE_IDENTITY() ";

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

                SqlParameter Id_ingreso = new SqlParameter
                {
                    ParameterName = "@Id_ingreso",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_ingreso);


                SqlParameter Id_usuario = new SqlParameter
                {
                    ParameterName = "@Id_usuario",
                    SqlDbType = SqlDbType.Int,
                    Value = ingreso.Id_usuario
                };
                SqlCmd.Parameters.Add(Id_usuario);
                contador += 1;

                SqlParameter Id_turno = new SqlParameter
                {
                    ParameterName = "@Id_turno",
                    SqlDbType = SqlDbType.Int,
                    Value = ingreso.Id_turno
                };
                SqlCmd.Parameters.Add(Id_turno);
                contador += 1;

                SqlParameter Fecha_ingreso = new SqlParameter
                {
                    ParameterName = "@Fecha_ingreso",
                    SqlDbType = SqlDbType.Date,
                    Value = ingreso.Fecha_ingreso,
                };
                SqlCmd.Parameters.Add(Fecha_ingreso);
                contador += 1;

                SqlParameter Hora_ingreso = new SqlParameter
                {
                    ParameterName = "@Hora_ingreso",
                    SqlDbType = SqlDbType.Time,
                    Size = 2,
                    Value = ingreso.Hora_ingreso,
                };
                SqlCmd.Parameters.Add(Hora_ingreso);
                contador += 1;

                SqlParameter Valor_ingreso = new SqlParameter
                {
                    ParameterName = "@Valor_ingreso",
                    SqlDbType = SqlDbType.Decimal,
                    Value = ingreso.Valor_ingreso,
                };
                SqlCmd.Parameters.Add(Valor_ingreso);
                contador += 1;
               
                SqlParameter Observaciones_ingreso = new SqlParameter
                {
                    ParameterName = "@Observaciones_ingreso",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = ingreso.Observaciones_ingreso.Trim()
                };
                SqlCmd.Parameters.Add(Observaciones_ingreso);
                contador += 1;

                SqlParameter Estado_ingreso = new SqlParameter
                {
                    ParameterName = "@Estado_ingreso",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = ingreso.Estado_ingreso.Trim()
                };
                SqlCmd.Parameters.Add(Estado_ingreso);
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
                    id_ingreso = Convert.ToInt32(SqlCmd.Parameters["@Id_ingreso"].Value);
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
        public string EditarIngresos(int id_ingreso, Ingresos ingreso)
        {
            int contador = 0;
            string rpta = "";

            string consulta = "UPDATE Ingresos SET " +
                "Id_usuario = @Id_usuario, " +
                "Id_turno = @Id_turno, " +
                "Fecha_ingreso = @Fecha_ingreso, " +
                "Hora_ingreso = @Hora_ingreso, " +
                "Valor_ingreso = @Valor_ingreso, " +
                "Observaciones_ingreso = @Observaciones_ingreso, " +
                "Estado_ingreso = @Estado_ingreso " +
                "WHERE Id_ingreso = @Id_ingreso ";

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

                SqlParameter Id_ingreso = new SqlParameter
                {
                    ParameterName = "@Id_ingreso",
                    SqlDbType = SqlDbType.Int,
                    Value = id_ingreso,
                };
                SqlCmd.Parameters.Add(Id_ingreso);


                SqlParameter Id_usuario = new SqlParameter
                {
                    ParameterName = "@Id_usuario",
                    SqlDbType = SqlDbType.Int,
                    Value = ingreso.Id_usuario
                };
                SqlCmd.Parameters.Add(Id_usuario);
                contador += 1;

                SqlParameter Id_turno = new SqlParameter
                {
                    ParameterName = "@Id_turno",
                    SqlDbType = SqlDbType.Int,
                    Value = ingreso.Id_turno
                };
                SqlCmd.Parameters.Add(Id_turno);
                contador += 1;

                SqlParameter Fecha_ingreso = new SqlParameter
                {
                    ParameterName = "@Fecha_ingreso",
                    SqlDbType = SqlDbType.Date,
                    Value = ingreso.Fecha_ingreso,
                };
                SqlCmd.Parameters.Add(Fecha_ingreso);
                contador += 1;

                SqlParameter Hora_ingreso = new SqlParameter
                {
                    ParameterName = "@Hora_ingreso",
                    SqlDbType = SqlDbType.Time,
                    Size = 2,
                    Value = ingreso.Hora_ingreso,
                };
                SqlCmd.Parameters.Add(Hora_ingreso);
                contador += 1;

                SqlParameter Valor_ingreso = new SqlParameter
                {
                    ParameterName = "@Valor_ingreso",
                    SqlDbType = SqlDbType.Decimal,
                    Value = ingreso.Valor_ingreso,
                };
                SqlCmd.Parameters.Add(Valor_ingreso);
                contador += 1;

                SqlParameter Observaciones_ingreso = new SqlParameter
                {
                    ParameterName = "@Observaciones_ingreso",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = ingreso.Observaciones_ingreso.Trim()
                };
                SqlCmd.Parameters.Add(Observaciones_ingreso);
                contador += 1;

                SqlParameter Estado_ingreso = new SqlParameter
                {
                    ParameterName = "@Estado_ingreso",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = ingreso.Estado_ingreso.Trim()
                };
                SqlCmd.Parameters.Add(Estado_ingreso);
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

        #region METODO BUSCAR INGRESOS
        public DataTable BuscarIngresos(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            rpta = "OK";

            StringBuilder consulta = new StringBuilder();

            consulta.Append("SELECT * FROM Ingresos ing " +
                "INNER JOIN Turnos tu ON ing.Id_turno = tu.Id_turno " +
                "INNER JOIN Usuarios us ON ing.Id_usuario = us.Id_usuario ");

            if (tipo_busqueda.Equals("ID INGRESO"))
            {
                consulta.Append("WHERE ing.Id_ingreso = @Texto_busqueda ");
            }
            else if (tipo_busqueda.Equals("ID USUARIO"))
            {
                consulta.Append("WHERE ing.Id_usuario = @Texto_busqueda ");
            }
            else if (tipo_busqueda.Equals("ID TURNO"))
            {
                consulta.Append("WHERE ing.Id_turno = @Texto_busqueda ");
            }

            consulta.Append("ORDER BY ing.Id_ingreso DESC");

            DataTable DtResultado = new DataTable("Ingresos");
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
