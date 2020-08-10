namespace CapaDatos
{
    using CapaEntidades;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;

    public class DCobros
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
        public DCobros()
        {

        }

        #endregion

        #region METODO INSERTAR
        public string InsertarCobros(out int id_cobro, Cobros cobro)
        {
            id_cobro = 0;
            int contador = 0;
            string rpta = "";

            string consulta = "INSERT INTO Cobros (Id_usuario, Id_tipo_producto, Id_zona, Fecha_apertura, " +
                "Hora_apertura, Valor_cobro, Estado_cobro) " +
                "VALUES(@Id_usuario, @Id_tipo_producto, @Id_zona, @Fecha_apertura, " +
                "@Hora_apertura, @Valor_cobro, @Estado_cobro) " +
                "SET @Id_cobro = SCOPE_IDENTITY() ";

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

                SqlParameter Id_cobro = new SqlParameter
                {
                    ParameterName = "@Id_cobro",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_cobro);

                SqlParameter Id_usuario = new SqlParameter
                {
                    ParameterName = "@Id_usuario",
                    SqlDbType = SqlDbType.Int,
                    Value = cobro.Id_usuario
                };
                SqlCmd.Parameters.Add(Id_usuario);
                contador += 1;

                SqlParameter Id_tipo_producto = new SqlParameter
                {
                    ParameterName = "@Id_tipo_producto",
                    SqlDbType = SqlDbType.Int,
                    Value = cobro.Id_tipo_producto
                };
                SqlCmd.Parameters.Add(Id_tipo_producto);
                contador += 1;

                SqlParameter Id_zona = new SqlParameter
                {
                    ParameterName = "@Id_zona",
                    SqlDbType = SqlDbType.Int,
                    Value = cobro.Id_zona
                };
                SqlCmd.Parameters.Add(Id_zona);
                contador += 1;

                SqlParameter Fecha_apertura = new SqlParameter
                {
                    ParameterName = "@Fecha_apertura",
                    SqlDbType = SqlDbType.Date,
                    Value = cobro.Fecha_apertura,
                };
                SqlCmd.Parameters.Add(Fecha_apertura);
                contador += 1;

                SqlParameter Hora_apertura = new SqlParameter
                {
                    ParameterName = "@Hora_apertura",
                    SqlDbType = SqlDbType.Time,
                    Size = 2,
                    Value = cobro.Hora_apertura,
                };
                SqlCmd.Parameters.Add(Hora_apertura);
                contador += 1;

                SqlParameter Valor_cobro = new SqlParameter
                {
                    ParameterName = "@Valor_cobro",
                    SqlDbType = SqlDbType.Decimal,
                    Value = cobro.Valor_cobro,
                };
                SqlCmd.Parameters.Add(Valor_cobro);
                contador += 1;

                SqlParameter Estado_cobro = new SqlParameter
                {
                    ParameterName = "@Estado_cobro",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = cobro.Estado_cobro.Trim()
                };
                SqlCmd.Parameters.Add(Estado_cobro);
                contador += 1;

                SqlParameter Observaciones = new SqlParameter
                {
                    ParameterName = "@Observaciones",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150,
                    Value = cobro.Observaciones.Trim()
                };
                SqlCmd.Parameters.Add(Observaciones);
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
                    id_cobro = Convert.ToInt32(SqlCmd.Parameters["@Id_cobro"].Value);
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
        public string EditarCobros(int id_cobro, Cobros cobro)
        {
            int contador = 0;
            string rpta = "";

            string consulta = "UPDATE Cobros SET " +
                "Id_usuario = @Id_usuario, " +
                "Id_tipo_producto = @Id_tipo_producto, " +
                "Id_zona = @Id_zona, " +
                "Fecha_apertura = @Fecha_apertura, " +
                "Hora_apertura = @Hora_apertura, " +
                "Valor_cobro = @Valor_cobro, " +
                "Estado_cobro = @Estado_cobro " +
                "WHERE Id_cobro = @Id_cobro ";

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

                SqlParameter Id_cobro = new SqlParameter
                {
                    ParameterName = "@Id_cobro",
                    SqlDbType = SqlDbType.Int,
                    Value = id_cobro,
                };
                SqlCmd.Parameters.Add(Id_cobro);

                SqlParameter Id_usuario = new SqlParameter
                {
                    ParameterName = "@Id_usuario",
                    SqlDbType = SqlDbType.Int,
                    Value = cobro.Id_usuario
                };
                SqlCmd.Parameters.Add(Id_usuario);
                contador += 1;

                SqlParameter Id_tipo_producto = new SqlParameter
                {
                    ParameterName = "@Id_tipo_producto",
                    SqlDbType = SqlDbType.Int,
                    Value = cobro.Id_tipo_producto
                };
                SqlCmd.Parameters.Add(Id_tipo_producto);
                contador += 1;

                SqlParameter Id_zona = new SqlParameter
                {
                    ParameterName = "@Id_zona",
                    SqlDbType = SqlDbType.Int,
                    Value = cobro.Id_zona
                };
                SqlCmd.Parameters.Add(Id_zona);
                contador += 1;

                SqlParameter Fecha_apertura = new SqlParameter
                {
                    ParameterName = "@Fecha_apertura",
                    SqlDbType = SqlDbType.Date,
                    Value = cobro.Fecha_apertura,
                };
                SqlCmd.Parameters.Add(Fecha_apertura);
                contador += 1;

                SqlParameter Hora_apertura = new SqlParameter
                {
                    ParameterName = "@Hora_apertura",
                    SqlDbType = SqlDbType.Time,
                    Size = 2,
                    Value = cobro.Hora_apertura,
                };
                SqlCmd.Parameters.Add(Hora_apertura);
                contador += 1;

                SqlParameter Valor_cobro = new SqlParameter
                {
                    ParameterName = "@Valor_cobro",
                    SqlDbType = SqlDbType.Decimal,
                    Value = cobro.Valor_cobro,
                };
                SqlCmd.Parameters.Add(Valor_cobro);
                contador += 1;

                SqlParameter Estado_cobro = new SqlParameter
                {
                    ParameterName = "@Estado_cobro",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = cobro.Estado_cobro.Trim()
                };
                SqlCmd.Parameters.Add(Estado_cobro);
                contador += 1;

                SqlParameter Observaciones = new SqlParameter
                {
                    ParameterName = "@Observaciones",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150,
                    Value = cobro.Observaciones.Trim()
                };
                SqlCmd.Parameters.Add(Observaciones);
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

        #region METODO BUSCAR COBROS
        public DataTable BuscarCobros(string tipo_busqueda, string texto_busqueda1, string texto_busqueda2,
            out string rpta)
        {
            rpta = "OK";

            DataTable DtResultado = new DataTable("Cobros");
            SqlConnection SqlCon = new SqlConnection();
            SqlCon.InfoMessage += new SqlInfoMessageEventHandler(SqlCon_InfoMessage);
            SqlCon.FireInfoMessageEventOnUserErrors = true;
            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                StringBuilder consulta = new StringBuilder();
                SqlCommand Sqlcmd;
                if (tipo_busqueda.Equals("ESTADISTICA ID COBRO"))
                {
                    Sqlcmd = new SqlCommand
                    {
                        Connection = SqlCon,
                        CommandText = "sp_Estadistica_cobros",
                        CommandType = CommandType.StoredProcedure,
                    };
                }
                else if (tipo_busqueda.Equals("ESTADISTICA ID COBRO DIARIO"))
                {
                    Sqlcmd = new SqlCommand
                    {
                        Connection = SqlCon,
                        CommandText = "sp_Estadistica_cobros_diarias",
                        CommandType = CommandType.StoredProcedure,
                    };
                }
                else
                {
                    consulta.Append("SELECT * " +
                        "FROM Cobros cb " +
                        "INNER JOIN Zonas zo ON cb.Id_zona = zo.Id_zona " +
                        "INNER JOIN Ciudades ci ON zo.Id_ciudad = ci.Id_ciudad " +
                        "INNER JOIN Paises pa ON ci.Id_pais = pa.Id_pais " +
                        "INNER JOIN Usuarios us ON cb.Id_usuario = us.Id_usuario " +
                        "INNER JOIN Tipo_productos tppr ON cb.Id_tipo_producto = tppr.Id_tipo_producto "
                       );

                    if (tipo_busqueda.Equals("ID USUARIO"))
                    {
                        consulta.Append("WHERE cb.Id_usuario = @Texto_busqueda1 ");
                    }
                    else if (tipo_busqueda.Equals("ID ZONA"))
                    {
                        consulta.Append("WHERE cb.Id_zona = @Texto_busqueda1 ");
                    }
                    else if (tipo_busqueda.Equals("ID COBRO"))
                    {
                        consulta.Append("WHERE cb.Id_cobro = @Texto_busqueda1 ");
                    }
                    else if (tipo_busqueda.Equals("ID USUARIO ID CIUDAD"))
                    {
                        consulta.Append("WHERE cb.Id_usuario = @Texto_busqueda1 and " +
                            "ci.Id_ciudad = @Texto_busqueda2 ");
                    }
                    else if (tipo_busqueda.Equals("ID USUARIO ID PAIS"))
                    {
                        consulta.Append("WHERE cb.Id_usuario = @Texto_busqueda1 and " +
                            "pa.Id_pais = @Texto_busqueda2 ");
                    }

                    consulta.Append("ORDER BY cb.Id_cobro DESC");

                    Sqlcmd = new SqlCommand
                    {
                        Connection = SqlCon,
                        CommandText = consulta.ToString(),
                        CommandType = CommandType.Text
                    };
                }

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

        public DataTable BuscarEstadisticaCobroDiario(string texto_busqueda1, string texto_busqueda2,
            out string rpta)
        {
            rpta = "OK";

            StringBuilder consulta = new StringBuilder();
            DataTable DtResultado = new DataTable("Cobros");
            SqlConnection SqlCon = new SqlConnection();
            SqlCon.InfoMessage += new SqlInfoMessageEventHandler(SqlCon_InfoMessage);
            SqlCon.FireInfoMessageEventOnUserErrors = true;
            try
            {
                SqlCon.ConnectionString = DConexion.Cn;
                SqlCommand Sqlcmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = "sp_Estadistica_diaria_cobro",
                    CommandType = CommandType.StoredProcedure
                };

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
