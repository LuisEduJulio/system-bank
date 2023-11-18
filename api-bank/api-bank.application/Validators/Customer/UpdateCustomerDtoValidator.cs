using api_bank.domain.Dtos.CustomerDto;
using FluentValidation;

namespace api_bank.application.Validators.Customer
{
    public class UpdateCustomerDtoValidator : AbstractValidator<UpdateCustomerDto>
    {
        public UpdateCustomerDtoValidator()
        {
            RuleFor(pessoa => pessoa.Id)
                .NotEmpty()
                .WithMessage("Inform the customer id!");

            RuleFor(pessoa => pessoa.BankEntityId)
                .NotEmpty()
                .WithMessage("Inform the bank id!");
        }
    }
}
