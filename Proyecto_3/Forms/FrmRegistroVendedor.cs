using Entidad.Models; // Importa los modelos de datos (Usuario)
using Negocio.Servicios; // Importa la capa de negocio para interactuar con la base de datos

namespace Presentacion.Forms
{
    public partial class FrmRegistroVendedor : Form
    {
        // Instancia de la capa de negocio para usuarios
        private readonly UsuarioNegocio _usuarioNegocio = new UsuarioNegocio();

        public FrmRegistroVendedor()
        {
            InitializeComponent();

            // Cargar imagen de fondo del formulario
            string rutaImagen = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Imagen",
                "fondo.jpg"
            );

            this.BackgroundImage = Image.FromFile(rutaImagen);
            this.BackgroundImageLayout = ImageLayout.Stretch; // Ajusta la imagen al tamaño del formulario
        }

        // Evento que se ejecuta al cargar el formulario
        private void FrmRegistroVendedor_Load(object sender, EventArgs e)
        {
            CargarVendedores(); // Cargar los vendedores en el DataGridView
        }

        // Método para cargar todos los vendedores
        private void CargarVendedores()
        {
            try
            {
                // Obtener todos los usuarios con RoleId = 2 (vendedores)
                var lista = _usuarioNegocio.ListarUsuarios().FindAll(u => u.RoleId == 2);
                dgvVendedores.DataSource = lista;

                // Ocultar columnas sensibles en el DataGridView
                if (dgvVendedores.Columns.Contains("PasswordHash"))
                    dgvVendedores.Columns["PasswordHash"].Visible = false;

                if (dgvVendedores.Columns.Contains("FotoPerfil"))
                    dgvVendedores.Columns["FotoPerfil"].Visible = false;

                // Ocultar columnas que no se necesitan mostrar
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

        // Convierte la imagen del PictureBox a un arreglo de bytes
        private byte[]? ObtenerFotoBytes()
        {
            if (pbFoto.Image == null) return null;

            using var ms = new MemoryStream();
            pbFoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png); // Guardar en PNG
            return ms.ToArray();
        }

        // Botón para seleccionar foto de vendedor
        private void btnSeleccionarFoto_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog();
            ofd.Filter = "Imagenes|*.jpg;*.jpeg;*.png;*.bmp"; // Tipos permitidos
            if (ofd.ShowDialog() == DialogResult.OK)
                pbFoto.Image = Image.FromFile(ofd.FileName); // Cargar imagen al PictureBox
        }

        // Botón para agregar un nuevo vendedor
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Validación de campos obligatorios
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Nombre, usuario y contraseña son obligatorios.");
                return;
            }

            // Crear objeto vendedor
            var vendedor = new Usuario
            {
                NombreCompleto = txtNombre.Text.Trim(),
                Username = txtUsuario.Text.Trim(),
                RoleId = 2, // RoleId 2 = Vendedor
                FotoPerfil = ObtenerFotoBytes()
            };

            try
            {
                _usuarioNegocio.RegistrarUsuario(vendedor, txtPassword.Text.Trim()); // Registrar en la base de datos
                MessageBox.Show("Vendedor agregado correctamente.");
                LimpiarCampos(); // Limpiar formulario
                CargarVendedores(); // Refrescar DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar vendedor: " + ex.Message);
            }
        }

        // Evento al hacer click en una fila del DataGridView
        private void dgvVendedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Cargar datos del vendedor seleccionado a los TextBox
                txtNombre.Text = dgvVendedores.Rows[e.RowIndex].Cells["NombreCompleto"].Value?.ToString();
                txtUsuario.Text = dgvVendedores.Rows[e.RowIndex].Cells["Username"].Value?.ToString();

                // Cargar la foto del vendedor si existe
                var foto = dgvVendedores.Rows[e.RowIndex].Cells["FotoPerfil"].Value;
                if (foto != DBNull.Value && foto is byte[] bytes)
                {
                    using (var ms = new MemoryStream(bytes))
                    {
                        using (var tempImage = Image.FromStream(ms))
                        {
                            pbFoto.Image = new Bitmap(tempImage); // <-- copia en memoria independiente
                        }
                    }
                }
                else
                {
                    pbFoto.Image = null;
                }
            }
        }

        // Botón para editar un vendedor existente
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvVendedores.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un vendedor para editar.");
                return;
            }

            int userId = Convert.ToInt32(dgvVendedores.CurrentRow.Cells["UserId"].Value);

            // Crear objeto vendedor actualizado
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
                _usuarioNegocio.ActualizarUsuario(vendedor); // Actualizar en la base de datos
                MessageBox.Show("Vendedor actualizado correctamente.");
                LimpiarCampos();
                CargarVendedores();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar vendedor: " + ex.Message);
            }
        }

        // Botón para eliminar un vendedor
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
                    _usuarioNegocio.EliminarUsuario(userId); // Eliminar de la base de datos
                    MessageBox.Show("Vendedor eliminado correctamente.");
                    CargarVendedores();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar vendedor: " + ex.Message);
                }
            }
        }

        // Limpiar todos los campos del formulario
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtUsuario.Clear();
            txtPassword.Clear();
            pbFoto.Image = null;
        }

        // Botón para cerrar el formulario
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
