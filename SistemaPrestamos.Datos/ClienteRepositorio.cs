using System.Data;
using System.Data.SqlClient;

namespace SistemaPrestamos.Datos
{
    public class ClienteRepositorio
    {
        private Conexion cn = new Conexion();

        public DataTable ObtenerClientes()
        {
            using (SqlConnection conn = cn.ObtenerConexion())
            {
                string query = "SELECT * FROM Clientes";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable ObtenerClientePorId(int id)
        {
            using (SqlConnection conn = cn.ObtenerConexion())
            {
                string query = "SELECT * FROM Clientes WHERE Id = @id";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@id", id);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void GuardarCliente(string nombre, string correo, string telefono, string direccion, string garantia, decimal sueldo)
        {
            using (SqlConnection conn = cn.ObtenerConexion())
            {
                string query = @"INSERT INTO Clientes (NombreCompleto, Correo, Telefono, Direccion, Garantia, Sueldo) 
                                VALUES (@nombre, @correo, @telefono, @direccion, @garantia, @sueldo)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@correo", correo);
                cmd.Parameters.AddWithValue("@telefono", telefono);
                cmd.Parameters.AddWithValue("@direccion", direccion);
                cmd.Parameters.AddWithValue("@garantia", garantia);
                cmd.Parameters.AddWithValue("@sueldo", sueldo);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable ObtenerTodosPrestamos()
        {
            using (SqlConnection conn = cn.ObtenerConexion())
            {
                string query = @"SELECT p.Id, c.NombreCompleto, p.Monto, p.TiempoMeses, 
                                p.TasaInteres, p.InteresGenerado, p.MontoTotal, p.Estado
                                FROM Prestamos p JOIN Clientes c ON p.ClienteId = c.Id";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void GuardarPrestamo(int clienteId, decimal monto, int meses, decimal tasa, decimal interes, decimal montoTotal)
        {
            using (SqlConnection conn = cn.ObtenerConexion())
            {
                string query = @"INSERT INTO Prestamos (ClienteId, Monto, TiempoMeses, TasaInteres, InteresGenerado, MontoTotal, SaldoRestante, FechaInicio, Estado)
                                VALUES (@clienteId, @monto, @meses, @tasa, @interes, @montoTotal, @monto, @fecha, 'Activo')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@clienteId", clienteId);
                cmd.Parameters.AddWithValue("@monto", monto);
                cmd.Parameters.AddWithValue("@meses", meses);
                cmd.Parameters.AddWithValue("@tasa", tasa * 100);
                cmd.Parameters.AddWithValue("@interes", interes);
                cmd.Parameters.AddWithValue("@montoTotal", montoTotal);
                cmd.Parameters.AddWithValue("@fecha", System.DateTime.Now);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable ObtenerReporteMoras()
        {
            using (SqlConnection conn = cn.ObtenerConexion())
            {
                string query = @"SELECT c.NombreCompleto, COUNT(m.Id) AS CantidadMoras, SUM(m.MontoMora) AS TotalMoras
                                FROM Moras m
                                JOIN Prestamos p ON m.PrestamoId = p.Id
                                JOIN Clientes c ON p.ClienteId = c.Id
                                GROUP BY c.NombreCompleto";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable ObtenerClientesMorosos()
        {
            using (SqlConnection conn = cn.ObtenerConexion())
            {
                string query = @"SELECT c.NombreCompleto, c.Correo, c.Telefono, COUNT(m.Id) AS TotalMoras
                                FROM Moras m
                                JOIN Prestamos p ON m.PrestamoId = p.Id
                                JOIN Clientes c ON p.ClienteId = c.Id
                                GROUP BY c.NombreCompleto, c.Correo, c.Telefono
                                HAVING COUNT(m.Id) >= 3";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable ObtenerResumenFinanciero()
        {
            using (SqlConnection conn = cn.ObtenerConexion())
            {
                string query = "SELECT SUM(Monto) AS TotalPrestado, SUM(InteresGenerado) AS TotalGanancia FROM Prestamos";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}