using System;
using System.Windows.Forms;
using Entidades;
using LogicaNegocio;

namespace Presentacion
{
    public partial class frmProductos : Form
    {
        public frmProductos()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            bool retorno;
            string error = "";
            string mensaje = "";
            string codigo = txtCodigo.Text;
            string desc = txtDescripcion.Text; ; 

            if(codigo == "")
            {
                error = "codigo inválido o vacío.";
            }
            if(desc == "")
            {
                error += "\ndescripción inválida o vacía.";
            }

            if (error == "")
            {
                Producto prod = new Producto();
                prod.Codigo = codigo;
                prod.Descripcion = desc;
                retorno = LogicaProducto.Agregar(prod);
                
                if (retorno)
                {
                    txtCodigo.Text = "";
                    txtDescripcion.Text = "";
                }
                else
                {
                    mensaje = "Este código de producto ya existe.";
                    MessageBox.Show(mensaje);
                }
            }
            else
            {
                MessageBox.Show(error);
                error = "";      
            }
            txtCodigo.Focus();
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            txtCodigo.Focus();
        }
    }
}
