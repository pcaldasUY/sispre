using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace AccesoDatos
{
    public class AProveedor
    {
        public int Agregar(Proveedor prov)
        {
            int afectados = -1;

            SqlConnection cnn = new SqlConnection(Conexion.conn);
            SqlCommand cmd = new SqlCommand("AgregarProveedor", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", prov.Id));
            cmd.Parameters.Add(new SqlParameter("@Nombre", prov.Nombre));

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

        public static List<Proveedor> ListarTodos()
        {
            Proveedor p = null;
            List<Proveedor> lista = new List<Proveedor>();
            int id = 0;
            string nombre = "";

            SqlConnection cnn = new SqlConnection(Conexion.conn);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Proveedores", cnn);
            cmd.CommandType = CommandType.Text;
            cnn.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                id = (int)dr["id"];
                nombre = dr["nombre"].ToString();
                p = new Proveedor(id, nombre);
                lista.Add(p);
            }
            return lista;
        }
    }
}
