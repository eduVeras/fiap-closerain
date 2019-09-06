using System.Threading.Tasks;
using Fiap.CloseRain.Domain.Entities;
using Fiap.CloseRain.Domain.Entities.Services;
using Fiap.CloseRain.Domain.Interfaces.Application;
using Fiap.CloseRain.Domain.Interfaces.Base;
using Fiap.CloseRain.Domain.Interfaces.Repository;
using Fiap.CloseRain.Domain.Interfaces.Service;

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
            var tweet = new Tweet(entity.Regiao.Latitude, entity.Regiao.Longitude);
            await _twitterService.TweetWithCoordinates(tweet);

        }
    }
}
