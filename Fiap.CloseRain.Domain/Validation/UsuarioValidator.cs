using Fiap.CloseRain.Domain.Entities;
using FluentValidation;
using System;

namespace Fiap.CloseRain.Domain.Validation
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("Nome deve ser preenchido.")
                .MinimumLength(5)
                .WithMessage("Tamanho minimo de nome não informado.");


            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email obrigatório.")
                .EmailAddress();


            RuleFor(x => x.Senha)
                .NotEmpty()
                .WithMessage("Senha obrigatória.")
                .MinimumLength(8);


            RuleFor(x => x.Nascimento)
                .NotEqual(DateTime.MinValue)
                .WithMessage("Data de nascimento deve ser informada.")
                .Must(BeOver18)
                .WithMessage("Usuario não possui a idade minima para cadastro");

        }


        public bool BeOver18(DateTime nascimento)
        {
            return nascimento.AddYears(18) > DateTime.Now;
        }
    }
}
