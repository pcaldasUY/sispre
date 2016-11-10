using System.Data;
using AccesoDatos;
using Entidades;

namespace LogicaNegocio
{
    public class LRegistro
    {
        public static bool Agregar(Registro reg)
        {
            return ARegistro.Agregar(reg) == 1;
        }


    }
}
