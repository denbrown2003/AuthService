using Microsoft.Extensions.Configuration;
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
         
            string nn = config["MAIL_SERVER"];
            string mode = config["ASPNETCORE_ENVIRONMENT"];
            string test = config["TEST"];

            Console.WriteLine(nn);
            Console.WriteLine(mode);
            Console.WriteLine(test);

        }
        

    }


   
}
