namespace Entidad.Models
{
    // ==============================
    // MODELO DE VENTA
    // Representa una venta realizada en el sistema, incluyendo información
    // del cliente, usuario (vendedor), total y detalle de productos vendidos.
    // ==============================
    public class Venta
    {
        public int VentaId { get; set; }          // ID único de la venta en la base de datos
        public int ClienteId { get; set; }        // ID del cliente que realiza la compra
        public int UserId { get; set; }           // ID del usuario (vendedor) que registra la venta
        public DateTime Fecha { get; set; }       // Fecha y hora de la venta
        public decimal Total { get; set; }        // Total de la venta (suma de todos los detalles)

        // ==============================
        // DATOS ADICIONALES PARA REPORTES O INTERFAZ
        // ==============================
        public string? NombreCliente { get; set; } // Nombre del cliente (para mostrar en reportes)
        public string? NombreUsuario { get; set; } // Nombre del usuario/vendedor (para mostrar en reportes)

        // ==============================
        // DETALLES DE LA VENTA
        // Lista de productos y cantidades vendidas en esta venta
        // ==============================
        public List<DetalleVenta> Detalles { get; set; } = new(); // Inicializado vacío por defecto
    }
}
