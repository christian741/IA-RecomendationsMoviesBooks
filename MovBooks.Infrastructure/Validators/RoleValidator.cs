using FluentValidation;
using MovBooks.Core.DTOs;

namespace MovBooks.Infrastructure.Validators
{
    public class RoleValidator : AbstractValidator<RoleDto>
    {
        public RoleValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("El nombre es requerido")
                .MaximumLength(50).WithMessage("El nombre no debe contener más de 50 carácteres");
        }
    }
}
