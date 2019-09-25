using Fiap.CloseRain.Domain.Entities;
using Fiap.CloseRain.Domain.Interfaces.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fiap.CloseRain.Domain.Interfaces.Application
{
    public interface IIncidenteApplication : IBaseApplication<Incidente>
    {
        Task<IEnumerable<Incidente>> BuscarPorUsuarioAsync(int idUsuario);
        Task<IEnumerable<Incidente>> BuscarUltimosAsync(int qtdUltimosIncidentes);
    }
}