using Fiap.CloseRain.Domain.Entities;
using Fiap.CloseRain.Domain.Interfaces.Application;
using Fiap.CloseRain.Domain.Interfaces.Base;
using Fiap.CloseRain.Domain.Interfaces.Repository;
using Fiap.CloseRain.Domain.Interfaces.Service;
using System.Threading.Tasks;

namespace Fiap.CloseRain.Application.Applications
{
    public class IncidenteApplication : BaseApplication<Incidente,int>, IIncidenteApplication
    {

        private readonly ITwitterService _twitterService;
        private readonly IIncidenteRepository _incidenteRepository;
        public IncidenteApplication(IBaseRepository<Incidente, int> baseRepository,
            ITwitterService twitterService,
            IIncidenteRepository incidenteRepository) 
            : base(baseRepository)
        {
            _twitterService = twitterService;
            _incidenteRepository = incidenteRepository;
        }


        public override async Task InserirAsync(Incidente entity)
        {
            await _incidenteRepository.InserirAsync(entity);

            var tweet = entity.CreateTweet();

            await _twitterService.TweetWithCoordinates(tweet);

            entity.OnSuccessPublish();

            await _incidenteRepository.AtualizarAsync(entity);

        }
    }
}
