
namespace Entidades
{
    public class Proveedor
    {
        int id;
        string nombre;

        public int Id
        {
            set { id = value; }
            get { return id; }
        }

        public string Nombre
        {
            set { nombre = value; }
            get { return nombre; }
        }

        public Proveedor()
        { }

        public Proveedor(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
