using System;
using System.Threading.Tasks;
using Dictionary.Services.Configs;
using Dictionary.Services.Models.Account;
using FluentValidation;

namespace Dictionary.Services.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly UserCredentialsValidator _userCredentialsValidator;
        private readonly UserCredentialsConfig _userCredentialsConfig;

        public AccountService(UserCredentialsValidator userCredentialsValidator, UserCredentialsConfig userCredentialsConfig)
        {
            _userCredentialsConfig = userCredentialsConfig;
            _userCredentialsValidator = userCredentialsValidator;
        }

        public async Task<bool> UserExists(UserCredentials userCredentials)
        {
            await _userCredentialsValidator.ValidateAndThrowAsync(userCredentials);

            if (string.IsNullOrEmpty(_userCredentialsConfig.Password))
                throw new ArgumentNullException(_userCredentialsConfig.Password);

            bool exists = _userCredentialsConfig.Password == userCredentials.Password && _userCredentialsConfig.Username == userCredentials.Username;

            return exists;
        }
    }
}