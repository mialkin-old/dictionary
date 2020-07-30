using Dictionary.Services.Configs;
using Dictionary.Services.Models.Account;
using Dictionary.Services.Services.Account;
using FluentValidation;
using NUnit.Framework;

namespace Dictionary.Tests.Services
{
    [TestFixture]
    public class AccountServiceTest
    {
        [Test]
        public void InvalidCredentials(
            [Values(null, "", " ", "   ")] string username,
            [Values(null, "", " ", "   ")] string password)
        {
            var accountService =
                new AccountService(new AccountConfig("adminPass"), new UserCredentialsModelValidator());
            var model = new UserCredentialsModel(username, password);

            Assert.ThrowsAsync<ValidationException>(async () => await accountService.UserWithCredentialsExists(model));
        }

        public void ValidCredentials(
            [Values("a", "admin")] string username,
            [Values("p", "password")] string password)
        {
            var accountService =
                new AccountService(new AccountConfig("adminPass"), new UserCredentialsModelValidator());
            var model = new UserCredentialsModel(username, password);

            accountService.UserWithCredentialsExists(model);
        }
    }
}