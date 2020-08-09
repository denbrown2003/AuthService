using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;

namespace DockerApp
{
    class Program
    {
        static IConfigurationRoot config = Startup.Config();
        static void Main(string[] args)
        {
            AppContext.GetContext();
            Rabbit rabbit = new Rabbit();

            string queue = "demoqueue";
            var channel = rabbit.getChannel(queue);

            MessageReceiver messageReceiver = new MessageReceiver(channel);
            channel.BasicConsume(queue, false, messageReceiver);

            Console.ReadLine();
        }
    }
}
