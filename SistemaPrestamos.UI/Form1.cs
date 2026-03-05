using System;
using System.Windows.Forms;
using SistemaPrestamos.Negocio;

namespace SistemaPrestamos.UI
{
    public partial class Form1 : Form
    {
        private PrestamoService servicio = new PrestamoService();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMonto.Text) ||
                    string.IsNullOrWhiteSpace(txtPlazo.Text))
                {
                    MessageBox.Show("Debe completar todos los campos.");
                    return;
                }

                decimal monto = decimal.Parse(txtMonto.Text);
                int plazo = int.Parse(txtPlazo.Text);

                if (monto <= 0 || plazo <= 0)
                {
                    MessageBox.Show("Monto y plazo deben ser mayores que cero.");
                    return;
                }

                var tabla = servicio.GenerarTablaAmortizacion(monto, plazo);
                dgvAmortizacion.DataSource = null;
                dgvAmortizacion.DataSource = tabla;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            FormClientes formClientes = new FormClientes();
            formClientes.Show();
        }

        private void btnPrestamos_Click(object sender, EventArgs e)
        {
            FormPrestamos formPrestamos = new FormPrestamos();
            formPrestamos.Show();
        }

        private void dgvAmortizacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}