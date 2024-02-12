using collect_calculator.query_domain.Calculate;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collect_calculator.query_domain.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        => services.AddScoped<ICalculateHandler, CalculateHandler>();
    }
}

