
namespace Entidades
{
    public class Producto
    {
        string codigo;
        string descripcion;

        public string Codigo
        {
            set { codigo = value; }
            get { return codigo;  }
        }

        public string Descripcion
        {
            set { descripcion = value; }
            get { return descripcion; }
        }

        public Producto()
        { }

        public Producto(string codigo, string descr)
        {
            this.codigo = codigo;
            this.descripcion = descr;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
