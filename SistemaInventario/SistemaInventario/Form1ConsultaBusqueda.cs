using System;
using System.Data;
using System.Windows.Forms;

namespace SistemaInventario
{
    public partial class Form1 : Form
    {
        private DataTable tablaProductos = new DataTable();
        private DataView vistaProductos;

        public Form1()
        {
            InitializeComponent();
            CargarProductos();
        }

        private void CargarProductos()
        {
            tablaProductos = new DataTable();
            tablaProductos.Columns.Add("Id", typeof(int));
            tablaProductos.Columns.Add("Nombre", typeof(string));
            tablaProductos.Columns.Add("Stock", typeof(int));

            tablaProductos.Rows.Add(1, "Laptop", 10);
            tablaProductos.Rows.Add(2, "Mouse", 25);
            tablaProductos.Rows.Add(3, "Teclado", 15);

            vistaProductos = new DataView(tablaProductos);
            dgvResultados.DataSource = vistaProductos;
        }

        private void AplicarBusqueda()
        {
            if (vistaProductos == null) return;

            string texto = txtBuscar.Text.Trim().Replace("'", "''");
            vistaProductos.RowFilter = $"Nombre LIKE '%{texto}%'";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                MessageBox.Show("Ingrese el nombre del producto");
                txtBuscar.Focus();
                return;
            }

            AplicarBusqueda();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarProductos();
            MessageBox.Show("Datos actualizados correctamente.", "Inventario");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            if (vistaProductos != null)
            {
                vistaProductos.RowFilter = string.Empty;
            }
            txtBuscar.Focus();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            AplicarBusqueda();
        }

        

        }
    }
    
