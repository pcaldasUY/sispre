using System.Configuration;

namespace AccesoDatos
{
    public class Conexion
    {
        public static string conn = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
    }
}
