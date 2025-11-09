using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidad.Models;
using Negocio.Servicios;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Presentacion.Forms
{
    public partial class FrmLogin : Form
    {
        private readonly UsuarioNegocio _usuarioNegocio = new UsuarioNegocio();

        public FrmLogin()
        {
            InitializeComponent();

            Text = "TechSolutions - Sistema de Ventas";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;

            // Ocultar contraseña por defecto
            txtClave.UseSystemPasswordChar = true;

            // Evento para mostrar u ocultar contraseña
            chkMostrarClave.CheckedChanged += (s, e) =>
            {
                txtClave.UseSystemPasswordChar = !chkMostrarClave.Checked;
            };
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string clave = txtClave.Text;

            lblMensaje.Text = string.Empty;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(clave))
            {
                lblMensaje.Text = "Ingrese usuario y contraseña.";
                lblMensaje.ForeColor = Color.Red;
                return;
            }

            try
            {
                var user = _usuarioNegocio.Login(usuario, clave);


                if (user == null)
                {
                    lblMensaje.Text = "Credenciales inválidas o usuario inactivo.";
                    lblMensaje.ForeColor = Color.Red;
                    return;
                }

                MessageBox.Show($"Bienvenido {user.NombreCompleto}", "Acceso concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Abrir formulario principal
                FrmMain frmMain = new FrmMain(user);
                Hide();
                frmMain.FormClosed += (s, args) => this.Close();
                frmMain.Show();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al autenticar: " + ex.Message;
                lblMensaje.ForeColor = Color.Red;
            }
        }
    }
}
