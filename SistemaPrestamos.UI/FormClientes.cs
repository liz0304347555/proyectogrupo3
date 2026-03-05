using System;
using System.Data;
using System.Windows.Forms;
using SistemaPrestamos.Datos;

namespace SistemaPrestamos.UI
{
    public partial class FormClientes : Form
    {
        private ClienteRepositorio repo = new ClienteRepositorio();

        public FormClientes()
        {
            InitializeComponent();
            CargarClientes();
        }

        private void CargarClientes()
        {
            dgvClientes.DataSource = repo.ObtenerClientes();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                    string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                    string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                    string.IsNullOrWhiteSpace(txtGarantia.Text) ||
                    string.IsNullOrWhiteSpace(txtSueldo.Text))
                {
                    MessageBox.Show("Debe completar todos los campos.");
                    return;
                }

                decimal sueldo = decimal.Parse(txtSueldo.Text);

                repo.GuardarCliente(
                    txtNombre.Text,
                    txtCorreo.Text,
                    txtTelefono.Text,
                    txtDireccion.Text,
                    txtGarantia.Text,
                    sueldo
                );

                MessageBox.Show("Cliente guardado exitosamente!");
                btnLimpiar_Click(sender, e);
                CargarClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtGarantia.Text = "";
            txtSueldo.Text = "";
        }
    }
}