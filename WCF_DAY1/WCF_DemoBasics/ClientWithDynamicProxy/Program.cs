using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContractsLib;
using System.ServiceModel;



namespace ClientWithDynamicProxy
{
    class Program
    {
        static void Main(string[] args)
        {
            ICalcService DynamicProxy = ChannelFactory<ICalcService>.CreateChannel(new NetNamedPipeBinding(), new EndpointAddress("net.pipe://localhost/calcservice"));
            //ICalcService DynamicProxy = ChannelFactory<ICalcService>.CreateChannel(new NetTcpBinding(), new EndpointAddress("net.tcp://localhost/calcservice"));
            //ICalcService DynamicProxy = ChannelFactory<ICalcService>.CreateChannel(new NetHttpBinding(), new EndpointAddress("net.http://localhost/calcservice"));
          
           
            Console.WriteLine(DynamicProxy.Add(20,10));
            Console.WriteLine(DynamicProxy.Subtract(20, 10));
            Console.WriteLine(DynamicProxy.Divide(20, 10));
            Console.WriteLine(DynamicProxy.Multiply(20, 10));
            Console.WriteLine(DynamicProxy.Modulus(20, 10));
            Console.ReadKey();
        }
    }
}
