namespace Entidad.Models
{
    // ==============================
    // MODELO DE DETALLE DE VENTA
    // Representa cada línea o ítem dentro de una venta
    // ==============================
    public class DetalleVenta
    {
        // Identificador único del detalle de venta
        public int DetalleId { get; set; }

        // Identificador de la venta a la que pertenece este detalle
        public int VentaId { get; set; }

        // Identificador del producto vendido
        public int ProductoId { get; set; }

        // Cantidad vendida de este producto
        public int Cantidad { get; set; }

        // Precio unitario del producto en la venta
        public decimal PrecioUnitario { get; set; }

        // Nombre del producto (útil para mostrar en reportes o vistas)
        public string? NombreProducto { get; set; }

        // Calcula automáticamente el subtotal de este detalle (Cantidad * PrecioUnitario)
        public decimal Subtotal => Cantidad * PrecioUnitario;

        // ==============================
        // PROPIEDADES ADICIONALES PARA REPORTES
        // No requieren cambios en la base de datos, solo para mostrar info
        // ==============================

        // Fecha en que se realizó la venta
        public DateTime FechaVenta { get; set; }

        // Nombre del cliente que realizó la compra
        public string NombreCliente { get; set; } = string.Empty;

        // Nombre del usuario/vendedor que registró la venta
        public string NombreUsuario { get; set; } = string.Empty;

        // Total de la venta completa (suma de todos los detalles)
        public decimal TotalVenta { get; set; }

        // Descripción adicional del producto (opcional)
        public string? Descripcion { get; set; }
    }
}
