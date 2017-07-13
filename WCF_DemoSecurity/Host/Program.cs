using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContractsLib;
using ServicesLib;
using System.ServiceModel;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(DataService),
                new Uri("http://172.16.244.110:9999/dataservice"));
            host.AddDefaultEndpoints();
            host.Open();
            Console.WriteLine("DataService started!");
            Console.WriteLine("Press any key to stop DataService");
            Console.ReadKey();
            host.Close();
        }
    }
}
