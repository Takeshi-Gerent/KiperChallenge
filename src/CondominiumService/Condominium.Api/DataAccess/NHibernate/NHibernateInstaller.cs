using Condominium.Api.DataAccess.NHMapping;
using Condominium.Api.Domain;
using FluentNHibernate.Cfg;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using NHibernate.Bytecode;
using NHibernate.Cfg;
using NHibernate.Connection;
using NHibernate.Dialect;
using NHibernate.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Condominium.Api.DataAccess.NHibernate
{
    public static class NHibernateInstaller
    {
        public static IServiceCollection AddNHibernate(this IServiceCollection services, string connectionString)
        {
            var configuration = new Configuration();

            configuration.DataBaseIntegration(db =>
            {
                db.Dialect<MySQL5Dialect>();
                db.Driver<MySqlDataDriver>();
                db.ConnectionProvider<DriverConnectionProvider>();
                db.ConnectionString = connectionString;
                db.Timeout = 30;
                db.SchemaAction = SchemaAutoAction.Validate;
            });

            configuration.Proxy(p => new StaticProxyFactoryFactory());
            configuration.Cache(c => c.UseQueryCache = false);
            configuration.AddAssembly(typeof(NHibernateInstaller).Assembly);

            services.AddSingleton(Fluently.Configure(configuration).Mappings(m => m.FluentMappings.GetMappings()).BuildSessionFactory());
            services.AddScoped(s => s.GetService<ISessionFactory>().OpenSession());
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;

        }

        private static void GetMappings(this FluentMappingsContainer map)
        {
            map.Add<ApartmentMap>();
            map.Add<DwellerMap>();
        }
    }
}
