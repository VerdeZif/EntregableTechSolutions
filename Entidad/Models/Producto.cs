namespace Entidad.Models
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public byte[]? Imagen { get; set; }
    }
}
