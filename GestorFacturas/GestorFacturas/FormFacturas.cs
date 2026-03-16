using MySql.Data.MySqlClient;
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
    public partial class FormFacturas : Form
    {
        string connectionString = "server=localhost;database=gestorfacturas;user=root;password=rootdev;";

        public FormFacturas()
        {
            InitializeComponent();
        }

        private void btnListarFacturas_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT f.id, c.nombre AS Cliente, p.nombre AS Producto, 
                         f.cantidad, f.precio_unitario, f.total, f.fecha
                         FROM facturas f
                         JOIN clientes c ON f.cliente_id = c.id
                         JOIN productos p ON f.producto_id = p.id";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvFacturas.DataSource = dt;
            }
        }
        private void btnAgregarFactura_Click(object sender, EventArgs e)
        {
            int clienteId = Convert.ToInt32(cmbCliente.SelectedValue);
            int productoId = Convert.ToInt32(cmbProducto.SelectedValue);
            int cantidad = Convert.ToInt32(txtCantidad.Text);
            decimal precioUnitario = Convert.ToDecimal(txtPrecioUnitario.Text);
            decimal total = cantidad * precioUnitario;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO facturas (cliente_id, producto_id, cantidad, precio_unitario, total) VALUES (@cliente, @producto, @cantidad, @precio, @total)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@cliente", clienteId);
                cmd.Parameters.AddWithValue("@producto", productoId);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                cmd.Parameters.AddWithValue("@precio", precioUnitario);
                cmd.Parameters.AddWithValue("@total", total);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Factura registrada correctamente");
            btnListarFacturas_Click(null, null);
        }
    }
}
