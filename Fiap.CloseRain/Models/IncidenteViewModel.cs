using Fiap.CloseRain.Domain.Entities;
using Fiap.CloseRain.Domain.Enum;

namespace Fiap.CloseRain.Models
{
    public class IncidenteViewModel
    {

        public UsuarioViewModel Usuario { get; set; }
        public Regiao Regiao { get; set; }

        public Incidente Parse()
        {
            return new Incidente(ETipoIncidente.Alagamanto, Usuario.Parse(), Regiao);
        }
    }
}
