using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;

namespace RecieverApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Endpoint=sb://gepdemo-sb31.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=vPIlgAqxQW4D9HiAuh7XLs0lQastPHW5qbTxfO1XpUM=";
            string queueName = "myqueue";
            var client = QueueClient.CreateFromConnectionString(connectionString, queueName);
            client.OnMessage(msg => {
                Console.WriteLine($"MessageId : {msg.MessageId}, Message Body : {msg.GetBody<string>()}");
                msg.Complete();
                
            });

            Console.ReadKey();
        }
    }
}
