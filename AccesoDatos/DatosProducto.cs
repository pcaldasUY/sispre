using System;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace AccesoDatos
{
    public class DatosProducto
    {
        public static int Agregar(Producto prod)
        {
            int agrego = -1;

            SqlConnection cnn = new SqlConnection(Conexion.conn);

            SqlCommand cmd = new SqlCommand("AgregarProducto", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("retorno", SqlDbType.Int);
            param.Direction = ParameterDirection.ReturnValue;

            cmd.Parameters.Add(param);
            cmd.Parameters.AddWithValue("@codigo", prod.Codigo);
            cmd.Parameters.AddWithValue("@desc", prod.Descripcion);

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
