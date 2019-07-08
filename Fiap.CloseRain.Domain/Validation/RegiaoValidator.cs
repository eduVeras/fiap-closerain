using Fiap.CloseRain.Domain.Entities;
using FluentValidation;

namespace Fiap.CloseRain.Domain.Validation
{
    public class RegiaoValidator : AbstractValidator<Regiao>
    {
        public RegiaoValidator()
        {
            RuleFor(x => x.Cep).NotNull().Length(8).Must(BeAValidCep).WithMessage("Cep inválido");
            RuleFor(x => x.Logradouro).NotNull().MinimumLength(5);
            RuleFor(x => x.Bairro).NotNull().MinimumLength(5);
            RuleFor(x => x.Municipio).NotNull();
            RuleFor(x => x.Uf).NotNull().Length(2);
            RuleFor(x => x.Pais).NotNull();
            RuleFor(x => x.Latitude).NotNull();
            RuleFor(x => x.Longitude).NotNull();
        }

        public bool BeAValidCep(string cep)
        {
            return true;
        }
    }
}
