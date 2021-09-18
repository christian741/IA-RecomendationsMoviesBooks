using FluentValidation;
using MovBooks.Core.DTOs;

namespace MovBooks.Infrastructure.Validators
{
    public class PasswordRecoveryValidator : AbstractValidator<PasswordRecoveryDto>
    {
        public PasswordRecoveryValidator()
        {
            RuleFor(x => x.Email)
                .NotNull().WithMessage("El email es requerido")
                .MaximumLength(50).WithMessage("El email no debe contener más de 50 carácteres");

            RuleFor(x => x.Token)
                .MaximumLength(50).WithMessage("El token no debe contener más de 50 carácteres");
        }
    }
}
