namespace collect_calculator.domain.Messages
{
    public interface IQueueService
    {
        Task SendMessageAsync<T>(string queueName, IQueueMessage<T> message, CancellationToken cancellationToken);
    }
}
