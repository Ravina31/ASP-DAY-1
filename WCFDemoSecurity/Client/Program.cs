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
            DataServiceClient client = new DataServiceClient();
            client.ClientCredentials.UserName.UserName = @""; //provide username
            client.ClientCredentials.UserName.Password = ""; //password
            client.Open();
            Console.WriteLine(client.sayHello("GEP"));
            client.Close();
            Console.ReadKey();
        }
    }
}
