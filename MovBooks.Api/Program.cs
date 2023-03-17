using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovBooks.Core.Jobs;
using MovBooks.Core.Jobs.Interfaces;
using Serilog;

namespace MovBooks.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {


            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.File(@"C:\Users\David\Documents\@Desktop\Personal\@1-Grado\IA-RecomendationsMoviesBooks\MovBooks.Api\Storage\Logs\logs.log")
                .CreateLogger();

            try
            {
                Log.Information("Deploying Service");
                var host = CreateHostBuilder(args).Build();

                //Testing Queue
                //MonitorLoop monitorLoop = host.Services.GetRequiredService<MonitorLoop>()!;
                //monitorLoop.StartMonitorLoop();

                host.Run();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error deploying Service");
            }
            finally
            {
                //Clean log
                Log.CloseAndFlush();
            }

            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    //Test queue
                    //services.AddSingleton<MonitorLoop>();

                    // Config Main Queue
                    services.AddHostedService<QueuedHostedService>();
                    services.AddSingleton<IBackgroundTaskQueue>(_ =>
                    {
                        if (!int.TryParse(context.Configuration["QueueCapacity"], out var queueCapacity))
                        {
                            queueCapacity = 100;
                        }

                        return new BackgroundTaskQueue(queueCapacity);
                    });
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).UseSerilog();
    }
}
