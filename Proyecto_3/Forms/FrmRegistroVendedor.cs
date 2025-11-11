using Entidad.Models;
using Negocio.Servicios;

namespace Presentacion.Forms
{
    public partial class FrmRegistroVendedor : Form
    {
        private readonly UsuarioNegocio _usuarioNegocio = new UsuarioNegocio();

        public FrmRegistroVendedor()
        {
            InitializeComponent();
        }

        private void FrmRegistroVendedor_Load(object sender, EventArgs e)
        {
            CargarVendedores();
        }

        private void CargarVendedores()
        {
            try
            {
                var lista = _usuarioNegocio.ListarUsuarios().FindAll(u => u.RoleId == 2);
                dgvVendedores.DataSource = lista;

                // Ocultar columnas sensibles
                if (dgvVendedores.Columns.Contains("PasswordHash"))
                    dgvVendedores.Columns["PasswordHash"].Visible = false;

                if (dgvVendedores.Columns.Contains("FotoPerfil"))
                    dgvVendedores.Columns["FotoPerfil"].Visible = false;

                // Ocultar columnas eliminadas
                if (dgvVendedores.Columns.Contains("Correo"))
                    dgvVendedores.Columns["Correo"].Visible = false;

                if (dgvVendedores.Columns.Contains("Telefono"))
                    dgvVendedores.Columns["Telefono"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar vendedores: " + ex.Message);
            }
        }

        private byte[]? ObtenerFotoBytes()
        {
            if (pbFoto.Image == null) return null;
            using var ms = new MemoryStream();
            pbFoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }

        private void btnSeleccionarFoto_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog();
            ofd.Filter = "Imagenes|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
                pbFoto.Image = Image.FromFile(ofd.FileName);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Nombre, usuario y contraseña son obligatorios.");
                return;
            }

            var vendedor = new Usuario
            {
                NombreCompleto = txtNombre.Text.Trim(),
                Username = txtUsuario.Text.Trim(),
                RoleId = 2,
                FotoPerfil = ObtenerFotoBytes()
            };

            try
            {
                _usuarioNegocio.RegistrarUsuario(vendedor, txtPassword.Text.Trim());
                MessageBox.Show("Vendedor agregado correctamente.");
                LimpiarCampos();
                CargarVendedores();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar vendedor: " + ex.Message);
            }
        }

        private void dgvVendedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtNombre.Text = dgvVendedores.Rows[e.RowIndex].Cells["NombreCompleto"].Value?.ToString();
                txtUsuario.Text = dgvVendedores.Rows[e.RowIndex].Cells["Username"].Value?.ToString();

                var foto = dgvVendedores.Rows[e.RowIndex].Cells["FotoPerfil"].Value;
                if (foto != DBNull.Value && foto is byte[] bytes)
                    using (var ms = new MemoryStream(bytes))
                        pbFoto.Image = Image.FromStream(ms);
                else
                    pbFoto.Image = null;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvVendedores.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un vendedor para editar.");
                return;
            }

            int userId = Convert.ToInt32(dgvVendedores.CurrentRow.Cells["UserId"].Value);
            var vendedor = new Usuario
            {
                UserId = userId,
                NombreCompleto = txtNombre.Text.Trim(),
                Username = txtUsuario.Text.Trim(),
                RoleId = 2,
                FotoPerfil = ObtenerFotoBytes()
            };

            try
            {
                _usuarioNegocio.ActualizarUsuario(vendedor);
                MessageBox.Show("Vendedor actualizado correctamente.");
                LimpiarCampos();
                CargarVendedores();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar vendedor: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvVendedores.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un vendedor para eliminar.");
                return;
            }

            int userId = Convert.ToInt32(dgvVendedores.CurrentRow.Cells["UserId"].Value);
            var confirm = MessageBox.Show("¿Está seguro de eliminar este vendedor?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _usuarioNegocio.EliminarUsuario(userId);
                    MessageBox.Show("Vendedor eliminado correctamente.");
                    CargarVendedores();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar vendedor: " + ex.Message);
                }
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtUsuario.Clear();
            txtPassword.Clear();
            pbFoto.Image = null;
        }
    }
}
