using System;

namespace SistemaPrestamos.Entidades
{
    public class Prestamo
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public decimal Monto { get; set; }
        public int PlazoMeses { get; set; }
        public decimal TasaInteres { get; set; }
        public decimal InteresGenerado { get; set; }
        public decimal MontoTotal { get; set; }
        public DateTime FechaInicio { get; set; }
    }
}