using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Fiap.CloseRain.Domain.Entities
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime Nascimento { get; set; }
        public bool Ativo { get; set; }

    }
}
