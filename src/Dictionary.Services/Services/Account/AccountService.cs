using System;
using System.Threading.Tasks;
using Dictionary.Services.Configs;
using Dictionary.Services.Models.Account;
using FluentValidation;

namespace Dictionary.Services.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly UserCredentialsModelValidator _userCredentialsModelValidator;
        private readonly AccountConfig _accountConfig;

        public AccountService(UserCredentialsModelValidator userCredentialsModelValidator, AccountConfig accountConfig)
        {
            _accountConfig = accountConfig;
            _userCredentialsModelValidator = userCredentialsModelValidator;
        }
        public async Task<bool> UserWithCredentialsExists(UserCredentialsModel model)
        {
            await _userCredentialsModelValidator.ValidateAndThrowAsync(model);
            
            if(string.IsNullOrEmpty(_accountConfig.AdminPassword))
                throw new ArgumentNullException(_accountConfig.AdminPassword);
            
            bool exists = _accountConfig.AdminPassword == model.Password && _accountConfig.AdminUsername == model.Username;

            return exists;
        }
    }
}