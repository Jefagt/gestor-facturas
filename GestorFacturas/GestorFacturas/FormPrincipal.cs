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
    public partial class FormPrincipal : Form
    {
        private string rolUsuario;

        public FormPrincipal(string rol)
        {
            InitializeComponent();
            rolUsuario = rol;
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
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

    }
}
