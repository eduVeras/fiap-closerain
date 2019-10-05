using Fiap.CloseRain.Application.Applications;
using Fiap.CloseRain.Domain.Interfaces.Application;
using Fiap.CloseRain.Domain.Interfaces.Repository;
using Fiap.CloseRain.Domain.Interfaces.Service;
using Fiap.CloseRain.Infra.Data.Repositories;
using Fiap.CloseRain.Service.Twitter.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Fiap.CloseRain.Infra.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDependency(this IServiceCollection services)
        {
            services
                .RegisterApplication()
                .RegisterRepository()
                .RegisterTwitter();
        }

        private static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            services.AddScoped<IIncidenteApplication, IncidenteApplication>();
            services.AddScoped<IRegiaoApplication, RegiaoApplication>();
            services.AddScoped<IUsuarioApplication, UsuarioApplication>();
            return services;
        }

        private static IServiceCollection RegisterRepository(this IServiceCollection services)
        {
            services.AddScoped<IIncidenteRepository, IncidenteRepository>();
            services.AddScoped<IRegiaoRepository, RegiaoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            return services;

        }

        private static IServiceCollection RegisterTwitter(this IServiceCollection services)
        {
            services.AddScoped<ITwitterService, TwitterService>();
            return services;
        }
    }
}
