using System;
using System.Windows.Forms;

namespace SistemaInventario
{
    /// <summary>
    /// Clase que contiene métodos para validar los datos ingresados por el usuario.
    /// </summary>
    public static class Validaciones
    {
        // Valida que un texto no esté vacío
        public static bool CampoVacio(string texto)
        {
            return string.IsNullOrWhiteSpace(texto);
        }

        // Valida que un texto sea un número decimal positivo (para precios)
        public static bool EsNumeroPositivo(string texto, out double valor)
        {
            valor = 0;
            if (!double.TryParse(texto, out valor)) return false;
            return valor >= 0;
        }

        // Valida que un texto sea un entero positivo (para stock)
        public static bool EsEnteroPositivo(string texto, out int valor)
        {
            valor = 0;
            if (!int.TryParse(texto, out valor)) return false;
            return valor >= 0;
        }

        // Muestra un mensaje de error estandarizado
        public static void MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Muestra un mensaje de éxito estandarizado
        public static void MostrarExito(string mensaje)
        {
            MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}