using Fiap.CloseRain.Domain.Entities;
using FluentValidation;

namespace Fiap.CloseRain.Domain.Validation
{
    public class IncidenteValidator : AbstractValidator<Incidente>
    {
        public IncidenteValidator()
        {
            RuleFor(x => x.TipoIncidente).IsInEnum();
            RuleFor(x => x.Usuario).SetValidator(new UsuarioValidator());
            RuleFor(x => x.Regiao).SetValidator(new RegiaoValidator());
        }
    }
}
