using System;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace AccesoDatos
{
    public class ARegistro
    {
        public static int Agregar(Registro reg)
        {
            int afectados;
            SqlConnection cnn = new SqlConnection(Conexion.conn);
            SqlCommand cmd = new SqlCommand("AgregarNuevoPrecio", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@cod", reg.Prod.Codigo));
            cmd.Parameters.Add(new SqlParameter("@id", reg.Prov.Id));
            cmd.Parameters.Add(new SqlParameter("@fec", reg.Fecha));
            cmd.Parameters.Add(new SqlParameter("@pre", reg.Precio));
            cmd.Parameters.Add(new SqlParameter("@cant", reg.Cantidad));

            SqlParameter retorno = new SqlParameter("RetornoValor", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(retorno);

            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
                afectados = Convert.ToInt32(cmd.Parameters["RetornoValor"].Value);
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo ejecutar la consulta SQL!\n" + ex.Message);
            }
            finally
            {
                cnn.Close();
            }
            return afectados;
        }
    }
}
