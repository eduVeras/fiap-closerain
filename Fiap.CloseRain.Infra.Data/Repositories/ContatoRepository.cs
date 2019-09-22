using Fiap.CloseRain.Domain.Entities;
using Fiap.CloseRain.Domain.Interfaces.Repository;
using Fiap.CloseRain.Infra.Data.Context;

namespace Fiap.CloseRain.Infra.Data.Repositories
{
    public class ContatoRepository : BaseRepository<Contato>, IContatoRepository
    {
        public ContatoRepository(CloseRainContext context) : base(context)
        {
        }
    }
}
