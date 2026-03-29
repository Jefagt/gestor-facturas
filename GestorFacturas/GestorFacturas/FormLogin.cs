using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorFacturas
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Resize(object sender, EventArgs e)
        {
            panelLogin.Left = (this.ClientSize.Width - panelLogin.Width) / 2;
            panelLogin.Top = (this.ClientSize.Height - panelLogin.Height) / 2;
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contraseña = txtContraseña.Text;
            string rol = "";

            if (usuario == "admin" && contraseña == "admin123")
                rol = "admin";
            else if (usuario == "vendedor" && contraseña == "vendedor123")
                rol = "vendedor";
            else if (usuario == "cliente" && contraseña == "cliente123")
                rol = "cliente";
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
                return;
            }

            FormPrincipal form = new FormPrincipal(rol); // pasamos el rol al form principal
            form.Show();
            this.Hide();
        }
    }
}
