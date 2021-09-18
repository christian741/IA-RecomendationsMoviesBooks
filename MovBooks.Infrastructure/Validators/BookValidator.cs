using FluentValidation;
using MovBooks.Core.DTOs;

namespace MovBooks.Infrastructure.Validators
{
    public class BookValidator : AbstractValidator<BookDto>
    {
        public BookValidator()
        {
            RuleFor(x => x.Title)
                .NotNull().WithMessage("El título es requerido")
                .MaximumLength(255).WithMessage("El título no debe contener más de 255 carácters");
        }
    }
}
