using Datos.Database;
using Datos.Repositorio;
using Entidad.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Negocio.Servicios
{
    public class VentaNegocio
    {
        private readonly VentaDatos _ventaDatos;

        public VentaNegocio()
        {
            _ventaDatos = new VentaDatos();
        }

        // Registrar venta (usa el procedimiento almacenado)
        public (int ventaId, string mensaje) RegistrarVenta(int userId, int clienteId, decimal total, List<DetalleVenta> detalles)
        {
            if (clienteId <= 0)
                throw new ArgumentException("Debe seleccionar un cliente válido.");
            if (userId <= 0)
                throw new ArgumentException("Debe seleccionar un usuario válido.");
            if (detalles.Count == 0)
                throw new ArgumentException("Debe haber al menos un producto en la venta.");

            return _ventaDatos.RegistrarVenta(userId, clienteId, total, detalles);
        }

        // Listar todas las ventas
        public List<Venta> ListarVentas()
        {
            return _ventaDatos.ListarVentas();
        }
    }
}