using Fiap.CloseRain.Application.Applications;
using Fiap.CloseRain.Domain.Interfaces.Application;
using Fiap.CloseRain.Domain.Interfaces.Base;
using Fiap.CloseRain.Domain.Interfaces.Repository;
using Fiap.CloseRain.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Fiap.CloseRain.Infra.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDependency(this IServiceCollection services)
        {
            //Application
            //services.AddScoped(typeof(IBaseApplication<>), typeof(BaseApplication<>));
            services.AddScoped<IIncidenteApplication, IncidenteApplication>();
            services.AddScoped<IRegiaoApplication, RegiaoApplication>();
            services.AddScoped<IUsuarioApplication, UsuarioApplication>();
            services.AddScoped<IContatoApplication, ContatoApplication>();


            //Repository
            services.AddScoped<IIncidenteRepository, IIncidenteRepository>();
            services.AddScoped<IRegiaoRepository, RegiaoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IContatoRepository, ContatoRepository>();
        }
    }
}
