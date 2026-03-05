using System.Data.SqlClient;

namespace SistemaPrestamos.Datos
{
    public class Conexion
    {
        private string cadena = "Server=localhost\\MSSQLSERVER02;Database=ReporteFinanciero;Integrated Security=True;";

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadena);
        }
    }
}