namespace collect_calculator.query_domain.Messages
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
