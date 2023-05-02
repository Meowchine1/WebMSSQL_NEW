using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using TelegramBot;

namespace Publisher
{
    internal class Program
    {
      
        public static void sendMessageToWeb()
        {
            var factory = new ConnectionFactory();
            factory.HostName = "localhost";

            using (var connection = factory.CreateConnection())
            {

                using (var chanel = connection.CreateModel())
                {
                    chanel.QueueDeclare(queue: "web",
                        exclusive: false,
                        durable: true,
                        autoDelete: false,
                        arguments: null);
                    var message = DbConnection.getUserCode();
                    var body = Encoding.UTF8.GetBytes(message);

                    chanel.BasicPublish(exchange: "",
                        routingKey: "web",
                        basicProperties: null,
                        body: body);
                }
            }
        }

        static void Main(string[] args)
        {
            var factory = new ConnectionFactory();
            factory.HostName = "localhost";

            using (var connection = factory.CreateConnection())
            {

                using (var chanel = connection.CreateModel())
                {
                    chanel.QueueDeclare(queue: "telegram",
                        exclusive: false,
                        durable: true,
                        autoDelete: false,
                        arguments: null);

                    var consumer = new EventingBasicConsumer(chanel);

                    consumer.Received += (model, es) =>
                    {

                        var body = es.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);

                        if (message.Equals("get code"))
                        {
                            sendMessageToWeb();
                        }

                    };

                    chanel.BasicConsume(queue: "telegram",
                        autoAck: true,
                        consumer: consumer);

                    Console.ReadKey();
                }
            }
        }
        }
}