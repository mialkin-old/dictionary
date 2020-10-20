using FluentValidation;

namespace Dictionary.Services.Models.Account
{
    public class UserCredentialsValidator: AbstractValidator<UserCredentials>
    {
        public UserCredentialsValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }   
    }
}