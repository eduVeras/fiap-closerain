using System;

namespace Fiap.CloseRain.Domain.Entities
{
    public class Tweeteds
    {
        public Tweeteds()
        {
            
        }

        public Tweeteds(int idIncidente, string mensagem)
        {
            IdIncidente = idIncidente;
            Mensagem = mensagem;
            DataPublicacao = DateTime.Now;
        }
        public int  IdTweet { get; set; }
        public int IdIncidente { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataPublicacao { get; set; }
    }
}
