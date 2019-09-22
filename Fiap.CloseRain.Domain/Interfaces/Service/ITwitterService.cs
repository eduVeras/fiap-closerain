using System.Net;
using System.Threading.Tasks;
using Fiap.CloseRain.Domain.Entities.Services;

namespace Fiap.CloseRain.Domain.Interfaces.Service
{
    public interface ITwitterService
    {   
        Task<bool> Tweet(Tweet tweet);
        Task<bool> TweetWithCoordinates(Tweet tweet);
    }
}