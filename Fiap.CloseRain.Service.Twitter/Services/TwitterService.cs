using System.Net;

namespace Fiap.CloseRain.Service.Twitter.Services
{
    public class TwitterService
    {
        public void Lembrar()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }
    }
}