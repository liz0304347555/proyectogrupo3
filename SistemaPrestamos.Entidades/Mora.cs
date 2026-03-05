using System;

namespace SistemaPrestamos.Entidades
{
    public class Mora
    {
        public int Id { get; set; }
        public int PrestamoId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal MontoMora { get; set; }
    }
}