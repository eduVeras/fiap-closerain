using Fiap.CloseRain.Domain.Entities;
using Fiap.CloseRain.Domain.Interfaces.Application;
using Fiap.CloseRain.Domain.Interfaces.Repository;
using Fiap.CloseRain.Domain.Interfaces.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fiap.CloseRain.Application.Applications
{
    public class IncidenteApplication : BaseApplication<Incidente>, IIncidenteApplication
    {

        private readonly ITwitterService _twitterService;
        private readonly IIncidenteRepository _incidenteRepository;
        private readonly ITweetedsRepository _tweetedsRepository;
        public IncidenteApplication(ITwitterService twitterService,
            IIncidenteRepository incidenteRepository, ITweetedsRepository tweetedsRepository)
            : base(incidenteRepository)
        {
            _twitterService = twitterService;
            _incidenteRepository = incidenteRepository;
            _tweetedsRepository = tweetedsRepository;
        }

        public async Task<IEnumerable<Incidente>> BuscarPorUsuarioAsync(int idUsuario)
        {
            return await _incidenteRepository.BuscarPorUsuarioAsync(idUsuario);
        }

        public async Task<IEnumerable<Incidente>> BuscarUltimosAsync(int qtdUltimosIncidentes)
        {
            return await _incidenteRepository.BuscarUltimosAsync(qtdUltimosIncidentes);
        }

        public override async Task InserirAsync(Incidente entity)
        {
            await _incidenteRepository.InserirAsync(entity);

            var tweet = entity.CreateTweet();

            await _twitterService.TweetWithCoordinates(tweet);

            entity.OnSuccessPublish();

            await _incidenteRepository.AtualizarAsync(entity);

            await _tweetedsRepository.InserirAsync(new Tweeteds(entity.IdIncidente, tweet.Message));

        }
    }
}
