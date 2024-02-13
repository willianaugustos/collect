using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using collect_api_gateway;



public static class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    //public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
    //    WebHost.CreateDefaultBuilder(args)
    //        .ConfigureAppConfiguration(ic => ic.AddJsonFile("ocelot.json"))
    //        .UseStartup<Startup>();

    public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
               .ConfigureAppConfiguration((context, builder) =>
               {
                   //var isDev = context.HostingEnvironment.IsDevelopment();
                   //var isProd = context.HostingEnvironment.IsProduction();
                   var envName = context.HostingEnvironment.EnvironmentName;

                   builder.AddJsonFile($"ocelot.{envName}.json");
               })
               .ConfigureWebHostDefaults(webBuilder =>
               {
                   webBuilder.UseStartup<Startup>();
               });
}