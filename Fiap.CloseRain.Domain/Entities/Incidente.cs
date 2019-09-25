using Fiap.CloseRain.Domain.Enum;
using System;
using System.Runtime.CompilerServices;
using Fiap.CloseRain.Domain.Entities.Services;
using Fiap.CloseRain.Domain.Model;

namespace Fiap.CloseRain.Domain.Entities
{
    public sealed class Incidente
    {
        public Incidente()
        {
            Publicado = false;
            DataIncidente = DateTime.Now;
            DataPublicacao = null;
        }

        public Incidente(ETipoIncidente tipoIncidente, Usuario usuario, Regiao regiao)
        {
            TipoIncidente = tipoIncidente;
            Usuario = usuario;
            Regiao = regiao;
            Publicado = false;
            DataIncidente = DateTime.Now;
            DataPublicacao = null;
        }

        public int IdIncidente { get; set; }
        public int IdUsuario { get; set; }
        public int IdRegiao { get; set; }
        public ETipoIncidente TipoIncidente { get; set; }
        public Usuario Usuario { get; set; }
        public Regiao Regiao { get; set; }
        public bool Publicado { get; set; }
        public DateTime DataIncidente { get; set; }
        public DateTime? DataPublicacao { get; set; }

        public Notification<Incidente> IsValid()
        {
            var notification = new Notification<Incidente>(this);

            var usuario = Usuario.IsValid();
            if (usuario.HasErrors())
                notification.AddError(usuario.Errors);

            var regiao = Regiao.IsValid();
            if (regiao.HasErrors())
                notification.AddError(regiao.Errors);

            return notification;
        }

        public void OnSuccessPublish()
        {
            this.DataPublicacao = DateTime.Now;
            this.Publicado = true;
        }

        public Tweet CreateTweet()
        {
            return new Tweet($"A região encontra-se alagada, tome cuidado! {Regiao.GetPolicyByState()}", Regiao.Latitude, Regiao.Longitude);
        }

        /*
         * SELECT * 
         *  FROM Incidente 
         *  WHERE acos(sin(radians(-23.5919651)) * sin(Lat) + cos(1.3963) * cos(Lat) * cos(Lon - (radians(-46.6910617)))) * 6371 <= 5;
         */
    }
}
