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
                .WithMessage("Tamanha minimo de nome não informado.");


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
                .Must(nascimento => BeOverMinimum(nascimento, 18))
                .WithMessage("Usuario não possui a idade minima para cadastro");

        }


        public bool BeOverMinimum(DateTime nascimento, int minimum)
        {
            return nascimento.AddYears(minimum) > DateTime.Now;
        }
    }
}
