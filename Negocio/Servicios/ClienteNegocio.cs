using Datos.Repositorio;
using Entidad.Models;

namespace Negocio.Servicios
{
    // ==============================
    // CAPA DE NEGOCIO PARA CLIENTES
    // Esta clase encapsula la lógica de negocio relacionada con
    // los clientes, usando la capa de datos ClienteDatos.
    // ==============================
    public class ClienteNegocio
    {
        // Instancia de la clase de datos para interactuar con la BD
        private readonly ClienteDatos _clienteDatos;

        // Constructor: inicializa la instancia de ClienteDatos
        public ClienteNegocio()
        {
            _clienteDatos = new ClienteDatos();
        }

        // ==============================
        // LISTAR CLIENTES
        // Devuelve todos los clientes registrados
        // ==============================
        public List<Cliente> ListarClientes()
        {
            return _clienteDatos.Listar();
        }

        // ==============================
        // OBTENER CLIENTE POR ID
        // Devuelve un cliente específico según su ID.
        // Retorna null si no existe.
        // ==============================
        public Cliente? ObtenerPorId(int id)
        {
            return _clienteDatos.ObtenerPorId(id);
        }

        // Alias de ObtenerPorId, para mayor claridad semántica
        public Cliente? ObtenerClientePorId(int id)
        {
            return ObtenerPorId(id);
        }

        // ==============================
        // REGISTRAR CLIENTE
        // Valida los campos obligatorios antes de enviar a la capa de datos
        // Lanza ArgumentException si algún campo obligatorio está vacío
        // ==============================
        public bool RegistrarCliente(Cliente cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.Nombre))
                throw new ArgumentException("El nombre del cliente es obligatorio.");

            if (string.IsNullOrWhiteSpace(cliente.Username))
                throw new ArgumentException("El nombre de usuario es obligatorio.");

            if (string.IsNullOrWhiteSpace(cliente.PasswordHash))
                throw new ArgumentException("La contraseña es obligatoria.");

            // Llama al método Registrar de la capa de datos
            return _clienteDatos.Registrar(cliente);
        }

        // ==============================
        // ACTUALIZAR CLIENTE
        // Valida que el ClienteId sea válido antes de actualizar
        // ==============================
        public bool ActualizarCliente(Cliente cliente)
        {
            if (cliente.ClienteId <= 0)
                throw new ArgumentException("ID de cliente no válido.");

            return _clienteDatos.Actualizar(cliente);
        }

        // ==============================
        // ELIMINAR CLIENTE
        // Valida que el ID proporcionado sea válido
        // ==============================
        public bool EliminarCliente(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID de cliente no válido.");

            return _clienteDatos.Eliminar(id);
        }
    }
}
