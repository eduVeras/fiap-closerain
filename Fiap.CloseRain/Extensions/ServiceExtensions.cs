using Fiap.CloseRain.Infra.Data.Context;
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
