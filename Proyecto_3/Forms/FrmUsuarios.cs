using Entidad.Models;
using Negocio.Seguridad;
using Negocio.Servicios;

namespace Presentacion.Forms
{
    public partial class FrmUsuarios : Form
    {
        private readonly UsuarioNegocio _usuarioNegocio = new UsuarioNegocio();
        private byte[]? fotoPerfil; // Para guardar la foto seleccionada

        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
            CargarRoles();
        }

        private void CargarUsuarios()
        {
            dgvUsuarios.DataSource = null;
            var lista = _usuarioNegocio.ListarUsuarios();
            dgvUsuarios.DataSource = lista;
            dgvUsuarios.Columns["PasswordHash"].Visible = false;
            dgvUsuarios.Columns["FotoPerfil"].Visible = false;
        }

        private void CargarRoles()
        {
            var roles = _usuarioNegocio.ListarRoles();
            cbRol.DataSource = roles;
            cbRol.DisplayMember = "Nombre";
            cbRol.ValueMember = "RoleId";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtClave.Text))
            {
                MessageBox.Show("Debe completar todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var nuevoUsuario = new Usuario
            {
                Username = txtUsuario.Text.Trim(),
                NombreCompleto = txtNombre.Text.Trim(),
                RoleId = (int)cbRol.SelectedValue,
                FotoPerfil = fotoPerfil
            };

            bool ok = _usuarioNegocio.RegistrarUsuario(nuevoUsuario, txtClave.Text);

            if (ok)
            {
                MessageBox.Show("Usuario registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarUsuarios();
            }
            else
            {
                MessageBox.Show("No se pudo registrar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSeleccionarFoto_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Imagenes|*.jpg;*.png;*.jpeg;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fotoPerfil = File.ReadAllBytes(ofd.FileName);
                pictureBoxFoto.Image = Image.FromFile(ofd.FileName);
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un usuario para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var usuario = new Usuario
            {
                UserId = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["UserId"].Value),
                Username = txtUsuario.Text.Trim(),
                NombreCompleto = txtNombre.Text.Trim(),
                RoleId = (int)cbRol.SelectedValue,
                FotoPerfil = fotoPerfil  // <- Aquí se asigna la foto
            };
            // Solo actualizar la contraseña si se ingresó un valor

            if (!string.IsNullOrWhiteSpace(txtClave.Text))
            {
                var hasher = new PasswordHasher(); // crear instancia
                usuario.PasswordHash = hasher.HashPassword(txtClave.Text);
            }

            bool ok = _usuarioNegocio.ActualizarUsuario(usuario);

            if (ok)
            {
                MessageBox.Show("Usuario actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarUsuarios();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un usuario para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["UserId"].Value);
            var confirm = MessageBox.Show("¿Está seguro de eliminar este usuario?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                bool ok = _usuarioNegocio.EliminarUsuario(id);
                if (ok)
                {
                    MessageBox.Show("Usuario eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarUsuarios();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvUsuarios.Rows[e.RowIndex];
                txtUsuario.Text = row.Cells["Username"].Value?.ToString() ?? "";
                txtNombre.Text = row.Cells["NombreCompleto"].Value?.ToString() ?? "";
                cbRol.SelectedValue = Convert.ToInt32(row.Cells["RoleId"].Value);

                // Manejo seguro de FotoPerfil
                var valorFoto = row.Cells["FotoPerfil"].Value;
                if (valorFoto != null && valorFoto != DBNull.Value)
                {
                    byte[] bytes = (byte[])valorFoto;
                    if (bytes.Length > 0)
                    {
                        using MemoryStream ms = new MemoryStream(bytes);
                        pictureBoxFoto.Image = Image.FromStream(ms);
                        fotoPerfil = bytes;
                    }
                    else
                    {
                        pictureBoxFoto.Image = null;
                        fotoPerfil = null;
                    }
                }
                else
                {
                    pictureBoxFoto.Image = null;
                    fotoPerfil = null;
                }
            }
        }


        private void LimpiarCampos()
        {
            txtUsuario.Clear();
            txtNombre.Clear();
            txtClave.Clear();
            cbRol.SelectedIndex = 0;
            pictureBoxFoto.Image = null;
            fotoPerfil = null;
        }
    }
}
