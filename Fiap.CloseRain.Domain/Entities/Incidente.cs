using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Fiap.CloseRain.Domain.Enum;

namespace Fiap.CloseRain.Domain.Entities
{
    public class Incidente
    {
        public int IdUsuario { get; set; }
        public int IdRegiao { get; set; }
        public ETipoIncidente TipoIncidente { get; set; }
        public Usuario Usuario { get; set; }
        public Regiao Regiao { get; set; }
    }
}
