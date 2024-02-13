using collect_calculator.domain.Helpers;

namespace collect_calculator.domain.Calculate;

public interface ICalculateHandler
{
    Task<Response<CalculateResponse>> Handle(CalculateRequest request, Guid correlationId, CancellationToken cancellationToken);
}
