using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AuthService
{
    class Startup
    {
        private IConfigurationRoot Configuration { get; }
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
