namespace CapaDatos
{
    using CapaEntidades;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;

    public class DGastos
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
        public DGastos()
        {

        }

        #endregion

        #region METODO INSERTAR
        public string InsertarGastos(out int id_gasto, Gastos gasto)
        {
            id_gasto = 0;
            int contador = 0;
            string rpta = "";

            string consulta = "INSERT INTO Gastos (Id_tipo_gasto, Id_usuario, Id_turno, Fecha_gasto, Hora_gasto, " +
                "Valor_gasto, Observaciones_gasto, Estado_gasto) " +
                "VALUES(@Id_tipo_gasto, @Id_usuario, @Id_turno, @Fecha_gasto, @Hora_gasto, " +
                "@Valor_gasto, @Observaciones_gasto, @Estado_gasto) " +
                "SET @Id_gasto = SCOPE_IDENTITY() ";

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

                SqlParameter Id_gasto = new SqlParameter
                {
                    ParameterName = "@Id_gasto",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_gasto);

                SqlParameter Id_tipo_gasto = new SqlParameter
                {
                    ParameterName = "@Id_tipo_gasto",
                    SqlDbType = SqlDbType.Int,
                    Value = gasto.Id_tipo_gasto
                };
                SqlCmd.Parameters.Add(Id_tipo_gasto);
                contador += 1;

                SqlParameter Id_usuario = new SqlParameter
                {
                    ParameterName = "@Id_usuario",
                    SqlDbType = SqlDbType.Int,
                    Value = gasto.Id_usuario
                };
                SqlCmd.Parameters.Add(Id_usuario);
                contador += 1;

                SqlParameter Id_turno = new SqlParameter
                {
                    ParameterName = "@Id_turno",
                    SqlDbType = SqlDbType.Int,
                    Value = gasto.Id_turno
                };
                SqlCmd.Parameters.Add(Id_turno);
                contador += 1;

                SqlParameter Fecha_gasto = new SqlParameter
                {
                    ParameterName = "@Fecha_gasto",
                    SqlDbType = SqlDbType.Date,
                    Value = gasto.Fecha_gasto,
                };
                SqlCmd.Parameters.Add(Fecha_gasto);
                contador += 1;

                SqlParameter Hora_gasto = new SqlParameter
                {
                    ParameterName = "@Hora_gasto",
                    SqlDbType = SqlDbType.Time,
                    Size = 2,
                    Value = gasto.Hora_gasto,
                };
                SqlCmd.Parameters.Add(Hora_gasto);
                contador += 1;

                SqlParameter Valor_gasto = new SqlParameter
                {
                    ParameterName = "@Valor_gasto",
                    SqlDbType = SqlDbType.Decimal,
                    Value = gasto.Valor_gasto,
                };
                SqlCmd.Parameters.Add(Valor_gasto);
                contador += 1;
               
                SqlParameter Observaciones_gasto = new SqlParameter
                {
                    ParameterName = "@Observaciones_gasto",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = gasto.Observaciones_gasto.Trim()
                };
                SqlCmd.Parameters.Add(Observaciones_gasto);
                contador += 1;

                SqlParameter Estado_gasto = new SqlParameter
                {
                    ParameterName = "@Estado_gasto",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = gasto.Estado_gasto.Trim()
                };
                SqlCmd.Parameters.Add(Estado_gasto);
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
                    id_gasto = Convert.ToInt32(SqlCmd.Parameters["@Id_gasto"].Value);
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
        public string EditarGastos(int id_gasto, Gastos gasto)
        {
            int contador = 0;
            string rpta = "";

            string consulta = "UPDATE Gastos SET " +
                "Id_tipo_gasto = @Id_tipo_gasto, " +
                "Id_usuario = @Id_usuario, " +
                "Id_turno = @Id_turno, " +
                "Fecha_gasto = @Fecha_gasto, " +
                "Hora_gasto,  = @Hora_gasto" +
                "Valor_gasto = @Valor_gasto, " +
                "Observaciones_gasto = @Observaciones_gasto, " +
                "Estado_gasto = @Estado_gasto " +
                "WHERE Id_gasto = @Id_gasto ";

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

                SqlParameter Id_gasto = new SqlParameter
                {
                    ParameterName = "@Id_gasto",
                    SqlDbType = SqlDbType.Int,
                    Value = id_gasto
                };
                SqlCmd.Parameters.Add(Id_gasto);

                SqlParameter Id_tipo_gasto = new SqlParameter
                {
                    ParameterName = "@Id_tipo_gasto",
                    SqlDbType = SqlDbType.Int,
                    Value = gasto.Id_tipo_gasto
                };
                SqlCmd.Parameters.Add(Id_tipo_gasto);
                contador += 1;

                SqlParameter Id_usuario = new SqlParameter
                {
                    ParameterName = "@Id_usuario",
                    SqlDbType = SqlDbType.Int,
                    Value = gasto.Id_usuario
                };
                SqlCmd.Parameters.Add(Id_usuario);
                contador += 1;

                SqlParameter Id_turno = new SqlParameter
                {
                    ParameterName = "@Id_turno",
                    SqlDbType = SqlDbType.Int,
                    Value = gasto.Id_turno
                };
                SqlCmd.Parameters.Add(Id_turno);
                contador += 1;

                SqlParameter Fecha_gasto = new SqlParameter
                {
                    ParameterName = "@Fecha_gasto",
                    SqlDbType = SqlDbType.Date,
                    Value = gasto.Fecha_gasto,
                };
                SqlCmd.Parameters.Add(Fecha_gasto);
                contador += 1;

                SqlParameter Hora_gasto = new SqlParameter
                {
                    ParameterName = "@Hora_gasto",
                    SqlDbType = SqlDbType.Time,
                    Size = 2,
                    Value = gasto.Hora_gasto,
                };
                SqlCmd.Parameters.Add(Hora_gasto);
                contador += 1;

                SqlParameter Valor_gasto = new SqlParameter
                {
                    ParameterName = "@Valor_gasto",
                    SqlDbType = SqlDbType.Decimal,
                    Value = gasto.Valor_gasto,
                };
                SqlCmd.Parameters.Add(Valor_gasto);
                contador += 1;

                SqlParameter Observaciones_gasto = new SqlParameter
                {
                    ParameterName = "@Observaciones_gasto",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = gasto.Observaciones_gasto.Trim()
                };
                SqlCmd.Parameters.Add(Observaciones_gasto);
                contador += 1;

                SqlParameter Estado_gasto = new SqlParameter
                {
                    ParameterName = "@Estado_gasto",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = gasto.Estado_gasto.Trim()
                };
                SqlCmd.Parameters.Add(Estado_gasto);
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

        #region METODO BUSCAR GASTOS
        public DataTable BuscarGastos(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            rpta = "OK";

            StringBuilder consulta = new StringBuilder();

            consulta.Append("SELECT * FROM Gastos ga " +
                "INNER JOIN Turnos tu ON ga.Id_turno = tu.Id_turno " +
                "INNER JOIN Tipo_gastos tpga ON ga.Id_tipo_gasto = tpga.Id_tipo_gasto " +
                "INNER JOIN Usuarios us ON ga.Id_usuario = us.Id_usuario ");

            if (tipo_busqueda.Equals("ID GASTO"))
            {
                consulta.Append("WHERE ga.Id_gasto = @Texto_busqueda ");
            }
            else if (tipo_busqueda.Equals("ID USUARIO"))
            {
                consulta.Append("WHERE ga.Id_usuario = @Texto_busqueda ");
            }
            else if (tipo_busqueda.Equals("ID TURNO"))
            {
                consulta.Append("WHERE ga.Id_turno = @Texto_busqueda ");
            }

            consulta.Append("ORDER BY ga.Id_gasto DESC");

            DataTable DtResultado = new DataTable("Gastos");
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
