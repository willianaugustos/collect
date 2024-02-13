using collect_calculator.domain.Helpers;

namespace collect_calculator.domain.Calculate;

public record CalculateErrorResponse(int Status, string? Message) : ErrorResponse(Status, Message);