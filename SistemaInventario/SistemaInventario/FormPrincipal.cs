using System;
using System.Windows.Forms;

namespace SistemaInventario
{
    /// <summary>
    /// Formulario principal: navegación hacia los demás formularios,
    /// resumen del inventario y salida del programa.
    /// </summary>
    public partial class FormPrincipal : Form
    {
        // Cantidad a partir de la cual un producto se considera con stock bajo.
        // Ponerla aquí en una sola constante facilita cambiarla después.
        private const int StockMinimo = 5;

        public FormPrincipal()
        {
            InitializeComponent();
        }

        // Al abrir el formulario se muestra el resumen inicial.
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            ActualizarResumen();
        }

        // ---------- NAVEGACIÓN ----------

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            // TODO: descomentar cuando exista el formulario de la persona 2.
            // using (FrmRegistro frm = new FrmRegistro())
            // {
            //     frm.ShowDialog(this);   // abre el formulario como ventana modal
            // }
            MessageBox.Show("Formulario de registro pendiente.", "Información",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Al volver, el inventario pudo cambiar: se refresca el resumen.
            ActualizarResumen();
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            // TODO: descomentar cuando exista el formulario de la persona 3.
            // using (FrmConsulta frm = new FrmConsulta())
            // {
            //     frm.ShowDialog(this);
            // }
            MessageBox.Show("Formulario de consulta pendiente.", "Información",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            ActualizarResumen();
        }

        // ---------- RESUMEN ----------

        /// <summary>
        /// Recalcula y muestra el total de productos, el stock total
        /// y la lista de productos con stock bajo.
        /// </summary>
        private void ActualizarResumen()
        {
            int totalProductos = 0;
            int stockTotal = 0;
            lstStockBajo.Items.Clear();

            // TODO: conectar con la lista de productos del grupo (carpeta Datos).
            // Ajustar los nombres a los que use el grupo. Ejemplo de la idea:
            //
            // foreach (Producto p in Inventario.Productos)
            // {
            //     totalProductos++;
            //     stockTotal += p.Cantidad;
            //
            //     if (p.Cantidad <= StockMinimo)
            //     {
            //         lstStockBajo.Items.Add(p.Nombre + " (" + p.Cantidad + ")");
            //     }
            // }

            lblTotalProductos.Text = "Productos registrados: " + totalProductos;
            lblStockTotal.Text = "Unidades en stock: " + stockTotal;
            lblStockBajo.Text = "Productos con stock bajo: " + lstStockBajo.Items.Count;
        }

        // ---------- SALIDA ----------

        // El botón solo cierra el formulario; la confirmación se hace
        // en FormClosing para que también funcione con la X de la ventana.
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
                "¿Desea salir del sistema de inventario?",
                "Confirmar salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.No)
            {
                e.Cancel = true;   // cancela el cierre y la ventana sigue abierta
            }
        }
    }
}