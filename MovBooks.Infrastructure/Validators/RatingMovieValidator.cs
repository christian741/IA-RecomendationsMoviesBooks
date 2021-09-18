using FluentValidation;
using MovBooks.Core.Entities;

namespace MovBooks.Infrastructure.Validators
{
    public class RatingMovieValidator : AbstractValidator<RatingMovie>
    {
        public RatingMovieValidator()
        {
            RuleFor(x => x.UserId)
                .NotNull().WithMessage("El id del usuario es requerido");

            RuleFor(x => x.MovieId)
                .NotNull().WithMessage("El id de la película es requerido");

            RuleFor(x => x.Rating)
                .NotNull().WithMessage("La calificación es requerida");

            RuleFor(x => x.Comment)
                .NotNull().WithMessage("El comentario es requerido");
        }
    }
}
