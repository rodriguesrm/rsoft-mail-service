﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RSoft.Framework.Infra.Data.MongoDb.Creators;
using RSoft.Framework.Infra.Data.MongoDb.IoC;
using RSoft.Framework.Infra.Data.MongoDb.Options;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RSoft.Framework.Infra.Data.MongoDb.Extensions
{

    /// <summary>
    /// Dependency Injection services collection extension
    /// </summary>
    public static class ServiceCollectionExtensions
    {

        /// <summary>
        /// Register all specified types 
        /// </summary>
        /// <typeparam name="T">Type to register</typeparam>
        /// <param name="services">Service collection</param>
        /// <param name="lifetime">Lifetime of a service</param>
        /// <param name="assemblies">Assemblies list</param>
        public static IServiceCollection RegisterAllTypes<T>(this IServiceCollection services, ServiceLifetime lifetime, params Assembly[] assemblies)
        {
            IEnumerable<TypeInfo> types = assemblies.SelectMany(assembly => assembly.DefinedTypes.Where(x => x.GetInterfaces().Contains(typeof(T))));
            foreach (TypeInfo type in types)
            {
                services.Add(new ServiceDescriptor(typeof(T), type, lifetime));
            }
            return services;
        }

        /// <summary>
        /// Add MongoDb services
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <param name="configuration">Configuration object</param>
        /// <returns></returns>
        public static IServiceCollection AddMongoDbServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.Configure<MongoDbConnectionStrings>(options => configuration.GetSection("ConnectionStrings").Bind(options));

            //MongoDB
            services.AddScoped<MongoDatabaseProvider>();
            services.AddScoped(s => s.GetService<MongoDatabaseProvider>().GetDatabase());

            // DbCreator
            services.AddScoped<IDatabaseCreator, MongoCollectionCreator>();
            services.RegisterAllTypes<IDocumentCollectionCreator>(ServiceLifetime.Scoped, typeof(MongoCollectionCreator).Assembly);

            return services;

        }

    }

}
