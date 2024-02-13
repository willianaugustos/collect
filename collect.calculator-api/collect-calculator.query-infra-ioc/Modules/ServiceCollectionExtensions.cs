using collect_calculator.domain.Extensions;
using collect_calculator.infra_data.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace collect_calculator.infra_ioc.Modules;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    => services.AddDomainServices()
       .AddInfraSevices(configuration);
}
