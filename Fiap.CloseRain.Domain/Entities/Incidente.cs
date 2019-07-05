using Fiap.CloseRain.Domain.Enum;
using System;

namespace Fiap.CloseRain.Domain.Entities
{
    public class Incidente
    {
        public Incidente() { }

        public Incidente(int idUsuario, int idRegiao, ETipoIncidente tipoIncidente, Usuario usuario, Regiao regiao, bool publicado, DateTime dataIncidente, DateTime dataPublicacao)
        {
            IdUsuario = idUsuario;
            IdRegiao = idRegiao;
            TipoIncidente = tipoIncidente;
            Usuario = usuario;
            Regiao = regiao;
            Publicado = publicado;
            DataIncidente = dataIncidente;
            DataPublicacao = dataPublicacao;
        }

        public int IdUsuario { get; set; }
        public int IdRegiao { get; set; }
        public ETipoIncidente TipoIncidente { get; set; }
        public Usuario Usuario { get; set; }
        public Regiao Regiao { get; set; }
        public bool Publicado { get; set; }
        public DateTime DataIncidente { get; set; }
        public DateTime DataPublicacao { get; set; }

    }
}
