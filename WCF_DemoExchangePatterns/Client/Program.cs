using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.DataServiceProxy;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            DataServiceClient dsc = new DataServiceClient();
            dsc.Open();
            dsc.Process("Hello");
            Console.WriteLine("Process Invoked()");
            dsc.Close();
            Console.ReadKey();
        }
    }
}
