using api_bank.domain.Dtos.BankDto;
using FluentValidation;

namespace api_bank.application.Validations.Bank
{
    public class AddBankDtoValidator : AbstractValidator<AddBankDto>
    {
        public AddBankDtoValidator()
        {
            RuleFor(bank => bank.Name)
                .NotEmpty()
                .WithMessage("Inform number a name the bank!");

            RuleFor(bank => bank.Number)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Inform number the bank!");
        }
    }
}