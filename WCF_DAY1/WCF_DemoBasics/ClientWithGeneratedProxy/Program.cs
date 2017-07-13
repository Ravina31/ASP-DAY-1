using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientWithGeneratedProxy.CalcProxy;

namespace ClientWithGeneratedProxy
{
    class Program
    {
        static void Main(string[] args)
        {
            CalcServiceClient staticProxy = new CalcServiceClient("NetNamedPipeBinding_ICalcService");
            staticProxy.Open();
            Console.WriteLine(staticProxy.Add(10,20));
            Console.WriteLine(staticProxy.Subtract(10, 20));
            Console.WriteLine(staticProxy.Divide(10, 20));
            Console.WriteLine(staticProxy.Multiply(10, 20));
            Console.WriteLine(staticProxy.Modulus(10, 20));
            staticProxy.Close();
            Console.ReadKey();
        }
    }
}
