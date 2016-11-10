using System.Data;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{
    public class LProducto
    {
        public static bool Agregar(Producto prod)
        {
            return AProducto.Agregar(prod) == 1;
        }

        public static bool Modificar(Producto prod)
        {
            return AProducto.Modificar(prod) == 1;
        }

        public static DataTable ListarTotos()
        {
            return AProducto.ListarTodos();
        }
    }
}
