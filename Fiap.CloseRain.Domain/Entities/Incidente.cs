using Fiap.CloseRain.Domain.Enum;
using System;
using Fiap.CloseRain.Domain.Model;

namespace Fiap.CloseRain.Domain.Entities
{
    public sealed class Incidente
    {
        private Incidente() { }

        public Incidente(ETipoIncidente tipoIncidente, Usuario usuario, Regiao regiao)
        {
            TipoIncidente = tipoIncidente;
            Usuario = usuario;
            Regiao = regiao;
            Publicado = false;
            DataIncidente = DateTime.Now;
            DataPublicacao = null;
        }

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

        /*
         * SELECT * 
         *  FROM Incidente 
         *  WHERE acos(sin(radians(-23.5919651)) * sin(Lat) + cos(1.3963) * cos(Lat) * cos(Lon - (radians(-46.6910617)))) * 6371 <= 5;
         */
    }
}
