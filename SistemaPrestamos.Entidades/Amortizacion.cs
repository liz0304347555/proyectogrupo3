namespace SistemaPrestamos.Entidades
{
    public class Amortizacion
    {
        public int Mes { get; set; }
        public decimal Cuota { get; set; }
        public decimal Interes { get; set; }
        public decimal Capital { get; set; }
        public decimal Saldo { get; set; }
    }
}