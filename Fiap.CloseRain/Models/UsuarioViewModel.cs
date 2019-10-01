using Fiap.CloseRain.Domain.Entities;
using System;

namespace Fiap.CloseRain.Models
{
    public class UsuarioViewModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime Nascimento { get; set; }
        public string Telefone { get; set; }

        public Usuario Parse()
        {
            return new Usuario(this.Nome, this.Email, this.Senha, this.Nascimento)
            {
                Telefone = this.Telefone
            };
        }
    }
}
