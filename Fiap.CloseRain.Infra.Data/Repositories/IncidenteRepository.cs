using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fiap.CloseRain.Domain.Entities;
using Fiap.CloseRain.Domain.Interfaces.Repository;
using Fiap.CloseRain.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Fiap.CloseRain.Infra.Data.Repositories
{
    public class IncidenteRepository : BaseRepository<Incidente, int>, IIncidenteRepository
    {
        public IncidenteRepository(CloseRainContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Incidente>> BuscarPorRegiaoAsync(double latitude, double longitude)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Incidente>> BuscarPorUsuarioAsync(int idUsuario)
        {
            return await DbSet.Where(w => w.IdUsuario == idUsuario).ToListAsync();
        }

        public async Task<IEnumerable<Incidente>> BuscarUltimosAsync(int qtdUltimosIncidentes)
        {
            return await DbSet.Where(w => w.DataIncidente >= DateTime.Now.AddMinutes(45)).Take(50).ToListAsync();
        }

        
    }
}
