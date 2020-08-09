using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
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


    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        static private Startup obj = null;

        private Startup()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        static public IConfigurationRoot Config()
        {
            if (obj == null)obj = new Startup();
            return obj.Configuration;
        }
    }
}
