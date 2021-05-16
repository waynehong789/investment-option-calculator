using FluentValidation;

namespace Calculator.Application.Commands.CalculateInvestmentOptions
{
    public class CreateCustomerCommandValidator : AbstractValidator<CalculateInvestmentOptionsCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(x => x.InvestmentAmount).NotEmpty().WithMessage("Invalid InvestmentAmount field");
            RuleFor(x => x.SelectedOptions).NotEmpty().WithMessage("Invalid SelectedOptions field");
        }

    }
}