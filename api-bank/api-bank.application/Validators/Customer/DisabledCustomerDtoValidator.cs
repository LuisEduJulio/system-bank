using api_bank.domain.Dtos.CustomerDto;
using FluentValidation;

namespace api_bank.application.Validators.Customer
{
    public class DisabledCustomerDtoValidator : AbstractValidator<DisabledCustomerDto>
    {
        public DisabledCustomerDtoValidator()
        {
            RuleFor(pessoa => pessoa.Id)
                .NotEmpty()
                .WithMessage("O campo Nome é obrigatório.");
        }
    }
}