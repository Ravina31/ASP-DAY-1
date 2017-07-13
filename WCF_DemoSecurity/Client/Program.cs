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
            //client.ClientCredentials.UserName.UserName = @"TestUser";
            //client.ClientCredentials.UserName.Password = "test@123";
            client.Open();
            Console.WriteLine(client.SayHello("GEP"));
            client.Close();
            Console.ReadKey();
        }
    }
}
