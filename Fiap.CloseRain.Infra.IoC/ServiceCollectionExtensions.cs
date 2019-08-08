using System;
using System.Collections.Generic;
using System.Text;
using Fiap.CloseRain.Application.Applications;
using Fiap.CloseRain.Domain.Interfaces.Application;
using Fiap.CloseRain.Domain.Interfaces.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Fiap.CloseRain.Infra.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static  void AddDependency(this IServiceCollection services)
        {
            //Application
            services.AddScoped<IIncidenteApplication, IncidenteApplication>();

            //Repository
            services.AddScoped<IIncidenteRepository, IIncidenteRepository>();
        }
    }
}
