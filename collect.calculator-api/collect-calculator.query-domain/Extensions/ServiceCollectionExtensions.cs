using collect_calculator.domain.Calculate;
using Microsoft.Extensions.DependencyInjection;

namespace collect_calculator.domain.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    => services.AddScoped<ICalculateHandler, CalculateHandler>();
}

