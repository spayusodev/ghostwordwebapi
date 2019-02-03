using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace GhostWord.Spayuso.Infraestructure
{
    public static class InfraestructureDependencyResolver
    {
        public static IServiceCollection LoadInfraestructureDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IDataFeed, DataDictionary>();
            services.AddSingleton<IDataFeed, SingleTree>();
            services.AddSingleton<IDataReader, DataReader>();

            return services;
        }
    }
}
