using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Negocio.Servicios;
using Entidad.Models;

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
        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            CargarClientes();
            CargarProductos();
            lblVendedor.Text = $"Vendedor: {_usuario.NombreCompleto}";
        }

        private void CargarClientes()
        {
            cmbCliente.DataSource = _clienteNegocio.ListarClientes();
            cmbCliente.DisplayMember = "NombreCompleto";
            cmbCliente.ValueMember = "ClienteId";
        }

        private void CargarProductos()
        {
            cmbProducto.DataSource = _productoNegocio.ListarProductos();
            cmbProducto.DisplayMember = "Nombre";
            cmbProducto.ValueMember = "ProductoId";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedItem == null || numCantidad.Value <= 0)
            {
                MessageBox.Show("Seleccione un producto y una cantidad válida.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var producto = (Producto)cmbProducto.SelectedItem;
            int cantidad = (int)numCantidad.Value;

            if (cantidad > producto.Stock)
            {
                MessageBox.Show("No hay suficiente stock para este producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var detalle = new DetalleVenta
            {
                ProductoId = producto.ProductoId,
                NombreProducto = producto.Nombre,
                Descripcion = producto.Descripcion,
                Cantidad = cantidad,
                PrecioUnitario = producto.Precio
            };

            _detallesVenta.Add(detalle);
            CargarDetalles();
            CalcularTotal();
        }

        private void CargarDetalles()
        {
            dgvDetalles.DataSource = null;
            dgvDetalles.DataSource = _detallesVenta;
        }

        private void CalcularTotal()
        {
            decimal total = _detallesVenta.Sum(d => d.Subtotal);
            lblTotal.Text = $"Total: S/ {total:F2}";
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
            if (cmbCliente.SelectedItem == null || _detallesVenta.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un cliente y agregar al menos un producto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cliente = (Cliente)cmbCliente.SelectedItem;
            decimal total = _detallesVenta.Sum(d => d.Subtotal);

            try
            {
                var resultado = _ventaNegocio.RegistrarVenta(
                    _usuario.UserId,
                    cliente.ClienteId,
                    total,
                    _detallesVenta
                );

                MessageBox.Show($"Venta registrada correctamente. ID: {resultado.ventaId}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _detallesVenta.Clear();
                CargarDetalles();
                CalcularTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
