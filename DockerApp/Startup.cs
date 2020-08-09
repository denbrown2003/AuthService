using Microsoft.Extensions.Configuration;
using System.IO;
using DockerApp.models;
using System;

namespace DockerApp
{
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
            if (obj == null) obj = new Startup();
            return obj.Configuration;
        }
    }
}
