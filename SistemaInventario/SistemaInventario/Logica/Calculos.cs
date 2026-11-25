namespace SistemaInventario
{
    /// <summary>
    /// Clase que contiene los cálculos matemáticos del inventario.
    /// </summary>
    public static class Calculos
    {
        // Calcula el valor total de todo el inventario (precio x cantidad de cada producto)
        public static decimal ValorTotalInventario()
        {
            decimal total = 0;

            foreach (Producto p in Inventario.Productos)
            {
                total += p.Precio * p.Cantidad;
            }

            return total;
        }

        // Cuenta cuántos productos tienen el stock bajo (cantidad igual o menor al mínimo)
        public static int ContarStockBajo(int minimo)
        {
            int contador = 0;

            foreach (Producto p in Inventario.Productos)
            {
                if (p.Cantidad <= minimo)
                {
                    contador++;
                }
            }

            return contador;
        }
    }
}