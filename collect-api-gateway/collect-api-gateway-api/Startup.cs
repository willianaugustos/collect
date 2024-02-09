using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Values;

namespace collect_api_gateway
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddOcelot();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            ILogger logger = app.ApplicationServices.GetService<ILogger<Startup>>() ?? throw new Exception("Unable to get ILogger instance");
            logger?.LogInformation("Application Started");
            logger?.LogInformation($"Environment: {env.EnvironmentName}");

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseOcelot();
        }
    }
}
