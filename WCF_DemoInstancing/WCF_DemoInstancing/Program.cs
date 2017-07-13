using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WCF_DemoInstancing
{
    [ServiceContract(SessionMode=SessionMode.Required)]
    public interface IDataService
    {
    [OperationContract]
    void SetData(string data);

    [OperationContract]
    string GetData();
    }
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    class DataService : IDataService
    {
        private string data = string.Empty;

        public void SetData(string data)
        {
            this.data += "Data Recieved from Client : " + data;
        }

        public string GetData()
        {
            this.data += "Modified by Service!";
            return this.data;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(DataService), new Uri("net.pipe://localhost/dataservice"));
            host.AddDefaultEndpoints();
            host.Open();
            Console.WriteLine("Service ready");
            Console.WriteLine("Press any key to stop the service");
            Console.ReadKey();
            host.Close();
        }
    }
}
