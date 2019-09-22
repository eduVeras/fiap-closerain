using Fiap.CloseRain.Domain.Entities;
using Fiap.CloseRain.Domain.Interfaces.Repository;
using Fiap.CloseRain.Infra.Data.Context;

namespace Fiap.CloseRain.Infra.Data.Repositories
{
    public class RegiaoRepository : BaseRepository<Regiao>, IRegiaoRepository
    {
        public RegiaoRepository(CloseRainContext context) : base(context)
        {
        }
    }
}
