using System;
using System.Windows.Forms;
using Entidades;
using LogicaNegocio;

namespace Presentacion
{
    public partial class frmProveedores : Form
    {
        public frmProveedores()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            bool retorno;
            string error = "";
            string mensaje = "";
            
            string nombre = txtNombre.Text; ;

            if (nombre == "")
            {
                error = "Nombre inválido o vacío.";
            }

            if (error == "")
            {
                Proveedor prov = new Proveedor();
                prov.Nombre = nombre;
                
                retorno = LogicaProveedor.Agregar(prov);

                if (retorno)
                {

                    txtNombre.Text = "";
                }
                else
                {
                    mensaje = "Este Proveedor ya existe.";
                    MessageBox.Show(mensaje);
                }
            }
            else
            {
                MessageBox.Show(error);
                error = "";
            }
            txtNombre.Focus();
        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {

            txtNombre.Focus();
        }
    }
}
