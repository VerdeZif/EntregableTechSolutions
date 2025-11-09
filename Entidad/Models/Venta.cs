using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad.Models
{
    public class Venta
    {
        public int VentaId { get; set; }
        public int ClienteId { get; set; }
        public int UserId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        // Datos adicionales para mostrar en reportes o interfaz
        public string? NombreCliente { get; set; }
        public string? NombreUsuario { get; set; }

        // Lista de detalles de la venta
        public List<DetalleVenta> Detalles { get; set; } = new();
    }
}
