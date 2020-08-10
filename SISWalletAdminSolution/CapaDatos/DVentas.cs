namespace CapaDatos
{
    using CapaEntidades;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;

    public class DVentas
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
        public DVentas()
        {

        }

        #endregion

        #region METODO INSERTAR
        public string InsertarVentas(out int id_venta, Ventas venta)
        {
            id_venta = 0;
            int contador = 0;
            string rpta = "";

            string consulta = "INSERT INTO Ventas (Id_cobro, Id_tipo_producto, Id_cliente, Id_direccion, Id_turno, Fecha_venta, Hora_venta, " +
                "Valor_venta, Interes_venta, Total_venta, Numero_cuotas, Frecuencia_cobro, Valor_cuota, Estado_venta, Tipo_venta) " +
                "VALUES(@Id_cobro, @Id_tipo_producto, @Id_cliente, @Id_direccion, @Id_turno, @Fecha_venta, @Hora_venta, " +
                "@Valor_venta, @Interes_venta, @Total_venta, @Numero_cuotas, @Frecuencia_cobro, @Valor_cuota, @Estado_venta, @Tipo_venta) " +
                "SET @Id_venta = SCOPE_IDENTITY() ";

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

                SqlParameter Id_venta = new SqlParameter
                {
                    ParameterName = "@Id_venta",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_venta);

                SqlParameter Id_cobro = new SqlParameter
                {
                    ParameterName = "@Id_cobro",
                    SqlDbType = SqlDbType.Int,
                    Value = venta.Id_cobro
                };
                SqlCmd.Parameters.Add(Id_cobro);
                contador += 1;

                SqlParameter Id_tipo_producto = new SqlParameter
                {
                    ParameterName = "@Id_tipo_producto",
                    SqlDbType = SqlDbType.Int,
                    Value = venta.Id_tipo_producto
                };
                SqlCmd.Parameters.Add(Id_tipo_producto);
                contador += 1;

                SqlParameter Id_cliente = new SqlParameter
                {
                    ParameterName = "@Id_cliente",
                    SqlDbType = SqlDbType.Int,
                    Value = venta.Id_cliente
                };
                SqlCmd.Parameters.Add(Id_cliente);
                contador += 1;

                SqlParameter Id_direccion = new SqlParameter
                {
                    ParameterName = "@Id_direccion",
                    SqlDbType = SqlDbType.Int,
                    Value = venta.Id_direccion
                };
                SqlCmd.Parameters.Add(Id_direccion);
                contador += 1;

                SqlParameter Id_turno = new SqlParameter
                {
                    ParameterName = "@Id_turno",
                    SqlDbType = SqlDbType.Int,
                    Value = venta.Id_turno
                };
                SqlCmd.Parameters.Add(Id_turno);
                contador += 1;

                SqlParameter Fecha_venta = new SqlParameter
                {
                    ParameterName = "@Fecha_venta",
                    SqlDbType = SqlDbType.Date,
                    Value = venta.Fecha_venta,
                };
                SqlCmd.Parameters.Add(Fecha_venta);
                contador += 1;

                SqlParameter Hora_venta = new SqlParameter
                {
                    ParameterName = "@Hora_venta",
                    SqlDbType = SqlDbType.Time,
                    Size = 2,
                    Value = venta.Hora_venta,
                };
                SqlCmd.Parameters.Add(Hora_venta);
                contador += 1;

                SqlParameter Valor_venta = new SqlParameter
                {
                    ParameterName = "@Valor_venta",
                    SqlDbType = SqlDbType.Decimal,
                    Value = venta.Valor_venta,
                };
                SqlCmd.Parameters.Add(Valor_venta);
                contador += 1;

                SqlParameter Interes_venta = new SqlParameter
                {
                    ParameterName = "@Interes_venta",
                    SqlDbType = SqlDbType.Decimal,
                    Value = venta.Interes_venta,
                };
                SqlCmd.Parameters.Add(Interes_venta);
                contador += 1;

                SqlParameter Total_venta = new SqlParameter
                {
                    ParameterName = "@Total_venta",
                    SqlDbType = SqlDbType.Decimal,
                    Value = venta.Total_venta,
                };
                SqlCmd.Parameters.Add(Total_venta);
                contador += 1;

                SqlParameter Numero_cuotas = new SqlParameter
                {
                    ParameterName = "@Numero_cuotas",
                    SqlDbType = SqlDbType.Int,
                    Value = venta.Numero_cuotas,
                };
                SqlCmd.Parameters.Add(Numero_cuotas);
                contador += 1;

                SqlParameter Frecuencia_cobro = new SqlParameter
                {
                    ParameterName = "@Frecuencia_cobro",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = venta.Frecuencia_cobro.Trim()
                };
                SqlCmd.Parameters.Add(Frecuencia_cobro);
                contador += 1;

                SqlParameter Valor_cuota = new SqlParameter
                {
                    ParameterName = "@Valor_cuota",
                    SqlDbType = SqlDbType.Decimal,
                    Value = venta.Valor_cuota,
                };
                SqlCmd.Parameters.Add(Valor_cuota);
                contador += 1;

                SqlParameter Estado_venta = new SqlParameter
                {
                    ParameterName = "@Estado_venta",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = venta.Estado_venta.Trim()
                };
                SqlCmd.Parameters.Add(Estado_venta);
                contador += 1;

                SqlParameter Tipo_venta = new SqlParameter
                {
                    ParameterName = "@Tipo_venta",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = venta.Tipo_venta.Trim()
                };
                SqlCmd.Parameters.Add(Tipo_venta);
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
                    id_venta = Convert.ToInt32(SqlCmd.Parameters["@Id_venta"].Value);
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
        public string EditarVentas(int id_venta, Ventas venta)
        {
            int contador = 0;
            string rpta = "";

            string consulta = "UPDATE Ventas SET " +
                "Id_cobro = @Id_cobro, " +
                "Id_tipo_producto = @Id_tipo_producto, " +
                "Id_cliente = @Id_cliente, " +
                "Id_direccion = @Id_direccion, " +
                "Id_turno = @Id_turno, " +
                "Fecha_venta = @Fecha_venta, " +
                "Hora_venta = @Hora_venta, " +
                "Valor_venta = @Valor_venta, " +
                "Interes_venta = @Interes_venta, " +
                "Total_venta = @Total_venta, " +
                "Numero_cuotas = @Numero_cuotas, " +
                "Frecuencia_cobro = @Frecuencia_cobro, " +
                "Valor_cuota = @Valor_cuota, " +
                "Estado_venta = @Estado_venta, " +
                "Tipo_venta = @Tipo_venta" +
                "WHERE Id_venta = @Id_venta ";

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

                SqlParameter Id_venta = new SqlParameter
                {
                    ParameterName = "@Id_venta",
                    SqlDbType = SqlDbType.Int,
                    Value = id_venta,
                };
                SqlCmd.Parameters.Add(Id_venta);

                SqlParameter Id_cobro = new SqlParameter
                {
                    ParameterName = "@Id_cobro",
                    SqlDbType = SqlDbType.Int,
                    Value = venta.Id_cobro
                };
                SqlCmd.Parameters.Add(Id_cobro);
                contador += 1;

                SqlParameter Id_tipo_producto = new SqlParameter
                {
                    ParameterName = "@Id_tipo_producto",
                    SqlDbType = SqlDbType.Int,
                    Value = venta.Id_tipo_producto
                };
                SqlCmd.Parameters.Add(Id_tipo_producto);
                contador += 1;

                SqlParameter Id_cliente = new SqlParameter
                {
                    ParameterName = "@Id_cliente",
                    SqlDbType = SqlDbType.Int,
                    Value = venta.Id_cliente
                };
                SqlCmd.Parameters.Add(Id_cliente);
                contador += 1;

                SqlParameter Id_direccion = new SqlParameter
                {
                    ParameterName = "@Id_direccion",
                    SqlDbType = SqlDbType.Int,
                    Value = venta.Id_direccion
                };
                SqlCmd.Parameters.Add(Id_direccion);
                contador += 1;

                SqlParameter Id_turno = new SqlParameter
                {
                    ParameterName = "@Id_turno",
                    SqlDbType = SqlDbType.Int,
                    Value = venta.Id_turno
                };
                SqlCmd.Parameters.Add(Id_turno);
                contador += 1;

                SqlParameter Fecha_venta = new SqlParameter
                {
                    ParameterName = "@Fecha_venta",
                    SqlDbType = SqlDbType.Date,
                    Value = venta.Fecha_venta,
                };
                SqlCmd.Parameters.Add(Fecha_venta);
                contador += 1;

                SqlParameter Hora_venta = new SqlParameter
                {
                    ParameterName = "@Hora_venta",
                    SqlDbType = SqlDbType.Time,
                    Size = 2,
                    Value = venta.Hora_venta,
                };
                SqlCmd.Parameters.Add(Hora_venta);
                contador += 1;

                SqlParameter Valor_venta = new SqlParameter
                {
                    ParameterName = "@Valor_venta",
                    SqlDbType = SqlDbType.Decimal,
                    Value = venta.Valor_venta,
                };
                SqlCmd.Parameters.Add(Valor_venta);
                contador += 1;

                SqlParameter Interes_venta = new SqlParameter
                {
                    ParameterName = "@Interes_venta",
                    SqlDbType = SqlDbType.Decimal,
                    Value = venta.Interes_venta,
                };
                SqlCmd.Parameters.Add(Interes_venta);
                contador += 1;

                SqlParameter Total_venta = new SqlParameter
                {
                    ParameterName = "@Total_venta",
                    SqlDbType = SqlDbType.Decimal,
                    Value = venta.Total_venta,
                };
                SqlCmd.Parameters.Add(Total_venta);
                contador += 1;

                SqlParameter Numero_cuotas = new SqlParameter
                {
                    ParameterName = "@Numero_cuotas",
                    SqlDbType = SqlDbType.Int,
                    Value = venta.Numero_cuotas,
                };
                SqlCmd.Parameters.Add(Numero_cuotas);
                contador += 1;

                SqlParameter Frecuencia_cobro = new SqlParameter
                {
                    ParameterName = "@Frecuencia_cobro",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = venta.Frecuencia_cobro.Trim()
                };
                SqlCmd.Parameters.Add(Frecuencia_cobro);
                contador += 1;

                SqlParameter Valor_cuota = new SqlParameter
                {
                    ParameterName = "@Valor_cuota",
                    SqlDbType = SqlDbType.Decimal,
                    Value = venta.Valor_cuota,
                };
                SqlCmd.Parameters.Add(Valor_cuota);
                contador += 1;

                SqlParameter Estado_venta = new SqlParameter
                {
                    ParameterName = "@Estado_venta",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = venta.Estado_venta.Trim()
                };
                SqlCmd.Parameters.Add(Estado_venta);
                contador += 1;

                SqlParameter Tipo_venta = new SqlParameter
                {
                    ParameterName = "@Tipo_venta",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = venta.Tipo_venta.Trim()
                };
                SqlCmd.Parameters.Add(Tipo_venta);
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

        #region METODO BUSCAR VENTAS
        public DataTable BuscarVentas(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            rpta = "OK";

            StringBuilder consulta = new StringBuilder();

            consulta.Append("SELECT * FROM Ventas ve " +
                "INNER JOIN Cobros cb ON ve.Id_cobro = cb.Id_cobro " +
                "INNER JOIN Turnos tu ON ve.Id_turno = tu.Id_turno " +
                "INNER JOIN Tipo_productos tppr ON ve.Id_tipo_producto = tppr.Id_tipo_producto " +
                "INNER JOIN Usuarios us ON ve.Id_cliente = us.Id_usuario " +
                "INNER JOIN Direccion_clientes dcl ON ve.Id_direccion = dcl.Id_direccion ");

            if (tipo_busqueda.Equals("ID VENTA"))
            {
                consulta.Append("WHERE ve.Id_venta = @Texto_busqueda ");
            }
            else if (tipo_busqueda.Equals("ID CLIENTE"))
            {
                consulta.Append("WHERE ve.Id_cliente = @Texto_busqueda ");
            }
            else if (tipo_busqueda.Equals("ID TURNO"))
            {
                consulta.Append("WHERE ve.Id_turno = @Texto_busqueda ");
            }
            else if (tipo_busqueda.Equals("ID COBRO"))
            {
                consulta.Append("WHERE ve.Id_cobro = @Texto_busqueda ");
            }

            consulta.Append("ORDER BY ve.Id_venta DESC");

            DataTable DtResultado = new DataTable("Ventas");
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
