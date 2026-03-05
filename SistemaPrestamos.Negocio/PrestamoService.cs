using System;
using System.Collections.Generic;
using SistemaPrestamos.Entidades;

namespace SistemaPrestamos.Negocio
{
    public class PrestamoService
    {
        private decimal fondoDisponible = 5000000m;

        public decimal ObtenerTasaInteres(int plazoMeses)
        {
            if (plazoMeses >= 1 && plazoMeses <= 3)
                return 0.10m;
            if (plazoMeses >= 4 && plazoMeses <= 6)
                return 0.08m;
            if (plazoMeses >= 7 && plazoMeses <= 12)
                return 0.07m;
            return 0.05m;
        }

        public bool PuedeOtorgarPrestamo(Cliente cliente, decimal monto)
        {
            if (cliente == null) return false;
            if (string.IsNullOrWhiteSpace(cliente.Garantia)) return false;
            if (monto > cliente.Sueldo * 4) return false;
            if (monto > fondoDisponible) return false;
            return true;
        }

        public decimal CalcularInteresSimple(decimal capital, decimal tasa, int meses)
        {
            return capital * tasa * meses;
        }

        public decimal CalcularMontoTotal(decimal capital, decimal interes)
        {
            return capital + interes;
        }

        public decimal CalcularCuota(decimal monto, int plazoMeses)
        {
            decimal tasaAnual = ObtenerTasaInteres(plazoMeses);
            decimal tasaMensual = tasaAnual / 12;
            decimal factor = (decimal)Math.Pow((double)(1 + tasaMensual), plazoMeses);
            decimal cuota = monto * (tasaMensual * factor) / (factor - 1);
            return Math.Round(cuota, 2);
        }

        public List<Amortizacion> GenerarTablaAmortizacion(decimal monto, int plazoMeses)
        {
            var tabla = new List<Amortizacion>();
            decimal tasaAnual = ObtenerTasaInteres(plazoMeses);
            decimal tasaMensual = tasaAnual / 12;
            decimal cuota = CalcularCuota(monto, plazoMeses);
            decimal saldo = monto;

            for (int mes = 1; mes <= plazoMeses; mes++)
            {
                decimal interes = saldo * tasaMensual;
                decimal capital = cuota - interes;
                saldo -= capital;

                tabla.Add(new Amortizacion
                {
                    Mes = mes,
                    Cuota = Math.Round(cuota, 2),
                    Interes = Math.Round(interes, 2),
                    Capital = Math.Round(capital, 2),
                    Saldo = Math.Round(saldo < 0 ? 0 : saldo, 2)
                });
            }
            return tabla;
        }
    }
}