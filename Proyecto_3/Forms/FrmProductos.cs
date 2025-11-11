using Entidad.Models;
using Negocio.Servicios;

namespace Presentacion.Forms
{
    public partial class FrmProducto : Form
    {
        private readonly int _productoId;
        private readonly ProductoNegocio _productoNegocio;
        private Producto _producto;

        public FrmProducto(int productoId)
        {
            InitializeComponent();
            _productoId = productoId;
            _productoNegocio = new ProductoNegocio();
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            CargarDatos();
            BloquearCampos();
        }

        private void CargarDatos()
        {
            _producto = _productoNegocio.ObtenerPorId(_productoId);
            if (_producto == null)
            {
                MessageBox.Show("No se pudieron cargar los datos del producto.");
                Close();
                return;
            }

            lblNombre.Text = "Nombre: " + _producto.Nombre;
            lblDescripcion.Text = "Descripción: " + _producto.Descripcion;
            lblPrecio.Text = "Precio: $" + _producto.Precio.ToString("F2");
            lblStock.Text = "Stock: " + _producto.Stock;

            if (_producto.Imagen != null && _producto.Imagen.Length > 0)
            {
                using var ms = new MemoryStream(_producto.Imagen);
                pbImagen.Image = Image.FromStream(ms);
            }
        }

        private void BloquearCampos()
        {
            txtNombre.Visible = txtDescripcion.Visible = txtPrecio.Visible = numStock.Visible = btnSeleccionarImagen.Visible = false;
            btnGuardar.Visible = false;
        }

        private void DesbloquearCampos()
        {
            txtNombre.Visible = txtDescripcion.Visible = txtPrecio.Visible = numStock.Visible = btnSeleccionarImagen.Visible = true;
            btnGuardar.Visible = true;

            txtNombre.Text = _producto.Nombre;
            txtDescripcion.Text = _producto.Descripcion;
            txtPrecio.Text = _producto.Precio.ToString("F2");
            numStock.Value = _producto.Stock;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            DesbloquearCampos();
        }

        private void btnSeleccionarImagen_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbImagen.Image = Image.FromFile(ofd.FileName);
            }
        }

        private byte[]? ObtenerImagenBytes()
        {
            if (pbImagen.Image == null) return null;

            using MemoryStream ms = new MemoryStream();
            pbImagen.Image.Save(ms, pbImagen.Image.RawFormat);
            return ms.ToArray();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
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

            _producto.Nombre = txtNombre.Text.Trim();
            _producto.Descripcion = txtDescripcion.Text.Trim();
            _producto.Precio = precio;
            _producto.Stock = (int)numStock.Value;
            _producto.Imagen = ObtenerImagenBytes();

            bool actualizado = _productoNegocio.ActualizarProducto(_producto);

            if (actualizado)
            {
                MessageBox.Show("Producto actualizado correctamente.", "Éxito");
                CargarDatos();
                BloquearCampos();
            }
            else
            {
                MessageBox.Show("Error al actualizar el producto.", "Error");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

