namespace collect_calculator.query_domain.Messages
{
    public interface IQueueService
    {
        Task SendMessageAsync<T>(string queueName, IQueueMessage<T> message, CancellationToken cancellationToken);
    }
}
