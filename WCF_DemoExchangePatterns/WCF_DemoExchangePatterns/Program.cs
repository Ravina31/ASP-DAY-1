using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WCF_DemoExchangePatterns
{
    [ServiceContract(CallbackContract= typeof(IDataServiceCallback))]

    public interface IDataService
    {   [OperationContract]
        void Process(string data);
    }


    [ServiceContract]

    public interface IDataServiceCallback
    {
        [OperationContract]
        string GetData();
    }


    [ServiceBehavior(ConcurrencyMode= ConcurrencyMode.Reentrant)]
    class DataService : IDataService
    {
        public void Process(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                IDataServiceCallback clientProxy = OperationContext.Current.GetCallbackChannel<IDataServiceCallback>();
                data = clientProxy.GetData();
            }
            Console.WriteLine("Server has received {0}", data);
            System.Threading.Thread.Sleep(1000);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(DataService), new Uri("net.pipe://localhost/dataservice"));
            host.AddDefaultEndpoints();
            host.Open();
            Console.WriteLine("Service started");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            host.Close();
        }
    }
}
