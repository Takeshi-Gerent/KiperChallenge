using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;

namespace Condominium.Database
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var db = services.GetRequiredService<CondominiumContext>();
                    db.Database.Migrate();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();                    
                    logger.LogError(ex, "An error occurred while migrating the database.");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(config =>
                {
                    config.SetBasePath(Directory.GetCurrentDirectory())                    
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

        public void Configure(IApplicationBuilder app)
        {
            app.UseHsts();

        }
    }
}
