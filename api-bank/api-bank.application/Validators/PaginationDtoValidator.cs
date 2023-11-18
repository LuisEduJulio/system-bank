using api_bank.domain.Dtos;
using FluentValidation;

namespace api_bank.application.Validators
{
    public class PaginationDtoValidator : AbstractValidator<PaginationDto>
    {
        public PaginationDtoValidator()
        {
            RuleFor(bank => bank.Page)
                    .NotEmpty()
                    .WithMessage("Inform the number page!");

            RuleFor(bank => bank.Count)
                    .NotEmpty()
                    .GreaterThan(0)
                    .WithMessage("Inform the number count!");
        }
    }
}