using System;
using Challenge.WebApi.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Challenge.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = @"Pandora Challenge";

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                        .ConfigureServices(services =>
                        {
                            services.AddHostedService<BackgroundWorkerService>();
                        });
                });
    }
}