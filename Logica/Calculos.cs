using ProyectoFinal_inventario_winforms.Datos;

namespace ProyectoFinal_inventario_winforms.Logica
{
    /// <summary>
    /// Clase que contiene los cálculos matemáticos del inventario.
    /// </summary>
    public static class Calculos
    {
        // Calcula el valor total de todo el inventario
        public static double ValorTotalInventario()
        {
            double total = 0;
            // Notita: Esto asume que el compañero ya creó la clase Inventario con la lista Productos!
            foreach (var p in Inventario.Productos)
            {
                total += p.Precio * p.Stock;
            }
            return total;
        }

        // Cuenta cuántos productos tienen el stock bajo
        public static int ContarStockBajo(int minimo)
        {
            int contador = 0;
            foreach (var p in Inventario.Productos)
            {
                if (p.Stock <= minimo)
                    contador++;
            }
            return contador;
        }
    }
}