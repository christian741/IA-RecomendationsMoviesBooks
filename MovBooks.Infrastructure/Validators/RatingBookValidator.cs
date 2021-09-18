using FluentValidation;
using MovBooks.Core.Entities;

namespace MovBooks.Infrastructure.Validators
{
    public class RatingBookValidator : AbstractValidator<RatingBook>
    {
        public RatingBookValidator()
        {
            RuleFor(x => x.UserId)
                .NotNull().WithMessage("El id del usuario es requerido");

            RuleFor(x => x.BookId)
                .NotNull().WithMessage("El id del libro es requerido");

            RuleFor(x => x.Rating)
                .NotNull().WithMessage("La calificación es requerida");

            RuleFor(x => x.Comment)
                .NotNull().WithMessage("El comentario es requerido");
        }
    }
}
