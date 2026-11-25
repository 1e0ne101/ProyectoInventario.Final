using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaInventario
{
    /// <summary>
    /// Formulario para modificar y eliminar productos y para registrar
    /// entradas y salidas de existencias. Construye sus controles por código
    /// (no necesita Designer) y trabaja sobre Inventario.Productos.
    /// </summary>
    public class FrmGestion : Form
    {
        private DataGridView dgvProductos;
        private TextBox txtNombre;
        private TextBox txtCategoria;
        private TextBox txtProveedor;
        private TextBox txtPrecio;
        private TextBox txtMovimiento;

        public FrmGestion()
        {
            Text = "Modificar productos y existencias";
            ClientSize = new Size(760, 565);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            Label titulo = new Label();
            titulo.Text = "MODIFICAR PRODUCTOS Y EXISTENCIAS";
            titulo.Font = new Font("Arial", 14F, FontStyle.Bold);
            titulo.AutoSize = true;
            titulo.Location = new Point(20, 12);
            Controls.Add(titulo);

            // ----- Tabla de productos -----
            dgvProductos = new DataGridView();
            dgvProductos.Location = new Point(20, 50);
            dgvProductos.Size = new Size(720, 230);
            dgvProductos.ReadOnly = true;
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.MultiSelect = false;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.SelectionChanged += dgvProductos_SelectionChanged;
            Controls.Add(dgvProductos);

            // ----- Grupo: editar producto seleccionado -----
            GroupBox grpEditar = new GroupBox();
            grpEditar.Text = "Editar producto seleccionado";
            grpEditar.Location = new Point(20, 295);
            grpEditar.Size = new Size(440, 205);
            Controls.Add(grpEditar);

            txtNombre = AgregarCampo(grpEditar, "Nombre:", 28);
            txtCategoria = AgregarCampo(grpEditar, "Categoría:", 62);
            txtProveedor = AgregarCampo(grpEditar, "Proveedor:", 96);
            txtPrecio = AgregarCampo(grpEditar, "Precio:", 130);

            Button btnGuardar = new Button();
            btnGuardar.Text = "Guardar cambios";
            btnGuardar.Location = new Point(110, 163);
            btnGuardar.Size = new Size(140, 30);
            btnGuardar.Click += btnGuardar_Click;
            grpEditar.Controls.Add(btnGuardar);

            Button btnEliminar = new Button();
            btnEliminar.Text = "Eliminar";
            btnEliminar.Location = new Point(265, 163);
            btnEliminar.Size = new Size(120, 30);
            btnEliminar.Click += btnEliminar_Click;
            grpEditar.Controls.Add(btnEliminar);

            // ----- Grupo: entradas y salidas -----
            GroupBox grpExistencias = new GroupBox();
            grpExistencias.Text = "Existencias (entradas y salidas)";
            grpExistencias.Location = new Point(480, 295);
            grpExistencias.Size = new Size(260, 205);
            Controls.Add(grpExistencias);

            Label lblAyuda = new Label();
            lblAyuda.Text = "Seleccione un producto en la tabla\ny escriba la cantidad.";
            lblAyuda.AutoSize = true;
            lblAyuda.Location = new Point(15, 28);
            grpExistencias.Controls.Add(lblAyuda);

            Label lblCantidad = new Label();
            lblCantidad.Text = "Cantidad:";
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(15, 80);
            grpExistencias.Controls.Add(lblCantidad);

            txtMovimiento = new TextBox();
            txtMovimiento.Location = new Point(90, 76);
            txtMovimiento.Size = new Size(150, 23);
            grpExistencias.Controls.Add(txtMovimiento);

            Button btnEntrada = new Button();
            btnEntrada.Text = "Entrada (+)";
            btnEntrada.Location = new Point(15, 120);
            btnEntrada.Size = new Size(110, 32);
            btnEntrada.Click += (s, e) => RegistrarMovimiento(true);
            grpExistencias.Controls.Add(btnEntrada);

            Button btnSalida = new Button();
            btnSalida.Text = "Salida (-)";
            btnSalida.Location = new Point(135, 120);
            btnSalida.Size = new Size(105, 32);
            btnSalida.Click += (s, e) => RegistrarMovimiento(false);
            grpExistencias.Controls.Add(btnSalida);

            // ----- Cerrar -----
            Button btnCerrar = new Button();
            btnCerrar.Text = "Cerrar";
            btnCerrar.Location = new Point(640, 515);
            btnCerrar.Size = new Size(100, 30);
            btnCerrar.Click += (s, e) => Close();
            Controls.Add(btnCerrar);
            CancelButton = btnCerrar;

            CargarTabla(0);
        }

        // Crea una etiqueta y una caja de texto dentro de un contenedor
        private TextBox AgregarCampo(Control contenedor, string etiqueta, int y)
        {
            Label lbl = new Label();
            lbl.Text = etiqueta;
            lbl.AutoSize = true;
            lbl.Location = new Point(15, y + 4);
            contenedor.Controls.Add(lbl);

            TextBox caja = new TextBox();
            caja.Location = new Point(110, y);
            caja.Size = new Size(310, 23);
            contenedor.Controls.Add(caja);

            return caja;
        }

        // Llena la tabla con Inventario.Productos y vuelve a seleccionar el producto indicado
        private void CargarTabla(int idSeleccionar)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("Id", typeof(int));
            tabla.Columns.Add("Nombre", typeof(string));
            tabla.Columns.Add("Categoría", typeof(string));
            tabla.Columns.Add("Proveedor", typeof(string));
            tabla.Columns.Add("Precio", typeof(decimal));
            tabla.Columns.Add("Cantidad", typeof(int));

            foreach (Producto p in Inventario.Productos)
            {
                tabla.Rows.Add(p.Id, p.Nombre, p.Categoria, p.Proveedor, p.Precio, p.Cantidad);
            }

            dgvProductos.DataSource = tabla;

            if (idSeleccionar != 0)
            {
                foreach (DataGridViewRow fila in dgvProductos.Rows)
                {
                    if ((int)fila.Cells["Id"].Value == idSeleccionar)
                    {
                        fila.Selected = true;
                        dgvProductos.CurrentCell = fila.Cells["Nombre"];
                        break;
                    }
                }
            }

            MostrarSeleccionado();
        }

        // Devuelve el Producto de la lista que corresponde a la fila seleccionada (o null)
        private Producto ObtenerSeleccionado()
        {
            if (dgvProductos.CurrentRow == null)
            {
                return null;
            }

            int id = (int)dgvProductos.CurrentRow.Cells["Id"].Value;

            foreach (Producto p in Inventario.Productos)
            {
                if (p.Id == id)
                {
                    return p;
                }
            }

            return null;
        }

        // Copia los datos del producto seleccionado a las cajas de edición
        private void MostrarSeleccionado()
        {
            Producto p = ObtenerSeleccionado();

            if (p == null)
            {
                txtNombre.Clear();
                txtCategoria.Clear();
                txtProveedor.Clear();
                txtPrecio.Clear();
                return;
            }

            txtNombre.Text = p.Nombre;
            txtCategoria.Text = p.Categoria;
            txtProveedor.Text = p.Proveedor;
            txtPrecio.Text = p.Precio.ToString();
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            MostrarSeleccionado();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Producto p = ObtenerSeleccionado();
            if (p == null)
            {
                Validaciones.MostrarError("Seleccione un producto de la tabla.");
                return;
            }

            if (Validaciones.CampoVacio(txtNombre.Text))
            {
                Validaciones.MostrarError("Ingrese el nombre del producto.");
                txtNombre.Focus();
                return;
            }

            if (Validaciones.CampoVacio(txtCategoria.Text))
            {
                Validaciones.MostrarError("Ingrese la categoría.");
                txtCategoria.Focus();
                return;
            }

            if (Validaciones.CampoVacio(txtProveedor.Text))
            {
                Validaciones.MostrarError("Ingrese el proveedor.");
                txtProveedor.Focus();
                return;
            }

            double precio;
            if (!Validaciones.EsNumeroPositivo(txtPrecio.Text, out precio) || precio <= 0)
            {
                Validaciones.MostrarError("El precio debe ser un número mayor a cero.");
                txtPrecio.Focus();
                return;
            }

            p.Nombre = txtNombre.Text.Trim();
            p.Categoria = txtCategoria.Text.Trim();
            p.Proveedor = txtProveedor.Text.Trim();
            p.Precio = (decimal)precio;

            CargarTabla(p.Id);
            Validaciones.MostrarExito("Producto modificado correctamente.");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Producto p = ObtenerSeleccionado();
            if (p == null)
            {
                Validaciones.MostrarError("Seleccione un producto de la tabla.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Desea eliminar el producto \"" + p.Nombre + "\"?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                Inventario.Productos.Remove(p);
                CargarTabla(0);
                Validaciones.MostrarExito("Producto eliminado correctamente.");
            }
        }

        // Entrada suma unidades; salida resta (sin permitir quedar en negativo)
        private void RegistrarMovimiento(bool esEntrada)
        {
            Producto p = ObtenerSeleccionado();
            if (p == null)
            {
                Validaciones.MostrarError("Seleccione un producto de la tabla.");
                return;
            }

            int cantidad;
            if (!Validaciones.EsEnteroPositivo(txtMovimiento.Text, out cantidad) || cantidad <= 0)
            {
                Validaciones.MostrarError("La cantidad debe ser un número entero mayor a cero.");
                txtMovimiento.Focus();
                return;
            }

            if (esEntrada)
            {
                p.Cantidad += cantidad;
            }
            else
            {
                if (cantidad > p.Cantidad)
                {
                    Validaciones.MostrarError("No hay suficiente stock. Disponible: " + p.Cantidad);
                    return;
                }
                p.Cantidad -= cantidad;
            }

            txtMovimiento.Clear();
            CargarTabla(p.Id);
            Validaciones.MostrarExito("Existencias actualizadas. Cantidad actual: " + p.Cantidad);
        }
    }
}