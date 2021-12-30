using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDatos
{
    public class AntiguedadSaldo
    {
        private int idAuxiliar;
        private string auxiliar;
        private double saldoInicial;
        private double saldoActual;
        private double importe;
        private DateTime fecha;
        private int idCuenta;
        private string cuenta;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        public int IdAuxiliar { get => idAuxiliar; set => idAuxiliar = value; }
        public string Auxiliar { get => auxiliar; set => auxiliar = value; }
        public double SaldoInicial { get => saldoInicial; set => saldoInicial = value; }
        public double SaldoActual { get => saldoActual; set => saldoActual = value; }
        public double Importe { get => importe; set => importe = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public int IdCuenta { get => idCuenta; set => idCuenta = value; }
        public string Cuenta { get => cuenta; set => cuenta = value; }
        public DateTime FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public DateTime FechaFin { get => fechaFin; set => fechaFin = value; }
    }
}
