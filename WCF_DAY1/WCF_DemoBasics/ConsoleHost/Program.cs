using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ContractsLib;
using ServicesLib;

namespace ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
          ServiceHost host = new ServiceHost(typeof(Calc));
         // host.AddServiceEndpoint(typeof(ICalcService), new NetNamedPipeBinding(), "net.pipe://localhost/calcservice");
          //  host.AddServiceEndpoint(typeof(ICalcService), new NetTcpBinding(), "net.tcp://localhost:8080/calciservice");
           // host.AddServiceEndpoint(typeof(ICalcService), new NetHttpBinding(), "net.http://localhost:8080/calciservice");
            host.Open();        // start listening
            Console.WriteLine("Calci service is up and running");
            Console.WriteLine("Press any key to stop the service");
            Console.ReadKey();
            host.Close();

        }
    }
}
