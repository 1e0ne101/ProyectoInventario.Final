using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaInventario
{
    /// <summary>
    /// Formulario de registro de productos. Construye sus controles por código
    /// (no necesita Designer) y guarda en Inventario.Productos.
    /// </summary>
    public class FrmRegistro : Form
    {
        private TextBox txtNombre;
        private TextBox txtCategoria;
        private TextBox txtProveedor;
        private TextBox txtPrecio;
        private TextBox txtCantidad;

        public FrmRegistro()
        {
            Text = "Registro de Productos";
            ClientSize = new Size(380, 310);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            Label titulo = new Label();
            titulo.Text = "REGISTRAR PRODUCTO";
            titulo.Font = new Font("Arial", 14F, FontStyle.Bold);
            titulo.AutoSize = true;
            titulo.Location = new Point(20, 15);
            Controls.Add(titulo);

            txtNombre = AgregarCampo("Nombre:", 60);
            txtCategoria = AgregarCampo("Categoría:", 100);
            txtProveedor = AgregarCampo("Proveedor:", 140);
            txtPrecio = AgregarCampo("Precio:", 180);
            txtCantidad = AgregarCampo("Cantidad:", 220);

            Button btnGuardar = new Button();
            btnGuardar.Text = "Guardar";
            btnGuardar.Location = new Point(20, 265);
            btnGuardar.Size = new Size(100, 30);
            btnGuardar.Click += btnGuardar_Click;
            Controls.Add(btnGuardar);

            Button btnLimpiar = new Button();
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.Location = new Point(140, 265);
            btnLimpiar.Size = new Size(100, 30);
            btnLimpiar.Click += btnLimpiar_Click;
            Controls.Add(btnLimpiar);

            Button btnCerrar = new Button();
            btnCerrar.Text = "Cerrar";
            btnCerrar.Location = new Point(260, 265);
            btnCerrar.Size = new Size(100, 30);
            btnCerrar.Click += btnCerrar_Click;
            Controls.Add(btnCerrar);

            AcceptButton = btnGuardar;
            CancelButton = btnCerrar;
        }

        // Crea una etiqueta y una caja de texto en la posición vertical indicada
        private TextBox AgregarCampo(string etiqueta, int y)
        {
            Label lbl = new Label();
            lbl.Text = etiqueta;
            lbl.AutoSize = true;
            lbl.Location = new Point(20, y + 4);
            Controls.Add(lbl);

            TextBox caja = new TextBox();
            caja.Location = new Point(130, y);
            caja.Size = new Size(230, 23);
            Controls.Add(caja);

            return caja;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
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

            int cantidad;
            if (!Validaciones.EsEnteroPositivo(txtCantidad.Text, out cantidad))
            {
                Validaciones.MostrarError("La cantidad debe ser un número entero, cero o mayor.");
                txtCantidad.Focus();
                return;
            }

            Producto nuevo = new Producto(
                SiguienteId(),
                txtNombre.Text.Trim(),
                (decimal)precio,
                cantidad,
                txtCategoria.Text.Trim());
            nuevo.Proveedor = txtProveedor.Text.Trim();

            Inventario.Productos.Add(nuevo);

            Validaciones.MostrarExito("Producto registrado correctamente.");
            LimpiarCampos();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        // El Id se asigna solo: el más alto que exista + 1
        private int SiguienteId()
        {
            int mayor = 0;
            foreach (Producto p in Inventario.Productos)
            {
                if (p.Id > mayor)
                {
                    mayor = p.Id;
                }
            }
            return mayor + 1;
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtCategoria.Clear();
            txtProveedor.Clear();
            txtPrecio.Clear();
            txtCantidad.Clear();
            txtNombre.Focus();
        }
    }
}