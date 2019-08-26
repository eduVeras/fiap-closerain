using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiap.CloseRain.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Fiap.CloseRain.Extensions
{
    public static class ServiceExtensions
    {

        public static void AddEFCore(this IServiceCollection services)
        {
            services.AddDbContext<CloseRainContext>(opt => opt.UseSqlServer(""));
        }
    }
}
