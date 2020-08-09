using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace DockerApp
{
    class Rabbit
    {
        static IConfigurationRoot config = Startup.Config();
        private IConnection conn;
        public bool isConnect { get { return conn.IsOpen; } }

        public Rabbit()
        {
            conn = connection();
        }
        private IConnection connection()
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new Uri( config["RabbitMQ:ConnectionString"] );
            return factory.CreateConnection();
        }

        public IModel getChannel(string queue) 
        {
            IModel channel = conn.CreateModel();
            channel.QueueDeclare(queue, false, false, false, null);
            channel.BasicQos(0, 1, false);
            return channel;
        }

        static public Request Deserialize(ReadOnlyMemory<byte> body)
        {
            string msg = Encoding.UTF8.GetString(body.ToArray());
            return JsonConvert.DeserializeObject<Request>(msg) as Request;
        }


        static public byte[] Serialize(Response obj)
        {
            string message = JsonConvert.SerializeObject(obj);
            return Encoding.UTF8.GetBytes(message);
        }
    }

    enum taskRabbit { CredValidate, Create, GetToken, Validate }

    [Serializable]
    class Request
    {
        public string login;
        public string password;
        public int id;
        public string token;
        public taskRabbit task;
    }

    [Serializable]
    class Response
    {
        public bool access;
        public string token;
        public string login;
        public int id;
        public string group;
        public int errCode = 0;
        public string errText = "";
    }

}
