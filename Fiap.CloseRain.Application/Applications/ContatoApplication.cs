using Fiap.CloseRain.Domain.Entities;
using Fiap.CloseRain.Domain.Interfaces.Application;
using Fiap.CloseRain.Domain.Interfaces.Base;
using Fiap.CloseRain.Domain.Interfaces.Repository;

namespace Fiap.CloseRain.Application.Applications
{
    public class ContatoApplication : BaseApplication<Contato>, IContatoApplication
    {

        private readonly IContatoRepository _contatoRepository;
        public ContatoApplication(IContatoRepository baseRepository) : base(baseRepository)
        {
            _contatoRepository = baseRepository;
        }
    }
}
