using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GestorFacturas
{
    public partial class FormPrincipal : Form
    {
        string connectionString = "server=localhost;database=gestorfacturas;user=root;password=rootdev;";

        private string rolUsuario;

        public FormPrincipal(string rol)
        {
            InitializeComponent();
            rolUsuario = rol;
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            // conexion
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    lblConexion.Text = "Listo";
                    lblConexion.ForeColor = Color.Green;
                }
            }
            catch (Exception ex)
            {
                lblConexion.Text = "Conexión fallida";
                lblConexion.ForeColor = Color.Red;
            }

            // verificacion
            if (rolUsuario == "admin")
            {
                // Admin: acceso completo
                //btnUsuarios.Enabled = true; // botón para gestionar usuarios
                //btnReportes.Enabled = true;
            }
            else if (rolUsuario == "vendedor")
            {
                // Vendedor: acceso limitado
                //btnUsuarios.Enabled = false; // no puede cambiar usuarios
                //btnReportes.Enabled = true;
            }
            else if (rolUsuario == "cliente")
            {
                // Cliente: acceso restringido
                //btnUsuarios.Enabled = false;
                //btnReportes.Enabled = false;
                //btnFacturas.Enabled = true; // solo ver facturas
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AbrirFormEnPanel(Form formHijo)
        {
            // Limpia el panel
            panelContenido.Controls.Clear();

            // Configura el formulario hijo
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;

            // Agrega al panel
            panelContenido.Controls.Add(formHijo);
            formHijo.Show();
        }

        private void ResetearColoresMenu()
        {
            btnDashboard.BackColor = Color.White;
            btnDashboard.ForeColor = Color.MidnightBlue;
            btnClientes.BackColor = Color.White;
            btnClientes.ForeColor = Color.MidnightBlue;
            btnProductos.BackColor = Color.White;
            btnProductos.ForeColor = Color.MidnightBlue;
            btnFacturas.BackColor = Color.White;
            btnFacturas.ForeColor = Color.MidnightBlue;
        }
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ResetearColoresMenu();
            btnDashboard.BackColor = Color.RoyalBlue;
            btnDashboard.ForeColor = Color.White;
            AbrirFormEnPanel(new FormDashboard());
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            ResetearColoresMenu(); 
            btnClientes.BackColor = Color.RoyalBlue;
            btnClientes.ForeColor= Color.White;
            AbrirFormEnPanel(new FormClientes());
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            ResetearColoresMenu();
            btnProductos.BackColor = Color.RoyalBlue;
            btnProductos.ForeColor = Color.White;
            AbrirFormEnPanel(new FormProductos());
        }

        private void btnFacturas_Click(object sender, EventArgs e)
        {
            ResetearColoresMenu();
            btnFacturas.BackColor = Color.RoyalBlue;
            btnFacturas.ForeColor = Color.White;
            AbrirFormEnPanel(new FormFacturas());
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // Confirmación opcional
            DialogResult result = MessageBox.Show("¿Desea cerrar sesión?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Abrir nuevamente el login
                FormLogin login = new FormLogin();
                login.Show();

                // Cerrar el form principal
                this.Close();
            }
        }
    }
}
