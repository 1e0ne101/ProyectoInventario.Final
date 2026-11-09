using System;

namespace SistemaInventario
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public string Categoria { get; set; }

        public Producto(int id, string nombre, decimal precio, int cantidad, string categoria)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
            Cantidad = cantidad;
            Categoria = categoria;
        }
    }
}