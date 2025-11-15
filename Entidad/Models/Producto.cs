namespace Entidad.Models
{
    // ==============================
    // MODELO DE PRODUCTO
    // Representa un producto dentro del sistema
    // ==============================
    public class Producto
    {
        // Identificador único del producto
        public int ProductoId { get; set; }

        // Nombre del producto
        public string Nombre { get; set; } = string.Empty;

        // Descripción opcional del producto
        public string? Descripcion { get; set; }

        // Precio del producto
        public decimal Precio { get; set; }

        // Cantidad disponible en stock
        public int Stock { get; set; }

        // Imagen del producto (opcional, guardada como arreglo de bytes)
        public byte[]? Imagen { get; set; }
    }
}
