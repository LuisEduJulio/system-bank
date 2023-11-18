using api_bank.domain.Dtos.CustomerDto;
using FluentValidation;

namespace api_bank.application.Validators.Customer
{
    public class AddCustomerDtoValidator : AbstractValidator<AddCustomerDto>
    {
        public AddCustomerDtoValidator()
        {
            RuleFor(customer => customer.Name)
                .NotEmpty()
                .WithMessage("The name is required!");

            RuleFor(customer => customer.LastName)
                .NotEmpty()
                .WithMessage("The last name is required!");

            RuleFor(customer => customer.Email)
              .NotEmpty()
              .EmailAddress()
              .WithMessage("The email is required!");

            RuleFor(customer => customer.BankEntityId)
             .NotEmpty()
             .WithMessage("The bank is required!");
        }
    }
}
