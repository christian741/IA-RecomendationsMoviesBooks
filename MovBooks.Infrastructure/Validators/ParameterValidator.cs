using FluentValidation;
using MovBooks.Core.DTOs;

namespace MovBooks.Infrastructure.Validators
{
    public class ParameterValidator : AbstractValidator<ParameterDto>
    {
        public ParameterValidator()
        {
            RuleFor(x => x.Key)
                .NotNull().WithMessage("La llave es requerida")
                .MaximumLength(255).WithMessage("La llave no debe contener más de 255 carácteres");

            RuleFor(x => x.Value)
                .NotNull().WithMessage("El valor es requerido")
                .MaximumLength(255).WithMessage("El valor no debe contener más de 255 carácteres");
        }
    }
}
