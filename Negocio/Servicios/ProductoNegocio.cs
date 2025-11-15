using Datos.Repositorio;
using Entidad.Models;

namespace Negocio.Servicios
{
    // ==============================
    // CAPA DE NEGOCIO PARA PRODUCTOS
    // Encapsula la lógica de negocio relacionada con productos
    // usando la capa de datos ProductoDatos.
    // ==============================
    public class ProductoNegocio
    {
        // Instancia de la clase de datos para interactuar con la BD
        private readonly ProductoDatos _productoDatos;

        // Constructor: inicializa la instancia de ProductoDatos
        public ProductoNegocio()
        {
            _productoDatos = new ProductoDatos();
        }

        // ==============================
        // LISTAR PRODUCTOS
        // Devuelve todos los productos registrados en la base de datos
        // ==============================
        public List<Producto> ListarProductos()
        {
            return _productoDatos.Listar();
        }

        // ==============================
        // OBTENER PRODUCTO POR ID
        // Devuelve un producto específico según su ID.
        // Retorna null si no existe.
        // ==============================
        public Producto? ObtenerPorId(int id)
        {
            return _productoDatos.ObtenerPorId(id);
        }

        // ==============================
        // REGISTRAR NUEVO PRODUCTO
        // Valida los campos obligatorios antes de enviar a la capa de datos
        // Lanza ArgumentException si algún campo obligatorio no es válido
        // ==============================
        public bool RegistrarProducto(Producto producto)
        {
            if (string.IsNullOrWhiteSpace(producto.Nombre))
                throw new ArgumentException("El nombre del producto es obligatorio.");

            if (producto.Precio <= 0)
                throw new ArgumentException("El precio debe ser mayor que 0.");

            // Llama al método Registrar de la capa de datos
            return _productoDatos.Registrar(producto);
        }

        // ==============================
        // ACTUALIZAR PRODUCTO
        // Valida que el ProductoId sea válido antes de actualizar
        // ==============================
        public bool ActualizarProducto(Producto producto)
        {
            if (producto.ProductoId <= 0)
                throw new ArgumentException("ID de producto no válido.");

            return _productoDatos.Actualizar(producto);
        }

        // ==============================
        // ELIMINAR PRODUCTO
        // Valida que el ID proporcionado sea válido antes de eliminar
        // ==============================
        public bool EliminarProducto(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID de producto no válido.");

            return _productoDatos.Eliminar(id);
        }
    }
}
