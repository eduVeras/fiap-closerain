using Fiap.CloseRain.Domain.Entities;
using Fiap.CloseRain.Domain.Interfaces.Application;
using Fiap.CloseRain.Domain.Interfaces.Base;
using Fiap.CloseRain.Domain.Interfaces.Repository;

namespace Fiap.CloseRain.Application.Applications
{
    public class RegiaoApplication : BaseApplication<Regiao>, IRegiaoApplication
    {
        public RegiaoApplication(IRegiaoRepository regiaoRepository) : base(regiaoRepository)
        {
        }
    }
}
