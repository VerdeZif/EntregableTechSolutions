using Entidad.Models;
using Negocio.Servicios;

namespace Presentacion.Forms
{
    // ==============================
    // FORMULARIO PARA VISUALIZAR Y EDITAR UN PRODUCTO
    // ==============================
    public partial class FrmProducto : Form
    {
        private readonly int _productoId;             // Id del producto que se va a mostrar/editar
        private readonly ProductoNegocio _productoNegocio; // Capa de negocio para productos
        private Producto _producto;                   // Objeto producto actual

        // ==============================
        // Constructor
        // ==============================
        public FrmProducto(int productoId)
        {
            InitializeComponent();
            _productoId = productoId;
            _productoNegocio = new ProductoNegocio();

            // Configurar imagen de fondo
            string rutaImagen = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Imagen",
                "fondo.jpg"
            );
            this.BackgroundImage = Image.FromFile(rutaImagen);
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        // ==============================
        // LOAD DEL FORMULARIO
        // ==============================
        private void FrmProducto_Load(object sender, EventArgs e)
        {
            CargarDatos();    // Cargar datos del producto
            BloquearCampos(); // Inicialmente los campos están bloqueados
        }

        // ==============================
        // CARGAR DATOS DEL PRODUCTO
        // ==============================
        private void CargarDatos()
        {
            _producto = _productoNegocio.ObtenerPorId(_productoId);
            if (_producto == null)
            {
                MessageBox.Show("No se pudieron cargar los datos del producto.");
                Close();
                return;
            }

            // Mostrar información en etiquetas
            lblNombre.Text = "Nombre: " + _producto.Nombre;
            lblDescripcion.Text = "Descripción: " + _producto.Descripcion;
            lblPrecio.Text = "Precio: $" + _producto.Precio.ToString("F2");
            lblStock.Text = "Stock: " + _producto.Stock;

            // Mostrar imagen si existe
            if (_producto.Imagen != null && _producto.Imagen.Length > 0)
            {
                using var ms = new MemoryStream(_producto.Imagen);
                pbImagen.Image = Image.FromStream(ms);
            }
        }

        // ==============================
        // BLOQUEAR CAMPOS (MODO VISUALIZACIÓN)
        // ==============================
        private void BloquearCampos()
        {
            txtNombre.Visible = txtDescripcion.Visible = txtPrecio.Visible = numStock.Visible = btnSeleccionarImagen.Visible = false;
            btnGuardar.Visible = false;
        }

        // ==============================
        // DESBLOQUEAR CAMPOS (MODO EDICIÓN)
        // ==============================
        private void DesbloquearCampos()
        {
            txtNombre.Visible = txtDescripcion.Visible = txtPrecio.Visible = numStock.Visible = btnSeleccionarImagen.Visible = true;
            btnGuardar.Visible = true;

            // Cargar datos actuales en los campos de edición
            txtNombre.Text = _producto.Nombre;
            txtDescripcion.Text = _producto.Descripcion;
            txtPrecio.Text = _producto.Precio.ToString("F2");
            numStock.Value = _producto.Stock;
        }

        // ==============================
        // BOTÓN EDITAR
        // ==============================
        private void btnEditar_Click(object sender, EventArgs e)
        {
            DesbloquearCampos();
        }

        // ==============================
        // BOTÓN SELECCIONAR IMAGEN
        // ==============================
        private void btnSeleccionarImagen_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbImagen.Image = Image.FromFile(ofd.FileName);
            }
        }

        // ==============================
        // OBTENER IMAGEN EN BYTES PARA GUARDAR
        // ==============================
        private byte[]? ObtenerImagenBytes()
        {
            if (pbImagen.Image == null) return null;

            using MemoryStream ms = new MemoryStream();
            pbImagen.Image.Save(ms, pbImagen.Image.RawFormat);
            return ms.ToArray();
        }

        // ==============================
        // BOTÓN GUARDAR CAMBIOS
        // ==============================
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                MessageBox.Show("Debe ingresar el nombre y precio del producto.", "Validación");
                return;
            }

            if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
            {
                MessageBox.Show("El precio debe ser un número válido.", "Error");
                return;
            }

            // Actualizar objeto producto
            _producto.Nombre = txtNombre.Text.Trim();
            _producto.Descripcion = txtDescripcion.Text.Trim();
            _producto.Precio = precio;
            _producto.Stock = (int)numStock.Value;
            _producto.Imagen = ObtenerImagenBytes();

            // Guardar cambios mediante la capa de negocio
            bool actualizado = _productoNegocio.ActualizarProducto(_producto);

            if (actualizado)
            {
                MessageBox.Show("Producto actualizado correctamente.", "Éxito");
                CargarDatos();    // Recargar datos actualizados
                BloquearCampos(); // Volver a modo visualización
            }
            else
            {
                MessageBox.Show("Error al actualizar el producto.", "Error");
            }
        }

        // ==============================
        // BOTÓN CANCELAR
        // ==============================
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

