using System;
using System.Data;
using System.Windows.Forms;
using SistemaPrestamos.Datos;
using SistemaPrestamos.Negocio;

namespace SistemaPrestamos.UI
{
    public partial class FormPrestamos : Form
    {
        private ClienteRepositorio repo = new ClienteRepositorio();
        private PrestamoService servicio = new PrestamoService();

        public FormPrestamos()
        {
            InitializeComponent();
            CargarClientes();
            CargarPrestamos();
        }

        private void CargarClientes()
        {
            DataTable clientes = repo.ObtenerClientes();
            cmbClientes.DataSource = clientes;
            cmbClientes.DisplayMember = "NombreCompleto";
            cmbClientes.ValueMember = "Id";
        }

        private void CargarPrestamos()
        {
            dgvPrestamos.DataSource = repo.ObtenerTodosPrestamos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbClientes.SelectedValue == null ||
                    string.IsNullOrWhiteSpace(txtMonto.Text) ||
                    string.IsNullOrWhiteSpace(txtMeses.Text))
                {
                    MessageBox.Show("Debe completar todos los campos.");
                    return;
                }

                int clienteId = (int)cmbClientes.SelectedValue;
                decimal monto = decimal.Parse(txtMonto.Text);
                int meses = int.Parse(txtMeses.Text);

                DataTable cliente = repo.ObtenerClientePorId(clienteId);
                decimal sueldo = (decimal)cliente.Rows[0]["Sueldo"];
                string garantia = cliente.Rows[0]["Garantia"].ToString();

                if (monto > sueldo * 4)
                {
                    MessageBox.Show("No se puede prestar más de 4 veces el sueldo del cliente.");
                    return;
                }

                if (string.IsNullOrEmpty(garantia))
                {
                    MessageBox.Show("El cliente no tiene garantía registrada.");
                    return;
                }

                decimal tasa = servicio.ObtenerTasaInteres(meses);
                decimal interes = servicio.CalcularInteresSimple(monto, tasa, meses);
                decimal montoTotal = servicio.CalcularMontoTotal(monto, interes);

                lblTasa.Text = "Tasa: " + (tasa * 100) + "%";
                lblInteres.Text = "Interes generado: " + interes.ToString("F2");
                lblMontoTotal.Text = "Monto total: " + montoTotal.ToString("F2");

                repo.GuardarPrestamo(clienteId, monto, meses, tasa, interes, montoTotal);

                MessageBox.Show("Prestamo guardado exitosamente!");
                btnLimpiar_Click(sender, e);
                CargarPrestamos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtMonto.Text = "";
            txtMeses.Text = "";
            lblTasa.Text = "Tasa: -";
            lblInteres.Text = "Interes generado: -";
            lblMontoTotal.Text = "Monto total: -";
        }
    }
}