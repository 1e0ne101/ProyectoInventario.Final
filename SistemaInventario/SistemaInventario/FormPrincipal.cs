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

            // Botón para modificar productos y registrar entradas/salidas.
            // Se crea por código para no tener que editar el Designer.
            Button btnGestion = new Button();
            btnGestion.Font = btnConsulta.Font;
            btnGestion.Text = "Modificar / Existencias";
            btnGestion.Location = new System.Drawing.Point(460, 110);
            btnGestion.Size = new System.Drawing.Size(180, 45);
            btnGestion.UseVisualStyleBackColor = true;
            btnGestion.Click += btnGestion_Click;
            Controls.Add(btnGestion);
        }

        // Al abrir el formulario se muestra el resumen inicial.
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            ActualizarResumen();
        }

        // ---------- NAVEGACIÓN ----------

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            using (FrmRegistro frm = new FrmRegistro())
            {
                frm.ShowDialog(this);   // abre el formulario como ventana modal
            }

            // Al volver, el inventario pudo cambiar: se refresca el resumen.
            ActualizarResumen();
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            using (Form1 frm = new Form1())
            {
                frm.ShowDialog(this);
            }

            ActualizarResumen();
        }

        private void btnGestion_Click(object sender, EventArgs e)
        {
            using (FrmGestion frm = new FrmGestion())
            {
                frm.ShowDialog(this);
            }

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

            foreach (Producto p in Inventario.Productos)        // significa “para cada ficha de la lista, llámala p y haz lo que está entre llaves”.
            {
                totalProductos++;          //suma 1 al contador por cada producto
                stockTotal += p.Cantidad;  //suma las unidades de ese producto al total

                if (p.Cantidad <= StockMinimo)   // pregunta si quedan 5 o menos unidades. StockMinimo es la constante de arriba del archivo.
                {
                    lstStockBajo.Items.Add(p.Nombre + " (" + p.Cantidad + ")");  //agrega el nombre a la lista de stock bajo, por ejemplo Clavos (3)
                }
            }

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
                e.Cancel = true;      // cancela el cierre y la ventana sigue abierta
            }
        }
    }
}