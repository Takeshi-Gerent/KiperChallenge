using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NHibernate.Cfg;
using System;
using System.IO;

namespace Condominium.Database
{
    public class Program
    {
        public static void Main(string[] args)
            => CreateHostBuilder(args).Build().Run();

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).ConfigureHostConfiguration(config =>
            {
                config.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .AddJsonFile($"appsettings.{System.Environment.GetEnvironmentVariable("ENVIRONMENT")}.json", true, true)
                .AddCommandLine(args);
            }).ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());

        }

    }

    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CondominiumContext>(o => o.UseMySQL(Configuration.GetConnectionString("MigrationConnection")));
        }

    }
}
