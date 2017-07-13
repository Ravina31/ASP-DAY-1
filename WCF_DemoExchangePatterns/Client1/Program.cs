using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.DataServiceProxy;




namespace Client
{
    class DataServiceCallback : IDataServiceCallback
    {
        public string GetData()
        {
            Console.WriteLine("Enter a string :  ");
             return Console.ReadLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DataServiceClient dsc = new DataServiceClient(new System.ServiceModel.InstanceContext(new DataServiceCallback()));
            dsc.Open();
            dsc.Process("");
            Console.WriteLine("Process Invoked()");
            
            Console.ReadKey();
            dsc.Close();
        }
    }
}
