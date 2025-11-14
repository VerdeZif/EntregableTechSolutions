using Entidad.Models;
using Negocio.Servicios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.Forms
{
    public partial class FrmVentas : Form
    {
        private readonly Usuario _usuario;
        private readonly ClienteNegocio _clienteNegocio = new ClienteNegocio();
        private readonly ProductoNegocio _productoNegocio = new ProductoNegocio();
        private readonly VentaNegocio _ventaNegocio = new VentaNegocio();
        private List<DetalleVenta> _detallesVenta = new List<DetalleVenta>();

        public FrmVentas(Usuario usuario)
        {
            InitializeComponent();
            _usuario = usuario;
            string rutaImagen = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Imagen",
                "fondo.jpg"
            );

            this.BackgroundImage = Image.FromFile(rutaImagen);
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            CargarClientes();
            CargarProductos();
            lblVendedor.Text = $"Vendedor: {_usuario.NombreCompleto}";
            dgvDetalles.AutoGenerateColumns = false;
            ConfigurarGridDetalles();
        }

        private void CargarClientes()
        {
            var clientes = _clienteNegocio.ListarClientes();
            cmbCliente.DataSource = clientes;
            cmbCliente.DisplayMember = "Nombre";
            cmbCliente.ValueMember = "ClienteId";
            cmbCliente.SelectedIndex = -1;
        }

        private void CargarProductos()
        {
            var productos = _productoNegocio.ListarProductos();
            cmbProducto.DataSource = productos;
            cmbProducto.DisplayMember = "Nombre";
            cmbProducto.ValueMember = "ProductoId";
            cmbProducto.SelectedIndex = -1;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un producto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var producto = (Producto)cmbProducto.SelectedItem;

            // Validar stock
            if (producto.Stock <= 0)
            {
                MessageBox.Show("Este producto no tiene stock disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int cantidad = (int)numCantidad.Value;
            if (cantidad <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar si el producto ya está agregado
            var detalleExistente = _detallesVenta.FirstOrDefault(d => d.ProductoId == producto.ProductoId);

            if (detalleExistente != null)
            {
                if (detalleExistente.Cantidad + cantidad > producto.Stock)
                {
                    MessageBox.Show($"No puede agregar más de {producto.Stock} unidades de este producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                detalleExistente.Cantidad += cantidad;
            }
            else
            {
                if (cantidad > producto.Stock)
                {
                    MessageBox.Show($"No puede agregar más de {producto.Stock} unidades de este producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _detallesVenta.Add(new DetalleVenta
                {
                    ProductoId = producto.ProductoId,
                    NombreProducto = producto.Nombre,
                    Descripcion = producto.Descripcion,
                    Cantidad = cantidad,
                    PrecioUnitario = producto.Precio
                });
            }

            CargarDetalles();
            CalcularTotal();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDetalles.CurrentRow == null) return;

            int index = dgvDetalles.CurrentRow.Index;
            _detallesVenta.RemoveAt(index);
            CargarDetalles();
            CalcularTotal();
        }

        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un cliente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_detallesVenta.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un producto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar stock antes de registrar
            foreach (var detalle in _detallesVenta)
            {
                var producto = _productoNegocio.ObtenerPorId(detalle.ProductoId);
                if (producto.Stock < detalle.Cantidad)
                {
                    MessageBox.Show($"El producto {detalle.NombreProducto} solo tiene {producto.Stock} unidades disponibles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            int clienteId = Convert.ToInt32(cmbCliente.SelectedValue);
            decimal total = _detallesVenta.Sum(d => d.Subtotal);

            try
            {
                var resultado = _ventaNegocio.RegistrarVenta(
                    _usuario.UserId,
                    clienteId,
                    total,
                    _detallesVenta
                );

                if (resultado.ventaId > 0)
                {
                    MessageBox.Show($"Venta registrada correctamente. ID: {resultado.ventaId}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar formulario
                    _detallesVenta.Clear();
                    CargarDetalles();
                    CalcularTotal();
                    cmbCliente.SelectedIndex = -1;
                    cmbProducto.SelectedIndex = -1;
                    numCantidad.Value = 1;
                }
                else
                {
                    MessageBox.Show("No se pudo registrar la venta: " + resultado.mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDetalles()
        {
            dgvDetalles.DataSource = null;
            dgvDetalles.DataSource = _detallesVenta;
        }

        private void CalcularTotal()
        {
            decimal total = _detallesVenta.Sum(d => d.Subtotal);
            lblTotal.Text = $"Total: S/ {total:0.00}";
        }

        private void ConfigurarGridDetalles()
        {
            dgvDetalles.Columns.Clear();

            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreProducto",
                HeaderText = "Producto",
                ReadOnly = true
            });

            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Descripcion",
                HeaderText = "Descripción",
                ReadOnly = true
            });

            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Cantidad",
                HeaderText = "Cantidad",
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PrecioUnitario",
                HeaderText = "Precio Unitario",
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    NullValue = "S/ 0.00"
                }
            });

            dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Subtotal",
                HeaderText = "Subtotal",
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    NullValue = "S/ 0.00"
                }
            });

            dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

