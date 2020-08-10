namespace CapaDatos
{
    using CapaEntidades;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;

    public class DTipo_productos
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
        public DTipo_productos()
        {

        }

        #endregion

        #region METODO INSERTAR
        public string InsertarTipoProductos(out int id_tipo_producto, Tipo_productos producto)
        {
            id_tipo_producto = 0;
            int contador = 0;
            string rpta = "";

            string consulta = "INSERT INTO Tipo_productos (Nombre_producto, Descripcion_producto, Estado_producto) " +
                "VALUES(@Nombre_producto, @Descripcion_producto, @Estado_producto) " +
                "SET @Id_tipo_producto = SCOPE_IDENTITY() ";

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

                SqlParameter Id_tipo_producto = new SqlParameter
                {
                    ParameterName = "@Id_tipo_producto",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                SqlCmd.Parameters.Add(Id_tipo_producto);

                SqlParameter Nombre_producto = new SqlParameter
                {
                    ParameterName = "@Nombre_producto",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = producto.Nombre_producto.Trim().ToUpper(),
                };
                SqlCmd.Parameters.Add(Nombre_producto);
                contador += 1;

                SqlParameter Descripcion_producto = new SqlParameter
                {
                    ParameterName = "@Descripcion_producto",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150,
                    Value = producto.Descripcion_producto.Trim().ToUpper(),
                };
                SqlCmd.Parameters.Add(Descripcion_producto);
                contador += 1;

                SqlParameter Estado_producto = new SqlParameter
                {
                    ParameterName = "@Estado_producto",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = producto.Estado_producto.Trim().ToUpper(),
                };
                SqlCmd.Parameters.Add(Estado_producto);
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
                    id_tipo_producto = Convert.ToInt32(SqlCmd.Parameters["@Id_tipo_producto"].Value);
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
        public string EditarTipoProductos(int id_tipo_producto, Tipo_productos producto)
        {
            int contador = 0;
            string rpta = "";

            string consulta = "UPDATE Tipo_productos SET " +
                "Nombre_producto = @Nombre_producto, " +
                "Descripcion_producto = @Descripcion_producto, " +
                "Estado_producto = @Estado_producto " +
                "WHERE Id_tipo_producto = @Id_tipo_producto ";

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

                SqlParameter Id_tipo_producto = new SqlParameter
                {
                    ParameterName = "@Id_tipo_producto",
                    SqlDbType = SqlDbType.Int,
                    Value = id_tipo_producto,
                };
                SqlCmd.Parameters.Add(Id_tipo_producto);

                SqlParameter Nombre_producto = new SqlParameter
                {
                    ParameterName = "@Nombre_producto",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = producto.Nombre_producto.Trim().ToUpper(),
                };
                SqlCmd.Parameters.Add(Nombre_producto);
                contador += 1;

                SqlParameter Descripcion_producto = new SqlParameter
                {
                    ParameterName = "@Descripcion_producto",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150,
                    Value = producto.Descripcion_producto.Trim().ToUpper(),
                };
                SqlCmd.Parameters.Add(Descripcion_producto);
                contador += 1;

                SqlParameter Estado_producto = new SqlParameter
                {
                    ParameterName = "@Estado_producto",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = producto.Estado_producto.Trim().ToUpper(),
                };
                SqlCmd.Parameters.Add(Estado_producto);
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

        #region METODO BUSCAR TIPOS
        public DataTable BuscarTiposProductos(string tipo_busqueda, string texto_busqueda, out string rpta)
        {
            rpta = "OK";

            StringBuilder consulta = new StringBuilder();

            consulta.Append("SELECT * FROM Tipo_productos pr ");

            if (tipo_busqueda.Equals("ID PRODUCTO"))
            {
                consulta.Append("WHERE pr.Id_tipo_producto= @Texto_busqueda ");
            }

            consulta.Append("ORDER BY pr.Id_tipo_producto DESC");

            DataTable DtResultado = new DataTable("TiposProducto");
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
