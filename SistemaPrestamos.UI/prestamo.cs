using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPrestamos.UI
{
    internal class prestamo

    {
        public string Cliente { get; set; }
        public double Monto { get; set; }
        public int Meses { get; set; }
        public double Tasa { get; set; }
        public double Interes { get; set; }
        public double Total { get; set; }






        public double CalcularTasa()
        {
            if (Meses <= 12)
                return 0.1325;

            if (Meses <= 24)
                return 0.15;

            return 0.30;
        }

        public void CalcularPrestamo()
        {
            Tasa = CalcularTasa();

            double t = Meses / 12.0;

            Interes = Monto * Tasa * t;

            Total = Monto + Interes;
        }

    }
}

