using Microsoft.Extensions.Configuration;
using System.IO;
using DockerApp.models;
using System;
using Appy.Logging.GrayLog;

namespace DockerApp
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        static private Startup obj = null;
        public static GrayLogUdpClient Logger = null;

        private Startup()
        {
 
          
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            Logger = new GrayLogUdpClient("AuthService", "192.168.0.16", 12201);

        }

        static public IConfigurationRoot Config()
        {
            if (obj == null) obj = new Startup();
            return obj.Configuration;
        }


    }
}
