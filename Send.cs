// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;

var factory = new ConnectionFactory(){HostName = "localhost"};
using(var connection = factory.CreateConnection())
{
    using(var channel = connection.CreateModel())
    {
        channel.QueueDeclare(queue: "hello",
                             durable: false,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);

        var message = "Hola Mundo! :)";
        var body = System.Text.Encoding.UTF8.GetBytes(message);
        
        channel.BasicPublish(exchange: "",
                              routingKey: "hello",
                              basicProperties: null,
                              body: body);
        Console.WriteLine($" [x] Sent {message}");
    }
    Console.WriteLine(" Press any to exit.");
    Console.ReadLine();
}
