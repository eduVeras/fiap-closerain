using Fiap.CloseRain.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fiap.CloseRain.Domain.Entities
{
    public sealed class Usuario
    {
        private Usuario() { }

        public Usuario(string nome, string email, string senha, DateTime nascimento)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Nascimento = nascimento;
            Ativo = true;
            DataCadastro = DateTime.Now;
            Senha = senha;
            Incidentes = new List<Incidente>();
        }


        public int IdUsuario { get; set; }
        public int IdRegiao { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime Nascimento { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; }
        public Regiao Regiao { get; set; }
        public IList<Incidente> Incidentes { get; set; }

        /// <summary>
        /// Ultima publicação de um incidente em minutos.
        /// </summary>
        private int? UltimaPublicacao
        {
            get
            {
                var dataPublicacao = Incidentes.OrderByDescending(x => x.DataPublicacao).FirstOrDefault();
                if (dataPublicacao != null)
                    return (DateTime.Now - dataPublicacao.DataPublicacao)?.Minutes;
                return null;
            }
        }

        public Notification<Usuario> IsValid()
        {
            var notification = new Notification<Usuario>(this);

            if (string.IsNullOrWhiteSpace(Nome))
                notification.AddError(nameof(Nome), "Nome deve ser preenchido.");

            if (Nome.Length < 5)
                notification.AddError(nameof(Nome), "Tamanho minimo de nome não informado.");

            if (string.IsNullOrWhiteSpace(Email))
                notification.AddError(nameof(Email), "Email obrigatório.");

            if (string.IsNullOrWhiteSpace(Senha))
                notification.AddError(nameof(Senha), "Senha obrigatória.");

            if (Senha.Length < 8)
                notification.AddError(nameof(Senha), "Tamanho minimo de nome não informado.");

            if (Nascimento.Equals(DateTime.MinValue))
                notification.AddError(nameof(Nascimento), "Nascimento obrigatorio");

            if (!BeOver18(Nascimento))
                notification.AddError(nameof(Nascimento), "Usuario não possui a idade minima para cadastro");

            return notification;
        }

        public void AtualizarDataCadasto(DateTime data)
        {
            if (data < this.DataCadastro)
                throw new ArgumentException("Data menor que a existente.", nameof(data));

            this.DataCadastro = data;
            this.DataUltimaAtualizacao = DateTime.Now;
        }

        public bool PodePublicarIncidente()
        {
            var ultimoIncidente = Incidentes.OrderByDescending(x => x.DataIncidente).FirstOrDefault();

            if (ultimoIncidente == null)
                return true;

            if (ultimoIncidente.Publicado && UltimaPublicacao > 30)
                return true;

            if (UltimaPublicacao < 10)
                return false;

            return false;

        }

        public void Desativar()
        {
            this.Ativo = false;
            this.DataUltimaAtualizacao = DateTime.Now;
        }

        public bool BeOver18(DateTime nascimento)
        {
            var result = nascimento.AddYears(18) > DateTime.Now;
            return nascimento.AddYears(18) < DateTime.Now;
        }

    }
}
