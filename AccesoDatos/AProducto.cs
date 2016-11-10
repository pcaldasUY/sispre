using System;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace AccesoDatos
{
    public class AProducto
    {
        public static int Agregar(Producto prod)
        {
            int afectados = -1;

            SqlConnection cnn = new SqlConnection(Conexion.conn);
            SqlCommand cmd = new SqlCommand("AgregarProducto", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@codigo", prod.Codigo));
            cmd.Parameters.Add(new SqlParameter("@desc", prod.Descripcion));

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

        public static int Modificar(Producto prod)
        {
            int afectados = -1;

            SqlConnection cnn = new SqlConnection(Conexion.conn);
            SqlCommand cmd = new SqlCommand("ModificarProducto", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@cod", prod.Codigo));
            cmd.Parameters.Add(new SqlParameter("@desc", prod.Descripcion));

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

        public static DataTable ListarTodos()
        {
            SqlConnection cnn = new SqlConnection(Conexion.conn);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Productos", cnn);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataTable t = new DataTable();
            da.Fill(t);
            return t;
        }
    }
}
