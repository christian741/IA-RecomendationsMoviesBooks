using FluentValidation;
using MovBooks.Core.DTOs;

namespace MovBooks.Infrastructure.Validators
{
    public class PqrValidator : AbstractValidator<PqrDto>
    {
        public PqrValidator()
        {
            RuleFor(x => x.Description)
                .NotNull().WithMessage("La descripción es requerida");

            RuleFor(x => x.UserId)
                .NotNull().WithMessage("El id del usuario es requerido");

            RuleFor(x => x.Answer)
                .MaximumLength(255).WithMessage("La respuesta no debe contener más de 255 carácteres");
        }
    }
}
