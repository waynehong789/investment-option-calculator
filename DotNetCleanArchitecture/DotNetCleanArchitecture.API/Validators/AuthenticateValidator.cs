using DotNetCleanArchitecture.API.Models;
using FluentValidation;

namespace DotNetCleanArchitecture.API.Validators
{
    public class AuthenticateValidator : AbstractValidator<IAuthenticateRequest>
    {
        public AuthenticateValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}