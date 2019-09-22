using System.Collections.Generic;
using System.Threading.Tasks;
using Fiap.CloseRain.Domain.Entities;
using Fiap.CloseRain.Domain.Interfaces.Base;

namespace Fiap.CloseRain.Domain.Interfaces.Repository
{
    public interface IIncidenteRepository : IBaseRepository<Incidente>
    {
        Task<IEnumerable<Incidente>> BuscarPorRegiaoAsync(double latitude, double longitude);
        Task<IEnumerable<Incidente>> BuscarPorUsuarioAsync(int idUsuario);
        Task<IEnumerable<Incidente>> BuscarUltimosAsync(int qtdUltimosIncidentes);
    }
}