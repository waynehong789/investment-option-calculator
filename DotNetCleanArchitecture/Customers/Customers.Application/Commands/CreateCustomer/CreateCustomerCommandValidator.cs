using FluentValidation;

namespace Customers.Application.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Invalid FirstName field");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Invalid LastName field");
        }

    }
}