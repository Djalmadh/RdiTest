using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services;
using System;
using System.Threading.Tasks;

namespace Aplication
{
    class Program
    {
        static Task Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();
            Start(host.Services);

            return host.RunAsync();
        }

        static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                       .ConfigureServices((hostContext, services) =>
                       {
                           services.AddScoped<Robot>();
                       });
        }

        static void Start(IServiceProvider services)
        {
            using IServiceScope serviceScope = services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;
            Robot robot = provider.GetRequiredService<Robot>();

            Console.WriteLine(robot.GetLastLoop("RRRRDDDLLUUUUUUURRDDDDR"));
        }
    }
}
