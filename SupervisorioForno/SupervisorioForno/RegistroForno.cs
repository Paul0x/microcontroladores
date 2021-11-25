using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupervisorioForno
{
    public class RegistroForno
    {
        private int tempo;
        private double temp;
        private double voltVent;
        private double voltAq;
        private double setpoint;

        public RegistroForno()
        {
        }

        public int Tempo { get => tempo; set => tempo = value; }
        public double Temp { get => temp; set => temp = value; }
        public double VoltVent { get => voltVent; set => voltVent = value; }
        public double VoltAq { get => voltAq; set => voltAq = value; }
        public double Setpoint { get => setpoint; set => setpoint = value; }
    }
}