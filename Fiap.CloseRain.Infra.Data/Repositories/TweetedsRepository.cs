using Fiap.CloseRain.Domain.Entities;
using Fiap.CloseRain.Domain.Interfaces.Repository;
using Fiap.CloseRain.Infra.Data.Context;

namespace Fiap.CloseRain.Infra.Data.Repositories
{
    public class TweetedsRepository : BaseRepository<Tweeteds>, ITweetedsRepository
    {
        public TweetedsRepository(CloseRainContext context) : base(context)
        {
        }
    }
}
