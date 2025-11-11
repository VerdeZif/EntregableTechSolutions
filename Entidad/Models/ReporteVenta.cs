namespace Entidad.Models
{
    public class ReporteVenta
    {
        // Para reporte general
        public int VentaId { get; set; }
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; } = string.Empty;
        public string Usuario { get; set; } = string.Empty;
        public decimal Total { get; set; }

        // Para productos más vendidos
        public string? Producto { get; set; }
        public int? CantidadVendida { get; set; }
        public decimal? TotalRecaudado { get; set; }

        // Para ventas por usuario
        public int? TotalVentas { get; set; }
    }
}
