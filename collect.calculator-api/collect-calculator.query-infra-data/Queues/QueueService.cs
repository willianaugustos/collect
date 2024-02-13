using collect_calculator.domain.Messages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace collect_calculator.infra_data.Queues;

public class RabbitMQService(IOptions<RabbitMQSettings> settings, ILogger<RabbitMQService> logger) : IQueueService
{
    private readonly string _rabbitMqConnectionString = settings.Value?.ConnectionString ?? throw new ArgumentException("RabbitMQ not configured");

    public Task SendMessageAsync<T>(string queueName, IQueueMessage<T> message, CancellationToken cancellationToken)
    {
        var factory = new ConnectionFactory() { Uri = new Uri(_rabbitMqConnectionString) };

        using IConnection connection = factory.CreateConnection();
        using IModel channel = connection.CreateModel();
        channel.QueueDeclare(queue: queueName,
                             durable: false,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);

        string jsonMessage = JsonSerializer.Serialize(message);
        var body = Encoding.UTF8.GetBytes(jsonMessage);

        cancellationToken.ThrowIfCancellationRequested();

        channel.BasicPublish(exchange: "",
                             routingKey: queueName,
                             basicProperties: null,
                             body: body);
        logger.LogInformation(" [x] Message {message} sent to {queueName}", message, queueName);

        return Task.CompletedTask;
    }
}