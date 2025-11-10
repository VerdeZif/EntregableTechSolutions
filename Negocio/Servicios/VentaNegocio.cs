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

        // Listar compras por cliente
        public List<dynamic> ListarComprasPorCliente(int clienteId)
        {
            if (clienteId <= 0)
                throw new ArgumentException("ID de cliente inválido.");

            return _ventaDatos.ListarComprasPorCliente(clienteId);
        }

        public List<dynamic> ListarVentasPorVendedor(int vendedorUserId)
        {
            var lista = new List<dynamic>();

            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(@"
            SELECT v.VentaId, v.Fecha, v.Total, c.Nombre AS Cliente, u.NombreCompleto AS Vendedor
            FROM Ventas v
            INNER JOIN Clientes c ON v.ClienteId = c.ClienteId
            INNER JOIN Usuarios u ON v.UserId = u.UserId
            WHERE v.UserId = @vendedorUserId AND u.RoleId = 2
            ORDER BY v.Fecha DESC
        ", conn))
                {
                    cmd.Parameters.Add("@vendedorUserId", System.Data.SqlDbType.Int).Value = vendedorUserId;

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new
                            {
                                VentaId = Convert.ToInt32(dr["VentaId"]),
                                Fecha = Convert.ToDateTime(dr["Fecha"]).ToString("dd/MM/yyyy HH:mm"),
                                Total = Convert.ToDecimal(dr["Total"]),
                                Cliente = dr["Cliente"].ToString(),
                                Vendedor = dr["Vendedor"].ToString()
                            });
                        }
                    }
                }
            }

            return lista;
        }




    }
}