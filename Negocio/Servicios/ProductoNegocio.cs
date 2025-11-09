using Datos.Database;
using Datos.Repositorio;
using Entidad.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Servicios
{
    public class ProductoNegocio
    {
        private readonly ProductoDatos _productoDatos;

        public ProductoNegocio()
        {
            _productoDatos = new ProductoDatos();
        }

        // Listar todos los productos
        public List<Producto> ListarProductos()
        {
            return _productoDatos.Listar();
        }

        // Obtener producto por ID
        public Producto? ObtenerPorId(int id)
        {
            return _productoDatos.ObtenerPorId(id);
        }

        // Registrar nuevo producto
        public bool RegistrarProducto(Producto producto)
        {
            if (string.IsNullOrWhiteSpace(producto.Nombre))
                throw new ArgumentException("El nombre del producto es obligatorio.");

            if (producto.Precio <= 0)
                throw new ArgumentException("El precio debe ser mayor que 0.");

            return _productoDatos.Registrar(producto);
        }

        // Actualizar producto
        public bool ActualizarProducto(Producto producto)
        {
            if (producto.ProductoId <= 0)
                throw new ArgumentException("ID de producto no válido.");

            return _productoDatos.Actualizar(producto);
        }

        // Eliminar producto
        public bool EliminarProducto(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID de producto no válido.");

            return _productoDatos.Eliminar(id);
        }
    }
}