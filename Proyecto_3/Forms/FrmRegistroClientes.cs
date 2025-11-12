using Entidad.Models;
using Negocio.Servicios;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Presentacion.Forms
{
    public partial class FrmRegistroClientes : Form
    {
        private readonly ClienteNegocio _clienteNegocio = new ClienteNegocio();

        public FrmRegistroClientes()
        {
            InitializeComponent();
        }

        private void FrmRegistroClientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void CargarClientes()
        {
            try
            {
                var lista = _clienteNegocio.ListarClientes();
                dgvClientes.DataSource = lista;

                if (dgvClientes.Columns.Contains("Foto"))
                    dgvClientes.Columns["Foto"].Visible = false;
                if (dgvClientes.Columns.Contains("PasswordHash"))
                    dgvClientes.Columns["PasswordHash"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===========================
        // VALIDACIONES Y UTILIDADES
        // ===========================
        private bool EsCorreoValido(string correo)
        {
            if (string.IsNullOrWhiteSpace(correo)) return false;
            string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(correo, patron);
        }

        private byte[]? ObtenerFotoBytes()
        {
            if (pbFoto.Image == null)
                return null;

            using (var ms = new MemoryStream())
            {
                pbFoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }

        // ===========================
        // BOTONES
        // ===========================
        private void btnSeleccionarFoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pbFoto.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("Debe ingresar al menos el nombre y correo del cliente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!EsCorreoValido(txtCorreo.Text.Trim()))
            {
                MessageBox.Show("Correo no válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Debe ingresar un nombre de usuario y contraseña.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cliente = new Cliente
            {
                Nombre = txtNombre.Text.Trim(),
                Correo = txtCorreo.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                Foto = ObtenerFotoBytes(),
                Username = txtUsername.Text.Trim(),
                PasswordHash = HashPassword(txtPassword.Text.Trim()),
                UserId = 0 // Se generará automáticamente
            };

            try
            {
                _clienteNegocio.RegistrarCliente(cliente);
                MessageBox.Show("Cliente y usuario agregados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un cliente para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!EsCorreoValido(txtCorreo.Text.Trim()))
            {
                MessageBox.Show("Correo no válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cliente = new Cliente
            {
                ClienteId = Convert.ToInt32(dgvClientes.CurrentRow.Cells["ClienteId"].Value),
                UserId = Convert.ToInt32(dgvClientes.CurrentRow.Cells["UserId"].Value),
                Nombre = txtNombre.Text.Trim(),
                Correo = txtCorreo.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                Foto = ObtenerFotoBytes(),
                Username = txtUsername.Text.Trim(),
                PasswordHash = string.IsNullOrWhiteSpace(txtPassword.Text) ? dgvClientes.CurrentRow.Cells["PasswordHash"].Value.ToString()! : HashPassword(txtPassword.Text.Trim())
            };

            try
            {
                _clienteNegocio.ActualizarCliente(cliente);
                MessageBox.Show("Cliente actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un cliente para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvClientes.CurrentRow.Cells["ClienteId"].Value);
            var confirm = MessageBox.Show("¿Está seguro de eliminar este cliente y su usuario asociado?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _clienteNegocio.EliminarCliente(id);
                    MessageBox.Show("Cliente eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarClientes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtNombre.Text = dgvClientes.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                txtCorreo.Text = dgvClientes.Rows[e.RowIndex].Cells["Correo"].Value.ToString();
                txtTelefono.Text = dgvClientes.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
                txtDireccion.Text = dgvClientes.Rows[e.RowIndex].Cells["Direccion"].Value.ToString();

                if (dgvClientes.Columns.Contains("Username"))
                    txtUsername.Text = dgvClientes.Rows[e.RowIndex].Cells["Username"].Value.ToString();

                var foto = dgvClientes.Rows[e.RowIndex].Cells["Foto"].Value;
                if (foto != DBNull.Value && foto is byte[] fotoBytes)
                {
                    using var ms = new MemoryStream(fotoBytes);
                    pbFoto.Image = Image.FromStream(ms);
                }
                else
                {
                    pbFoto.Image = null;
                }
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtCorreo.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            pbFoto.Image = null;
        }

        private void pbFoto_Click(object sender, EventArgs e)
        {

        }
    }
}
