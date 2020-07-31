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
        private readonly AdminCredentials _adminCredentials;

        public AccountService(UserCredentialsModelValidator userCredentialsModelValidator, AdminCredentials adminCredentials)
        {
            _adminCredentials = adminCredentials;
            _userCredentialsModelValidator = userCredentialsModelValidator;
        }
        public async Task<bool> UserWithCredentialsExists(UserCredentialsModel model)
        {
            await _userCredentialsModelValidator.ValidateAndThrowAsync(model);
            
            if(string.IsNullOrEmpty(_adminCredentials.AdminPassword))
                throw new ArgumentNullException(_adminCredentials.AdminPassword);
            
            bool exists = _adminCredentials.AdminPassword == model.Password && _adminCredentials.AdminUsername == model.Username;

            return exists;
        }
    }
}