namespace Fiap.CloseRain.Domain.Entities.Services
{
    public class Tweet
    {

        public Tweet()
        {
            Message = TwitterMessage;
        }
        public Tweet(string message)
        {
            SetMessage(message);
        }

        public Tweet(double latitude, double longitude)
        {
            SetMessage(string.Empty);
            Latitude = latitude;
            Longitude = longitude;
        }
        public Tweet(string message, double latitude, double longitude)
        {
            SetMessage(message);
            Latitude = latitude;
            Longitude = longitude;
        }
        public string Message { get; private set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        private string TwitterMessage => "A região encontra-se alagada, tome cuidado!";

        public void SetMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                Message = TwitterMessage;
                return;
            }
            Message = message;
        }


    }
}
