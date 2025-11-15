// Espacios de nombres importados para trabajar con la base de datos, modelos y repositorios
using Datos.Database;       // Contiene la conexión a la base de datos
using Datos.Repositorio;    // Contiene la lógica de acceso a los datos
using Entidad.Models;       // Contiene los modelos de entidades (Venta, DetalleVenta, etc.)
using Microsoft.Data.SqlClient; // Cliente para SQL Server

namespace Negocio.Servicios
{
    // Clase de negocio que maneja la lógica de ventas
    public class VentaNegocio
    {
        // Objeto de acceso a datos de ventas
        private readonly VentaDatos _ventaDatos;

        // Constructor que inicializa la instancia de VentaDatos
        public VentaNegocio()
        {
            _ventaDatos = new VentaDatos();
        }

        // Método para registrar una venta usando un procedimiento almacenado
        // Devuelve un tuple con el ID de la venta y un mensaje
        public (int ventaId, string mensaje) RegistrarVenta(int userId, int clienteId, decimal total, List<DetalleVenta> detalles)
        {
            // Validaciones básicas antes de registrar la venta
            if (clienteId <= 0)
                throw new ArgumentException("Debe seleccionar un cliente válido.");
            if (userId <= 0)
                throw new ArgumentException("Debe seleccionar un usuario válido.");
            if (detalles.Count == 0)
                throw new ArgumentException("Debe haber al menos un producto en la venta.");

            // Llama al método de datos para registrar la venta
            return _ventaDatos.RegistrarVenta(userId, clienteId, total, detalles);
        }

        // Método para listar todas las ventas
        public List<Venta> ListarVentas()
        {
            return _ventaDatos.ListarVentas();
        }

        // Método para listar compras filtradas por cliente
        public List<dynamic> ListarComprasPorCliente(int clienteId)
        {
            if (clienteId <= 0)
                throw new ArgumentException("ID de cliente inválido.");

            return _ventaDatos.ListarComprasPorCliente(clienteId);
        }

        // Método para listar ventas filtradas por vendedor
        public List<dynamic> ListarVentasPorVendedor(int vendedorUserId)
        {
            var lista = new List<dynamic>();

            // Usando conexión a la base de datos
            using (var conn = ConexionBD.Instance.GetConnection())
            {
                conn.Open(); // Abrir la conexión
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT v.VentaId, v.Fecha, v.Total, c.Nombre AS Cliente, u.NombreCompleto AS Vendedor
                    FROM Ventas v
                    INNER JOIN Clientes c ON v.ClienteId = c.ClienteId
                    INNER JOIN Usuarios u ON v.UserId = u.UserId
                    WHERE v.UserId = @vendedorUserId AND u.RoleId = 2
                    ORDER BY v.Fecha DESC
                ", conn))
                {
                    // Parámetro para filtrar por vendedor
                    cmd.Parameters.Add("@vendedorUserId", System.Data.SqlDbType.Int).Value = vendedorUserId;

                    // Ejecutar lector de datos
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // Añadir cada registro a la lista de forma dinámica
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

            return lista; // Retornar lista con las ventas del vendedor
        }
    }
}
