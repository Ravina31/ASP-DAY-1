using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ContractsLib;
using ServicesLib;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(DataService), new Uri("http://localhost:9999/dataservice"));
            host.AddDefaultEndpoints();
            host.Open();
            Console.WriteLine("Data service started");
            Console.WriteLine("Press any key to stop data service");
            Console.ReadKey();
            host.Close();
        }
    }
}
