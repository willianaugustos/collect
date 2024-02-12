using collect_calculator.query_domain.Messages;
using collect_calculator.query_infra_data.Queues;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace collect_calculator.query_infra_data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfraSevices(this IServiceCollection services, IConfiguration configuration)
        => services.AddScoped<IQueueService, RabbitMQService>()
            .Configure<RabbitMQSettings>(configuration.GetSection(RabbitMQSettings.Type));
    }
}
