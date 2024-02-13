namespace collect_calculator.domain.Messages
{
    public interface IQueueMessage
    {
        Guid CorrelationId { get; set; }
    }

    public interface IQueueMessage<T> : IQueueMessage
    {

        public T? Data { get; set; }
    }
}
