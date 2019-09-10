using Fiap.CloseRain.Domain.Entities;
using Fiap.CloseRain.Domain.Interfaces.Application;
using Fiap.CloseRain.Domain.Interfaces.Base;

namespace Fiap.CloseRain.Application.Applications
{
    public class ContatoApplication : BaseApplication<Contato,int>, IContatoApplication
    {
        public ContatoApplication(IBaseRepository<Contato, int> baseRepository) : base(baseRepository)
        {
        }
    }
}
