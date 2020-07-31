using FluentValidation;

namespace Dictionary.Services.Models.Account
{
    public class UserCredentialsModelValidator: AbstractValidator<UserCredentialsModel>
    {
        public UserCredentialsModelValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }   
    }
}