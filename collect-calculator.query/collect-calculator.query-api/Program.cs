using Asp.Versioning;
using Microsoft.OpenApi.Models;
using Serilog;

namespace collect_calculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureServices((context, services) =>
                    {
                        // Add API versioning
                        services.AddApiVersioning(opt =>
                        {
                            opt.DefaultApiVersion = new ApiVersion(1, 0);
                            opt.AssumeDefaultVersionWhenUnspecified = true;
                            opt.ReportApiVersions = true;
                            opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                                                                            new HeaderApiVersionReader("x-api-version"),
                                                                            new MediaTypeApiVersionReader("x-api-version"));
                        });
                        services.AddEndpointsApiExplorer();

                        // Add controllers and configure JSON serialization
                        services.AddControllers().AddNewtonsoftJson();
                        
                        services.AddSingleton(Log.Logger);
                        
                        Log.Logger = new LoggerConfiguration()
                            .MinimumLevel.Information()
                            .WriteTo.Console()
                            .CreateLogger();

                        services.AddLogging(x =>
                        {
                            x.ClearProviders();
                            x.AddSerilog(dispose: true);
                        });

                        if (context.HostingEnvironment.IsDevelopment())
                        {
                            services.AddSwaggerGen(options =>
                            {
                                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                                options.SwaggerDoc("v1", new OpenApiInfo { Title = "collect-calculator.query v1", Version = "1.0" });
                                options.SwaggerDoc("v2", new OpenApiInfo { Title = "collect-calculator.query v2", Version = "2.0" });
                                options.CustomSchemaIds(x => x.FullName);
                            });
                        }
                    })

                    .Configure((app) =>
                    {

                        app.UseDeveloperExceptionPage();

                        app.UseSwagger();
                        app.UseSwaggerUI(options =>
                            {
                                options.DefaultModelsExpandDepth(-1); // Collapse all models
                                options.SwaggerEndpoint("/swagger/v1/swagger.json", "collect-calculator.query v1");
                                options.SwaggerEndpoint("/swagger/v2/swagger.json", "collect-calculator.query v2");
                                options.InjectJavascript("/custom.js");
                            });

                        // Enable routing
                        app.UseRouting();

                        // Enable endpoints
                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapControllers();
                        });
                    });
                });
    }
}