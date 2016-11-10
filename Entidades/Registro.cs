using System;

namespace Entidades
{
    public class Registro
    {
        #region Atributos
        Producto prod;
        Proveedor prov;
        DateTime fecha;
        double precio;
        int cantidad;
        #endregion

        #region Propiedades
        public Producto Prod
        {
            set { prod = value; }
            get { return prod; }
        }

        public Proveedor Prov
        {
            set { prov = value; }
            get { return prov; }
        }

        public DateTime Fecha
        {
            set { fecha = value; }
            get { return fecha; }
        }

        public double Precio
        {
            set { precio = value; }
            get { return precio; }
        }

        public int Cantidad
        {
            set { cantidad = value; }
            get { return cantidad; }
        }
        #endregion

        #region Contructores
        public Registro()
        { }

        public Registro(Producto prod, Proveedor prov, DateTime fec, double pre, int cant)
        {
            this.prod = prod;
            this.prov = prov;
            this.fecha = fec;
            this.precio = pre;
            this.cantidad = cant;
        }
        #endregion

        #region Metodos
        public override string ToString()
        {
            return base.ToString();
        }
        #endregion
    }
}
