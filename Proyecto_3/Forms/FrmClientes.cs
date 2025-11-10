using Entidad.Models;
using Negocio.Servicios;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Presentacion.Forms
{
    public partial class FrmClientes : Form
    {
        private readonly int _clienteId;
        private readonly ClienteNegocio _clienteNegocio;
        private readonly VentaNegocio _ventaNegocio;

        public FrmClientes(int clienteId)
        {
            InitializeComponent();
            _clienteId = clienteId;
            _clienteNegocio = new ClienteNegocio();
            _ventaNegocio = new VentaNegocio();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            CargarDatosCliente();
            CargarHistorialCompras();

            if (!string.IsNullOrEmpty(lblNombre.Text))
            {
                MessageBox.Show($"¡Bienvenido, {lblNombre.Text}!", "Bienvenida");
            }
        }

        private void CargarDatosCliente()
        {
            var cliente = _clienteNegocio.ObtenerClientePorId(_clienteId);

            if (cliente == null)
            {
                MessageBox.Show("No se pudieron cargar los datos del cliente.");
                return;
            }

            lblNombre.Text = cliente.Nombre;
            lblCorreo.Text = "Correo: " + cliente.Correo;
            lblTelefono.Text = "Teléfono: " + cliente.Telefono;
            lblDireccion.Text = "Dirección: " + cliente.Direccion;

            if (cliente.Foto != null && cliente.Foto.Length > 0)
            {
                using (var ms = new MemoryStream(cliente.Foto))
                {
                    pbFoto.Image = Image.FromStream(ms);
                }
            }
        }

        private void CargarHistorialCompras()
        {
            var compras = _ventaNegocio.ListarComprasPorCliente(_clienteId);
            dgvCompras.DataSource = compras;
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            new FrmLogin().Show();
            this.Close();
        }

        private void btnEditarDatos_Click(object sender, EventArgs e)
        {
            using (FrmEditarPerfilCliente editar = new FrmEditarPerfilCliente(_clienteId))
            {
                editar.ShowDialog();
                // Después de cerrar el formulario de edición, recarga los datos
                CargarDatosCliente();
            }
        }


        private void lblDireccion_Click(object sender, EventArgs e)
        {

        }

        private void lblCorreo_Click(object sender, EventArgs e)
        {

        }
    }
}
