using System.Collections.Generic;  // avisamos a c#a vamos ausar listas

namespace SistemaInventario  // nombre del grupo al que pertenece la clase, mismo que usa Producto
{
    public static class Inventario  // static significa que existe una sola copia  para todo el programa, desde cualquier formulario escribimos Inventario.Productos
    {
        public static List<Producto> Productos = new List<Producto>();     // List<Producto> es una lista que solo acepta fichas de Producto. Los < > indican qué tipo de cosa guarda.
    }                                                                      // Productos es el nombre de la lista, el mismo que ya usa Calculos.cs y = new List<Producto>() crea la lista vacía, lista para recibir productos
}                                                                          /* Inventario.Productos.Add(unProducto);     para agregar
                                                                              int cuantos = Inventario.Productos.Count;  para contar */
