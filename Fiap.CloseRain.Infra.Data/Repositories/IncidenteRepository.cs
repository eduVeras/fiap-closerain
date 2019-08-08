using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Fiap.CloseRain.Domain.Entities;
using Fiap.CloseRain.Domain.Interfaces.Repository;

namespace Fiap.CloseRain.Infra.Data.Repositories
{
    public class IncidenteRepository : BaseRepository<Incidente,int> , IIncidenteRepository
    {
        public async Task<IEnumerable<Incidente>> BuscarPorRegiaoAsync(double latitude, double longitude)
        {

            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Incidente>> BuscarPorUsuarioAsync(int idUsuario)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Incidente>> BuscarUltimosAsync(int qtdUltimosIncidentes)
        {
            throw new NotImplementedException();
        }
    }
}
