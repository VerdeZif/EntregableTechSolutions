using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Windows.Forms;
using Entidad.Models;

namespace Presentacion.Forms
{
    public partial class FrmMain : Form
    {
        private readonly Usuario _usuario;

        public FrmMain(Usuario usuario)
        {
            InitializeComponent();
            _usuario = usuario;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            lblUsuarioActivo.Text = $"Usuario: {_usuario.NombreCompleto}";
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            new FrmClientes().ShowDialog();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            new FrmProductos().ShowDialog();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            new FrmVentas(_usuario).ShowDialog();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            new FrmReportes().ShowDialog();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("¿Deseas cerrar sesión?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}

