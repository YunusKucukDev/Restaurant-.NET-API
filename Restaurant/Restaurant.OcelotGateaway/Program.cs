
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace Restaurant.OcelotGateWay
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("ocelot.json")
                .Build();

            builder.Services.AddOcelot(configuration);

            var app = builder.Build();


           
           


            app.UseOcelot().Wait();

            app.Run();

        }
    }
}