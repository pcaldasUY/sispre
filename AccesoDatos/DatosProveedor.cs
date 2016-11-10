using System;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace AccesoDatos
{
    public class DatosProveedor
    {
        public static int Agregar(Proveedor prov)
        {
            int agrego = -1;

            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = Conexion.conn;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "AgregarProveedor";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;

            SqlParameter param = new SqlParameter();
            param.ParameterName = "retorno";
            param.SqlDbType = SqlDbType.Int;
            param.Direction = ParameterDirection.ReturnValue;

            cmd.Parameters.Add(param);
            cmd.Parameters.AddWithValue("@nombre", prov.Nombre);

            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
                agrego = (int)cmd.Parameters["retorno"].Value;
            }
            catch (Exception ex)
            {
                throw new Exception("Exiten problemas con la info ingresada a la base de datos!!" + ex.Message);
            }
            finally
            {
                cnn.Close();
            }
            return agrego;
        }
    }
}
