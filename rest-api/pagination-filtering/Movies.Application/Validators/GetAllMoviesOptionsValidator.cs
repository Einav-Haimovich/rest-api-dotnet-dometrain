using FluentValidation;
using Movies.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Validators
{
    public class GetAllMoviesOptionsValidator : AbstractValidator<GetAllMoviesOptions>
    {
        private static readonly string[] AcceptableSortFields =
        {
            "title", "year"
        };

        public GetAllMoviesOptionsValidator()
        {
            RuleFor(x => x.Year)
                .LessThanOrEqualTo(DateTime.UtcNow.Year);
            RuleFor(x => x.SortField).Must(x => x is null || AcceptableSortFields.Contains(x, StringComparer.OrdinalIgnoreCase))
                .WithMessage("You can only sort by 'title' or 'year' ");
        }
    }
}
