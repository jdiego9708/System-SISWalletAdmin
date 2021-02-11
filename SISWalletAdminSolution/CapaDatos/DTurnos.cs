namespace CapaDatos
{
    using CapaEntidades;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;

    public class DTurnos
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
        public DTurnos()
        {

        }

        #endregion

        #region METODO INSERTAR
        public string InsertarTurno(out int id_turno, Turnos turno)
        {
            id_turno = 0;
            int contador = 0;
            string rpta = "";

            string consulta = "INSERT INTO Turnos (Id_cobrador, Id_cobro, Fecha_inicio_turno, Fecha_fin_turno, Hora_inicio_turno, Hora_fin_turno, " +
                "Valor_inicial, Clientes_iniciales, Clientes_nuevos, Clientes_cancelados, Clientes_total, Recaudo_ventas_nuevas, Recaudo_cuotas, " +
                "Recaudo_otros, Recaudo_pretendido_turno, Recaudo_real, Gastos_total, Estado_turno) " +
                "VALUES(@Id_cobrador, @Id_cobro, @Fecha_inicio_turno, @Fecha_fin_turno, @Hora_inicio_turno, @Hora_fin_turno, " +
                "@Valor_inicial, @Clientes_iniciales, @Clientes_nuevos, @Clientes_cancelados, @Clientes_total, @Recaudo_ventas_nuevas, @Recaudo_cuotas, " +
                "@Recaudo_otros, @Recaudo_pretendido_turno, @Recaudo_real, @Gastos_total, @Estado_turno) " +
                "SET @Id_turno = SCOPE_IDENTITY() ";

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

                SqlParameter Id_turno = new SqlParameter
                {
                    ParameterName = "@Id_turno",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_turno);

                SqlParameter Id_cobrador = new SqlParameter
                {
                    ParameterName = "@Id_cobrador",
                    SqlDbType = SqlDbType.Int,
                    Value = turno.Id_cobrador
                };
                SqlCmd.Parameters.Add(Id_cobrador);
                contador += 1;

                SqlParameter Id_cobro = new SqlParameter
                {
                    ParameterName = "@Id_cobro",
                    SqlDbType = SqlDbType.Int,
                    Value = turno.Id_cobro
                };
                SqlCmd.Parameters.Add(Id_cobro);
                contador += 1;

                SqlParameter Fecha_inicio_turno = new SqlParameter
                {
                    ParameterName = "@Fecha_inicio_turno",
                    SqlDbType = SqlDbType.Date,
                    Value = turno.Fecha_inicio_turno,
                };
                SqlCmd.Parameters.Add(Fecha_inicio_turno);
                contador += 1;

                SqlParameter Fecha_fin_turno = new SqlParameter
                {
                    ParameterName = "@Fecha_fin_turno",
                    SqlDbType = SqlDbType.Date,
                    Value = turno.Fecha_fin_turno,
                };
                SqlCmd.Parameters.Add(Fecha_fin_turno);
                contador += 1;

                SqlParameter Hora_inicio_turno = new SqlParameter
                {
                    ParameterName = "@Hora_inicio_turno",
                    SqlDbType = SqlDbType.Time,
                    Value = turno.Hora_inicio_turno,
                };
                SqlCmd.Parameters.Add(Hora_inicio_turno);
                contador += 1;

                SqlParameter Hora_fin_turno = new SqlParameter
                {
                    ParameterName = "@Hora_fin_turno",
                    SqlDbType = SqlDbType.Time,
                    Size = 2,
                    Value = turno.Hora_fin_turno,
                };
                SqlCmd.Parameters.Add(Hora_fin_turno);
                contador += 1;

                SqlParameter Valor_inicial = new SqlParameter
                {
                    ParameterName = "@Valor_inicial",
                    SqlDbType = SqlDbType.Decimal,
                    Value = turno.Valor_inicial,
                };
                SqlCmd.Parameters.Add(Valor_inicial);
                contador += 1;

                SqlParameter Clientes_iniciales = new SqlParameter
                {
                    ParameterName = "@Clientes_iniciales",
                    SqlDbType = SqlDbType.Int,
                    Value = turno.Clientes_iniciales,
                };
                SqlCmd.Parameters.Add(Clientes_iniciales);
                contador += 1;

                SqlParameter Clientes_nuevos = new SqlParameter
                {
                    ParameterName = "@Clientes_nuevos",
                    SqlDbType = SqlDbType.Int,
                    Value = turno.Clientes_nuevos,
                };
                SqlCmd.Parameters.Add(Clientes_nuevos);
                contador += 1;

                SqlParameter Clientes_cancelados = new SqlParameter
                {
                    ParameterName = "@Clientes_cancelados",
                    SqlDbType = SqlDbType.Int,
                    Value = turno.Clientes_cancelados,
                };
                SqlCmd.Parameters.Add(Clientes_cancelados);
                contador += 1;

                SqlParameter Clientes_total = new SqlParameter
                {
                    ParameterName = "@Clientes_total",
                    SqlDbType = SqlDbType.Int,
                    Value = turno.Clientes_total,
                };
                SqlCmd.Parameters.Add(Clientes_total);
                contador += 1;

                SqlParameter Recaudo_ventas_nuevas = new SqlParameter
                {
                    ParameterName = "@Recaudo_ventas_nuevas",
                    SqlDbType = SqlDbType.Decimal,
                    Value = turno.Recaudo_ventas_nuevas,
                };
                SqlCmd.Parameters.Add(Recaudo_ventas_nuevas);
                contador += 1;

                SqlParameter Recaudo_cuotas = new SqlParameter
                {
                    ParameterName = "@Recaudo_cuotas",
                    SqlDbType = SqlDbType.Decimal,
                    Value = turno.Recaudo_cuotas,
                };
                SqlCmd.Parameters.Add(Recaudo_cuotas);
                contador += 1;

                SqlParameter Recaudo_otros = new SqlParameter
                {
                    ParameterName = "@Recaudo_otros",
                    SqlDbType = SqlDbType.Decimal,
                    Value = turno.Recaudo_otros,
                };
                SqlCmd.Parameters.Add(Recaudo_otros);
                contador += 1;

                SqlParameter Recaudo_pretendido_turno = new SqlParameter
                {
                    ParameterName = "@Recaudo_pretendido_turno",
                    SqlDbType = SqlDbType.Decimal,
                    Value = turno.Recaudo_pretendido_turno,
                };
                SqlCmd.Parameters.Add(Recaudo_pretendido_turno);
                contador += 1;

                SqlParameter Recaudo_real = new SqlParameter
                {
                    ParameterName = "@Recaudo_real",
                    SqlDbType = SqlDbType.Decimal,
                    Value = turno.Recaudo_real,
                };
                SqlCmd.Parameters.Add(Recaudo_real);
                contador += 1;

                SqlParameter Gastos_total = new SqlParameter
                {
                    ParameterName = "@Gastos_total",
                    SqlDbType = SqlDbType.Decimal,
                    Value = turno.Gastos_total,
                };
                SqlCmd.Parameters.Add(Gastos_total);
                contador += 1;

                SqlParameter Estado_turno = new SqlParameter
                {
                    ParameterName = "@Estado_turno",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = turno.Estado_turno.Trim()
                };
                SqlCmd.Parameters.Add(Estado_turno);
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
                    id_turno = Convert.ToInt32(SqlCmd.Parameters["@Id_turno"].Value);
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
        public string EditarVentas(int id_turno, Turnos turno)
        {
            int contador = 0;
            string rpta = "";

            string consulta = "UPDATE Turnos SET " +
                "Id_cobrador = @Id_cobrador, " +
                "Id_cobro = @Id_cobro, " +
                "Fecha_inicio_turno = @Fecha_inicio_turno, " +
                "Fecha_fin_turno = @Fecha_fin_turno, " +
                "Hora_inicio_turno  = @Hora_inicio_turno, " +
                "Hora_fin_turno = @Hora_fin_turno, " +
                "Valor_inicial = @Valor_inicial, " +
                "Clientes_iniciales = @Clientes_iniciales, " +
                "Clientes_nuevos = @Clientes_nuevos, " +
                "Clientes_cancelados = @Clientes_cancelados, " +
                "Clientes_total = @Clientes_total, " +
                "Recaudo_ventas_nuevas = @Recaudo_ventas_nuevas, " +
                "Recaudo_cuotas = @Recaudo_cuotas, " +
                "Recaudo_otros = @Recaudo_otros, " +
                "Recaudo_pretendido_turno = @Recaudo_pretendido_turno, " +
                "Recaudo_real = @Recaudo_real, " +
                "Gastos_total = @Gastos_total, " +
                "Estado_turno = @Estado_turno " +
                "WHERE Id_turno = @Id_turno ";

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

                SqlParameter Id_turno = new SqlParameter
                {
                    ParameterName = "@Id_turno",
                    SqlDbType = SqlDbType.Int,
                    Value = id_turno,
                };
                SqlCmd.Parameters.Add(Id_turno);

                SqlParameter Id_cobrador = new SqlParameter
                {
                    ParameterName = "@Id_cobrador",
                    SqlDbType = SqlDbType.Int,
                    Value = turno.Id_cobrador,
                };
                SqlCmd.Parameters.Add(Id_cobrador);
                contador += 1;

                SqlParameter Id_cobro = new SqlParameter
                {
                    ParameterName = "@Id_cobro",
                    SqlDbType = SqlDbType.Int,
                    Value = turno.Id_cobro,
                };
                SqlCmd.Parameters.Add(Id_cobro);
                contador += 1;

                SqlParameter Fecha_inicio_turno = new SqlParameter
                {
                    ParameterName = "@Fecha_inicio_turno",
                    SqlDbType = SqlDbType.Date,
                    Value = turno.Fecha_inicio_turno,
                };
                SqlCmd.Parameters.Add(Fecha_inicio_turno);
                contador += 1;

                SqlParameter Fecha_fin_turno = new SqlParameter
                {
                    ParameterName = "@Fecha_fin_turno",
                    SqlDbType = SqlDbType.Date,
                    Value = turno.Fecha_fin_turno,
                };
                SqlCmd.Parameters.Add(Fecha_fin_turno);
                contador += 1;

                SqlParameter Hora_inicio_turno = new SqlParameter
                {
                    ParameterName = "@Hora_inicio_turno",
                    SqlDbType = SqlDbType.Time,
                    Value = turno.Hora_inicio_turno,
                };
                SqlCmd.Parameters.Add(Hora_inicio_turno);
                contador += 1;

                SqlParameter Hora_fin_turno = new SqlParameter
                {
                    ParameterName = "@Hora_fin_turno",
                    SqlDbType = SqlDbType.Time,
                    Value = turno.Hora_fin_turno,
                };
                SqlCmd.Parameters.Add(Hora_fin_turno);
                contador += 1;

                SqlParameter Valor_inicial = new SqlParameter
                {
                    ParameterName = "@Valor_inicial",
                    SqlDbType = SqlDbType.Decimal,
                    Value = turno.Valor_inicial,
                };
                SqlCmd.Parameters.Add(Valor_inicial);
                contador += 1;

                SqlParameter Clientes_iniciales = new SqlParameter
                {
                    ParameterName = "@Clientes_iniciales",
                    SqlDbType = SqlDbType.Int,
                    Value = turno.Clientes_iniciales,
                };
                SqlCmd.Parameters.Add(Clientes_iniciales);
                contador += 1;

                SqlParameter Clientes_nuevos = new SqlParameter
                {
                    ParameterName = "@Clientes_nuevos",
                    SqlDbType = SqlDbType.Int,
                    Value = turno.Clientes_nuevos,
                };
                SqlCmd.Parameters.Add(Clientes_nuevos);
                contador += 1;

                SqlParameter Clientes_cancelados = new SqlParameter
                {
                    ParameterName = "@Clientes_cancelados",
                    SqlDbType = SqlDbType.Int,
                    Value = turno.Clientes_cancelados,
                };
                SqlCmd.Parameters.Add(Clientes_cancelados);
                contador += 1;

                SqlParameter Clientes_total = new SqlParameter
                {
                    ParameterName = "@Clientes_total",
                    SqlDbType = SqlDbType.Int,
                    Value = turno.Clientes_total,
                };
                SqlCmd.Parameters.Add(Clientes_total);
                contador += 1;

                SqlParameter Recaudo_ventas_nuevas = new SqlParameter
                {
                    ParameterName = "@Recaudo_ventas_nuevas",
                    SqlDbType = SqlDbType.Decimal,
                    Value = turno.Recaudo_ventas_nuevas,
                };
                SqlCmd.Parameters.Add(Recaudo_ventas_nuevas);
                contador += 1;

                SqlParameter Recaudo_cuotas = new SqlParameter
                {
                    ParameterName = "@Recaudo_cuotas",
                    SqlDbType = SqlDbType.Decimal,
                    Value = turno.Recaudo_cuotas,
                };
                SqlCmd.Parameters.Add(Recaudo_cuotas);
                contador += 1;

                SqlParameter Recaudo_otros = new SqlParameter
                {
                    ParameterName = "@Recaudo_otros",
                    SqlDbType = SqlDbType.Decimal,
                    Value = turno.Recaudo_otros,
                };
                SqlCmd.Parameters.Add(Recaudo_otros);
                contador += 1;

                SqlParameter Recaudo_pretendido_turno = new SqlParameter
                {
                    ParameterName = "@Recaudo_pretendido_turno",
                    SqlDbType = SqlDbType.Decimal,
                    Value = turno.Recaudo_pretendido_turno,
                };
                SqlCmd.Parameters.Add(Recaudo_pretendido_turno);
                contador += 1;

                SqlParameter Recaudo_real = new SqlParameter
                {
                    ParameterName = "@Recaudo_real",
                    SqlDbType = SqlDbType.Decimal,
                    Value = turno.Recaudo_real,
                };
                SqlCmd.Parameters.Add(Recaudo_real);
                contador += 1;

                SqlParameter Gastos_total = new SqlParameter
                {
                    ParameterName = "@Gastos_total",
                    SqlDbType = SqlDbType.Decimal,
                    Value = turno.Gastos_total,
                };
                SqlCmd.Parameters.Add(Gastos_total);
                contador += 1;

                SqlParameter Estado_turno = new SqlParameter
                {
                    ParameterName = "@Estado_turno",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = turno.Estado_turno.Trim()
                };
                SqlCmd.Parameters.Add(Estado_turno);
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

        #region METODO BUSCAR TURNOS
        public DataTable BuscarTurnos(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            rpta = "OK";

            DataTable DtResultado = new DataTable("Turnos");
            SqlConnection SqlCon = new SqlConnection();
            SqlCon.InfoMessage += new SqlInfoMessageEventHandler(SqlCon_InfoMessage);
            SqlCon.FireInfoMessageEventOnUserErrors = true;
            try
            { 
                StringBuilder consulta = new StringBuilder();
                SqlCommand Sqlcmd;
                if (tipo_busqueda != "CERRAR TURNO")
                {
                    consulta.Append("SELECT * FROM Turnos tu " +
                    "INNER JOIN Usuarios us ON tu.Id_cobrador = us.Id_usuario ");

                    if (tipo_busqueda.Equals("ID TURNO"))
                    {
                        consulta.Append("WHERE tu.Id_turno = @Texto_busqueda ");
                    }
                    else if (tipo_busqueda.Equals("ID COBRADOR"))
                    {
                        consulta.Append("WHERE tu.Id_cobrador = @Texto_busqueda ");
                    }
                    else if (tipo_busqueda.Equals("FECHA INICIO"))
                    {
                        MainController main = MainController.GetInstance();
                        consulta.Append("WHERE tu.Fecha_inicio_turno = '" + texto_busqueda + "' and " +
                            "tu.Id_cobro = " + main.Id_cobro + " ");
                    }

                    consulta.Append("ORDER BY tu.Id_turno DESC");

                    SqlCon.ConnectionString = DConexion.Cn;
                    Sqlcmd = new SqlCommand
                    {
                        Connection = SqlCon,
                        CommandText = consulta.ToString(),
                        CommandType = CommandType.Text
                    };
                }
                else
                {
                    SqlCon.ConnectionString = DConexion.Cn;
                    Sqlcmd = new SqlCommand
                    {
                        Connection = SqlCon,
                        CommandText = "sp_Estadistica_cobradores_diarias",
                        CommandType = CommandType.StoredProcedure
                    };
                }

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
