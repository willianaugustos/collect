﻿using collect_calculator.domain.Helpers;
using collect_calculator.domain.Messages;

namespace collect_calculator.domain.Calculate;

public class CalculateHandler(IQueueService queueService) : ICalculateHandler
{
    private const string CALCULATE_QUEUE_NAME = "collect-calculate";

    public async Task<Response<CalculateResponse>> Handle(CalculateRequest request, Guid correlationId, CancellationToken cancellationToken)
    {
        IQueueMessage<CalculateRequest> queueMessage = QueueMessage<CalculateRequest>.From(correlationId, request);
        await queueService.SendMessageAsync<CalculateRequest>(CALCULATE_QUEUE_NAME, queueMessage, cancellationToken);
        return await Task.FromResult(Response<CalculateResponse>.SuccessWithNoData());
    }
}
