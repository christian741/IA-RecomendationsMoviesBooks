using FluentValidation;
using MovBooks.Core.DTOs;

namespace MovBooks.Infrastructure.Validators
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(x => x.Nickname)
                .NotNull().WithMessage("El nickname es requerido")
                .MaximumLength(50).WithMessage("El nickname no debe contener más de 50 carácters");

            RuleFor(x => x.Email)
                .NotNull().WithMessage("El email es requerido")
                .MaximumLength(50).WithMessage("El email no debe contener más de 50 carácters");

            RuleFor(x => x.Password)
                .NotNull().WithMessage("La constraseña es requerida")
                .MaximumLength(50).WithMessage("La contraseña no debe contener más de 50 carácters");

            RuleFor(x => x.RoleId)
                .NotNull().WithMessage("El id del rol es requerido");

            RuleFor(x => x.Avatar)
                .MaximumLength(50).WithMessage("El avatar no debe contener más de 50 carácteres");

            RuleFor(x => x.Image)
                .MaximumLength(255).WithMessage("La imagen no debe contener más de 255 carácteres");
        }
    }
}
