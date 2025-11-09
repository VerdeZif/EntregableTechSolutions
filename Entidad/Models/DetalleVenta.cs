public class DetalleVenta
{
    public int DetalleId { get; set; }
    public int VentaId { get; set; }
    public int ProductoId { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public string? NombreProducto { get; set; }
    public decimal Subtotal => Cantidad * PrecioUnitario;

    // Propiedades adicionales para el reporte (no requieren cambios en DB)
    public DateTime FechaVenta { get; set; }
    public string NombreCliente { get; set; } = string.Empty;
    public decimal TotalVenta { get; set; }
}
