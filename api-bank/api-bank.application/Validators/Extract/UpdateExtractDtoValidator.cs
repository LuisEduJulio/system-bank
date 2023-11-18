using api_bank.domain.Dtos;
using FluentValidation;

namespace api_bank.application.Validators.Extract
{
    public class UpdateExtractDtoValidator : AbstractValidator<UpdateExtractDto>
    {
        public UpdateExtractDtoValidator()
        {
            RuleFor(pessoa => pessoa.Id)
                .NotEmpty()
                .WithMessage("O campo Nome é obrigatório.");
        }
    }
}
