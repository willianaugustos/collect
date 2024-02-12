using collect_calculator.query_domain.Extensions;
using collect_calculator.query_infra_data.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace collect_calculator.query_infra_ioc.Modules
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        => services.AddDomainServices()
           .AddInfraSevices(configuration);
    }
}
