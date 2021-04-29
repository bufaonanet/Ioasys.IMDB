﻿using Ioasys.IMDb.Data;
using Ioasys.IMDb.Data.Repository;
using Ioasys.IMDb.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Ioasys.IMDb.Api.Configurations
{
    public static class DependencyConfig
    {
        public static IServiceCollection ResolveDependecies(this IServiceCollection services)
        {
            services.AddScoped<IMDbContext>();
            services.AddScoped<IAdministradorRepository, AdministradorRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();                     

            return services;
        }
    }
}