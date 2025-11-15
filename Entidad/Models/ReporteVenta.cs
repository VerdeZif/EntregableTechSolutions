namespace Entidad.Models
{
    // ==============================
    // MODELO DE REPORTE DE VENTAS
    // Esta clase se utiliza para generar reportes de ventas
    // en distintas consultas y reportes del sistema
    // ==============================
    public class ReporteVenta
    {
        // ==============================
        // Campos para reporte general de ventas
        // ==============================
        public int VentaId { get; set; }            // ID de la venta
        public DateTime Fecha { get; set; }         // Fecha en que se realizó la venta
        public string Cliente { get; set; } = string.Empty; // Nombre del cliente
        public string Usuario { get; set; } = string.Empty; // Nombre del usuario o vendedor que realizó la venta
        public decimal Total { get; set; }          // Total de la venta

        // ==============================
        // Campos para reportes de productos más vendidos
        // ==============================
        public string? Producto { get; set; }       // Nombre del producto
        public int? CantidadVendida { get; set; }   // Cantidad vendida de ese producto
        public decimal? TotalRecaudado { get; set; } // Total recaudado por ese producto

        // ==============================
        // Campos para reportes de ventas por usuario
        // ==============================
        public int? TotalVentas { get; set; }       // Número total de ventas realizadas por un usuario
    }
}
