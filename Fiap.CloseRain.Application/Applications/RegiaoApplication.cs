using Fiap.CloseRain.Domain.Entities;
using Fiap.CloseRain.Domain.Interfaces.Application;
using Fiap.CloseRain.Domain.Interfaces.Base;

namespace Fiap.CloseRain.Application.Applications
{
    public class RegiaoApplication : BaseApplication<Regiao,int>, IRegiaoApplication
    {
        public RegiaoApplication(IBaseRepository<Regiao, int> baseRepository) : base(baseRepository)
        {
        }
    }
}
