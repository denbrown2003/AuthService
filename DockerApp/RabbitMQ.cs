using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace DockerApp
{
    class RabbitMQ
    {
        static IConfigurationRoot config = Startup.Config();
        private IConnection conn;

        public RabbitMQ()
        {
            conn = connection();
        }
        private IConnection connection()
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new Uri( config["RabbitMQ:ConnectionString"] );
            return factory.CreateConnection();
        }
    }
   
}
