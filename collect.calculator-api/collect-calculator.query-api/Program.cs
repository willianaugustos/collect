using Asp.Versioning;
using collect_calculator.infra_ioc.Modules;
using Microsoft.OpenApi.Models;
using Serilog;

namespace collect_calculator;

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
                    }).AddApiExplorer(options =>
                    {
                        options.GroupNameFormat = "'v'V";
                        options.SubstituteApiVersionInUrl = true;
                    });

                    services.AddEndpointsApiExplorer();

                    // Add controllers and configure JSON serialization
                    services.AddControllers().AddNewtonsoftJson();

                    services.AddSingleton(Log.Logger);
                    IConfiguration config = services.BuildServiceProvider().GetService<IConfiguration>() ?? throw new Exception("Error getting IConfiguration service");
                    services.ConfigureServices(config);


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
                            options.SwaggerDoc("v1", new OpenApiInfo { Title = "v1", Version = "1.0" });
                            options.SwaggerDoc("v2", new OpenApiInfo { Title = "v2", Version = "2.0" });
                            options.CustomSchemaIds(x => x.FullName);
                        });
                    }
                })

                .Configure((configuration, app) =>
                {
                    app.UseDeveloperExceptionPage();

                    app.UseSwagger();
                    app.UseSwaggerUI(options =>
                        {
                            options.DefaultModelsExpandDepth(-1); // Collapse all models
                            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                            options.SwaggerEndpoint("/swagger/v2/swagger.json", "v2");
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