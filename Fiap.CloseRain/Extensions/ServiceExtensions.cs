using Fiap.CloseRain.Application.Applications;
using Fiap.CloseRain.Domain.Interfaces.Application;
using Fiap.CloseRain.Domain.Interfaces.Base;
using Fiap.CloseRain.Domain.Interfaces.Repository;
using Fiap.CloseRain.Domain.Interfaces.Service;
using Fiap.CloseRain.Infra.Data.Context;
using Fiap.CloseRain.Infra.Data.Repositories;
using Fiap.CloseRain.Service.Twitter.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Fiap.CloseRain.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddEfCore(this IServiceCollection services)
        {
            services.AddDbContext<CloseRainContext>(opt => opt.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CloseRainDb;Trusted_Connection=True;MultipleActiveResultSets=true"));
            return services;
        }

        
    }
}
