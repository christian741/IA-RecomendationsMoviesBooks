using FluentValidation;
using MovBooks.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovBooks.Infrastructure.Validators
{
    public class GenreValidator : AbstractValidator<Genre>
    {
        public GenreValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("El nombre es requerido")
                .MaximumLength(50).WithMessage("El nombre no debe contener más de 50 carácters");


        }
    }
}
