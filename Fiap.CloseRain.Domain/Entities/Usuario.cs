using System;
using System.Security.Cryptography;
using System.Text;
using Fiap.CloseRain.Domain.Model;
using Fiap.CloseRain.Domain.Validation;

namespace Fiap.CloseRain.Domain.Entities
{
    public class Usuario
    {
        protected Usuario() { }

        public Usuario(string nome, string email, string senha, DateTime nascimento)
        {   
            Nome = nome;
            Email = email;
            Senha = senha;
            Nascimento = nascimento;
            Ativo = true;
            DataCadastro = DateTime.Now;
            SetCryptSenha(senha);
        }

        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime Nascimento { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }


        public Notification IsValid()
        {
            var validate = new UsuarioValidator().Validate(this);
            return validate;
        }

        public void AtualizarDataCadasto(DateTime data)
        {
            if (data < this.DataCadastro)
                throw new ArgumentException("Data menor que a existente.", nameof(data));

            this.DataCadastro = data;
        }

        private void GetCryptSenha()
        {

        }

        private void SetCryptSenha(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("s@F&"));
                }

                this.Senha = builder.ToString();
            }

        }

        public void Desativar()
        {
            this.Ativo = false;
        }

    }
}
