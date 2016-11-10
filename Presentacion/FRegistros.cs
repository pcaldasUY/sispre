using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using LogicaNegocio;

namespace Presentacion
{
    public partial class frmRegistros : Form
    {
        List<Registro> lista = new List<Registro>();
        public frmRegistros()
        {
            InitializeComponent();
        }

        private void frmRegistros_Load(object sender, EventArgs e)
        {
            DataTable dt = LProducto.ListarTotos();
            cboProducto.DataSource = dt;
            cboProducto.DisplayMember = "descripcion";
            cboProducto.ValueMember = "codigo";

            txtCodigo.Text = cboProducto.SelectedValue.ToString();

            List<Proveedor> lista = LProveedor.ListarTodos();
            cboProveedor.DataSource = lista;
            cboProveedor.DisplayMember = "nombre";
            cboProveedor.ValueMember = "id";

            txtId.Text = cboProveedor.SelectedValue.ToString();

            txtFecha.Text = DateTime.Today.ToShortDateString();


        }

        private void cboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCodigo.Text = cboProducto.SelectedValue.ToString();
        }

        private void cboProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtId.Text = cboProveedor.SelectedValue.ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string cod = txtCodigo.Text;
            int idProv = Convert.ToInt32(txtId.Text);
            DateTime fecha = Convert.ToDateTime(txtFecha.Text);
            double pre = Convert.ToDouble(txtPrecio.Text);
            int cant = 0;
            if(!int.TryParse(txtCantidad.Text, out cant))
            {
                errorProvider1.SetError(txtCantidad, "Ingrese un numero válido");
            }
            cant = Convert.ToInt32(txtCantidad.Text);

            Producto prod = null;
            Proveedor prov = null;
            

            prod = new Producto(cod, cboProducto.SelectedText);
            prov = new Proveedor(idProv, cboProveedor.SelectedText);

            lista.Add(new Registro(prod, prov, fecha, pre, cant));
            
            dgvLista.DataSource = lista;

        }
    }
}
