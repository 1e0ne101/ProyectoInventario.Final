using System;

namespace SistemaInventario
{
    public class FormularioProductos
    {
        public Producto RegistrarProducto(string idTexto, string nombre, string precioTexto, string cantidadTexto, string categoria)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("❌ El nombre no puede estar vacío.");
                return null;
            }
            if (string.IsNullOrWhiteSpace(categoria))
            {
                Console.WriteLine("❌ La categoría no puede estar vacía.");
                return null;
            }
            if (!int.TryParse(idTexto, out int id))
            {
                Console.WriteLine("❌ El ID debe ser un número válido.");
                return null;
            }
            if (!decimal.TryParse(precioTexto, out decimal precio) || precio <= 0)
            {
                Console.WriteLine("❌ El precio debe ser mayor a cero.");
                return null;
            }
            if (!int.TryParse(cantidadTexto, out int cantidad) || cantidad < 0)
            {
                Console.WriteLine("❌ La cantidad no puede ser negativa.");
                return null;
            }

            Console.WriteLine("✅ ¡Producto registrado correctamente!");
            return new Producto(id, nombre, precio, cantidad, categoria);
        }
    }
}