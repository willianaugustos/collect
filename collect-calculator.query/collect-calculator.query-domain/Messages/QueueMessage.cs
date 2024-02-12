
namespace collect_calculator.query_domain.Messages
{
    public class QueueMessage<T> : IQueueMessage<T>
    {
        public T? Data { get; set; }
        public Guid CorrelationId { get; set; } = Guid.Empty;

        public static QueueMessage<T> From(Guid correlationId, T data)
        {
            return new QueueMessage<T> { CorrelationId = correlationId, Data = data };
        }
    }
}
