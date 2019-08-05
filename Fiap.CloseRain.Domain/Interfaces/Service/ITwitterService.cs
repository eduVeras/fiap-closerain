using System.Net;
using System.Threading.Tasks;

namespace Fiap.CloseRain.Domain.Interfaces.Service
{
    public interface ITwitterService
    {   
        Task<bool> Tweet(string message);
        Task<bool> TweetWithCoordinates(double longitude, double latitude, string message);
    }
}