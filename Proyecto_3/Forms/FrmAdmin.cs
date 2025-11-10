using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Entidad.Models;
using Negocio.Servicios;

namespace Presentacion.Forms
{
    public partial class FrmAdmin : Form
    {
        private readonly UsuarioNegocio _usuarioNegocio = new UsuarioNegocio();
        private readonly VentaNegocio _VentaNegocio = new VentaNegocio();
        private Usuario _admin;

        public FrmAdmin(int adminUserId)
        {
            InitializeComponent();
            CargarDatosAdmin(adminUserId);
            CargarVentas();
        }

        private void CargarDatosAdmin(int adminUserId)
        {
            try
            {
                _admin = _usuarioNegocio.ObtenerPorId(adminUserId);
                if (_admin != null)
                {
                    txtAdminNombre.Text = _admin.NombreCompleto;
                    pbAdminFoto.Image = _admin.FotoPerfil != null ?
                        Image.FromStream(new MemoryStream(_admin.FotoPerfil)) : null;

                    MessageBox.Show(
                        $"Bienvenido, {_admin.NombreCompleto}\nRol: {(_admin.RoleId == 1 ? "Administrador" : "Desconocido")}",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos del administrador: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarVentas()
        {
            try
            {
                var ventas = _VentaNegocio.ListarVentas(); // Debe devolver IdVenta, Fecha, Cliente, Total
                dgvVentas.DataSource = ventas;

                dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvVentas.MultiSelect = false;
                dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las ventas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmAdmin_Load(object sender, EventArgs e)
        {
            // Nada más que hacer al cargar
        }

        private void btnGestionClientes_Click(object sender, EventArgs e)
        {
            using var frm = new FrmRegistroClientes();
            frm.ShowDialog();
        }

        private void btnGestionVendedores_Click(object sender, EventArgs e)
        {
            using var frm = new FrmRegistroVendedor();
            frm.ShowDialog();
        }

        private void btnGestionProductos_Click(object sender, EventArgs e)
        {
            using var frm = new FrmRegistroProductos();
            frm.ShowDialog();
        }

        private void btnVerReportes_Click(object sender, EventArgs e)
        {
            if (dgvVentas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una venta para ver el reporte.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int ventaId = Convert.ToInt32(dgvVentas.CurrentRow.Cells["IdVenta"].Value);
            using var frm = new FrmReporteVenta(ventaId);
            frm.ShowDialog();
        }
    }
}
