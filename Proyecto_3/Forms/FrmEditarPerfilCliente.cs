using Entidad.Models;
using Negocio.Servicios;
using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Presentacion.Forms
{
    public partial class FrmEditarPerfilCliente : Form
    {
        private readonly int _clienteId;
        private readonly ClienteNegocio _clienteNegocio;
        private Cliente _cliente;

        public FrmEditarPerfilCliente(int clienteId)
        {
            InitializeComponent();
            _clienteId = clienteId;
            _clienteNegocio = new ClienteNegocio();
        }

        private void FrmEditarPerfilCliente_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            _cliente = _clienteNegocio.ObtenerClientePorId(_clienteId);
            if (_cliente == null)
            {
                MessageBox.Show("No se pudieron cargar los datos del cliente.");
                this.Close();
                return;
            }

            txtNombre.Text = _cliente.Nombre;
            txtCorreo.Text = _cliente.Correo;
            txtTelefono.Text = _cliente.Telefono;
            txtDireccion.Text = _cliente.Direccion;

            if (_cliente.Foto != null && _cliente.Foto.Length > 0)
            {
                using (var ms = new MemoryStream(_cliente.Foto))
                {
                    pbFoto.Image = Image.FromStream(ms);
                }
            }
        }

        private void btnSeleccionarFoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Imagenes|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pbFoto.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar campos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Validación");
                return;
            }

            // Validar correo
            if (!Regex.IsMatch(txtCorreo.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Ingrese un correo válido.", "Validación");
                return;
            }

            // Actualizar datos
            _cliente.Nombre = txtNombre.Text.Trim();
            _cliente.Correo = txtCorreo.Text.Trim();
            _cliente.Telefono = txtTelefono.Text.Trim();
            _cliente.Direccion = txtDireccion.Text.Trim();

            if (pbFoto.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    pbFoto.Image.Save(ms, pbFoto.Image.RawFormat);
                    _cliente.Foto = ms.ToArray();
                }
            }

            bool actualizado = _clienteNegocio.ActualizarCliente(_cliente);
            if (actualizado)
            {
                MessageBox.Show("Perfil actualizado correctamente.", "Éxito");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al actualizar el perfil.", "Error");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
