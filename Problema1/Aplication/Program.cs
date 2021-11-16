using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services;
using System;
using System.Collections.Generic;
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
                    services.AddScoped<NumberToWordsConverter>();
                });
        }

        static void Start(IServiceProvider services)
        {
            using IServiceScope serviceScope = services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;
            NumberToWordsConverter numberToWordsConverter = provider.GetRequiredService<NumberToWordsConverter>();

            List<(int,int)> inputs = new() 
            {
                (1000080,0),
                (111, 0),
                (1, 11),
                (23, 1),
                (1000, 1),
            };

            foreach(var input in inputs)
            {
                Console.WriteLine(
                    $"Input: ({input.Item1} , {input.Item2})"
                    +"\nResult: " + numberToWordsConverter.ConvertAmount2Words(input.Item1, input.Item2) + "\n");
            }         
        }
    }
}
