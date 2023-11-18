using api_bank.domain.Dtos;
using FluentValidation;

namespace api_bank.application.Validators.Extract
{
    public class AddExtractDtoValidator : AbstractValidator<AddExtractDto>
    {
        public AddExtractDtoValidator()
        {
            RuleFor(pessoa => pessoa.BankEntityId)
                .NotEmpty()
                .WithMessage("O campo Nome é obrigatório.");

            RuleFor(pessoa => pessoa.CustomerEntityId)
                  .NotEmpty()
                  .WithMessage("O campo Nome é obrigatório.");

            RuleFor(pessoa => pessoa.Price)
                 .NotEmpty()
                 .WithMessage("O campo Nome é obrigatório.");

            RuleFor(pessoa => pessoa.Describe)
                .NotEmpty()
                .WithMessage("O campo Nome é obrigatório.");

            RuleFor(pessoa => pessoa.Loose)
              .NotEmpty()
              .WithMessage("O campo Nome é obrigatório.");
        }
    }
}
