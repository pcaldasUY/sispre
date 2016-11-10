using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using LogicaNegocio;
using Entidades;

namespace Presentacion
{
    public partial class FProductos : Form
    {
        public FProductos()
        {
            InitializeComponent();
        }

        private void FProductos_Load(object sender, EventArgs e)
        {
            txtCodigo.Focus();
            DataTable dt = LProducto.ListarTotos();
            dgvLista.DataSource = dt;
            dgvLista.Columns[0].HeaderText = "Código";
            dgvLista.Columns[1].HeaderText = "Descripción";
            dgvLista.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string cod = txtCodigo.Text;
            string desc = txtDescripcion.Text;
            bool agrego;

            Producto prod = new Producto(cod, desc);

            try
            {
                agrego = LProducto.Agregar(prod);
                if (agrego)
                {
                    MessageBox.Show("Agregado con éxito!");
                    txtCodigo.Text = "";
                    txtDescripcion.Text = "";
                    txtCodigo.Focus();
                }
                else
                {
                    MessageBox.Show("El registro ya existe!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
