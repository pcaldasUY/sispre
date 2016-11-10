using System.Data;
using System.Collections.Generic;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{
    public class LProveedor
    {
        public static List<Proveedor> ListarTodos()
        {
            List<Proveedor> lista = AProveedor.ListarTodos();
            return lista;
        }
    }
}
