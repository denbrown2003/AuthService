using System;
using System.Text;
using RabbitMQ.Client;

namespace DockerApp
{
    class MessageReceiver : DefaultBasicConsumer
    {
        private readonly IModel _channel;
        public MessageReceiver(IModel channel)
        {
            _channel = channel;
        }

  
        public override void HandleBasicDeliver(
            string consumerTag, 
            ulong deliveryTag, 
            bool redelivered, 
            string exchange, 
            string routingKey, 
            IBasicProperties properties,
            ReadOnlyMemory<byte> body)
        {

            string content = properties.ContentType;
            if (content == "application/json")
            {
                Console.WriteLine("===============");

                Request request = Rabbit.Deserialize(body);
                Console.WriteLine(request.login);


                Console.WriteLine("===============");
            }
            
            _channel.BasicAck(deliveryTag, false);
        }
    }
}
