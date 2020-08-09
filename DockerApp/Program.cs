using Microsoft.Extensions.Configuration;
using System;
using System.Text;
using System.Threading;

namespace DockerApp
{
    class Program
    {
        static IConfigurationRoot config = Startup.Config();
        static AppContext context = AppContext.GetContext();

        static void Main(string[] args)
        {

         
            string nn = config["Database:ConnectionString"];
            string mode = config["RabbitMQ:ConnectionString"];
            string test = config["TEST"];

            Console.WriteLine(nn);
            Console.WriteLine(mode);
            Console.WriteLine(test);

            //RabbitMQ connect = new RabbitMQ();

            while (true)
            {

                Thread.Sleep(5000);
            }
        }
        

    }


   
}
