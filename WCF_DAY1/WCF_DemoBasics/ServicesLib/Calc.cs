using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContractsLib;

namespace ServicesLib
{
    public class Calc : ICalcService
    {

        public double Add(double a, double b)
        {
            return a + b;
        }

        public double Subtract(double a, double b)
        {
            return a - b;
        }

        public double Divide(double a, double b)
        {
            return a / b;
        }

        public double Multiply(double a, double b)
        {
            return a * b;
        }

        public double Modulus(double a, double b)
        {
            return a % b;
        }
    }
}
