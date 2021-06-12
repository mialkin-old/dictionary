using System.Threading.Tasks;
using Dictionary.Services.Models.Account;
using FluentValidation;

namespace Dictionary.Services.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly UserCredentialsValidator _userCredentialsValidator;
        private readonly string _username;
        private readonly string _password;

        public AccountService(UserCredentialsValidator userCredentialsValidator, string username, string password)
        {
            _userCredentialsValidator = userCredentialsValidator;
            _username = username;
            _password = password;
        }

        public async Task<bool> UserExists(UserCredentials userCredentials)
        {
            await _userCredentialsValidator.ValidateAndThrowAsync(userCredentials);

            return _username == userCredentials.Username && _password == userCredentials.Password;
        }
    }
}