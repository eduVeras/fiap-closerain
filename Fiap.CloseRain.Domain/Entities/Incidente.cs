using Fiap.CloseRain.Domain.Enum;
using System;

namespace Fiap.CloseRain.Domain.Entities
{
    public class Incidente
    {
        public Incidente() { }

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

    }
}
