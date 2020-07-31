using System.Threading.Tasks;
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
        public void InvalidUsername([Values(null, "", " ", "   ")] string username)
        {
            var accountService =
                new AccountService(new UserCredentialsModelValidator(),
                    new AccountConfig("admin", "password"));
            var model = new UserCredentialsModel(username, "password");

            Assert.ThrowsAsync<ValidationException>(async () => await accountService.UserWithCredentialsExists(model));
        }
        
        [Test]
        public void InvalidPassword([Values(null, "", " ", "   ")] string password)
        {
            var accountService =
                new AccountService(new UserCredentialsModelValidator(),
                    new AccountConfig("admin", "password"));
            var model = new UserCredentialsModel("admin", password);

            Assert.ThrowsAsync<ValidationException>(async () => await accountService.UserWithCredentialsExists(model));
        }
        
        [Test]
        public void InvalidCredentials(
            [Values(null, "", " ", "   ")] string username,
            [Values(null, "", " ", "   ")] string password)
        {
            var accountService =
                new AccountService(new UserCredentialsModelValidator(),
                    new AccountConfig("admin", "password"));
            var model = new UserCredentialsModel(username, password);

            Assert.ThrowsAsync<ValidationException>(async () => await accountService.UserWithCredentialsExists(model));
        }

        [Test]
        public void ValidCredentials(
            [Values("a", "admin")] string username,
            [Values("p", "password")] string password)
        {
            var accountService =
                new AccountService(new UserCredentialsModelValidator(),
                    new AccountConfig("admin", "password"));
            var model = new UserCredentialsModel(username, password);

            accountService.UserWithCredentialsExists(model);
        }

        [TestCase("admin", "password", "admin", "password")]
        [TestCase("ADMIN", "password", "ADMIN", "password")]
        [TestCase("admin", "PASSWORD", "admin", "PASSWORD")]
        public async Task UserWithCredentialsExists(string username, string password, string adminUsername, string adminPassword)
        {
            var accountService =
                new AccountService(new UserCredentialsModelValidator(),
                    new AccountConfig(adminUsername, adminPassword));
            var model = new UserCredentialsModel(username, password);

            bool exists = await accountService.UserWithCredentialsExists(model);
            
            Assert.IsTrue(exists);
        }
        
        [TestCase("admin", "password", "wrong-username", "password")]
        [TestCase("admin", "password", "admin", "wrong-password")]
        [TestCase("admin", "password", "admin", "PASSWORD")]
        [TestCase("admin", "password", "ADMIN", "password")]
        public async Task UserWithCredentialsDoesntExist(string username, string password, string adminUsername, string adminPassword)
        {
            var accountService =
                new AccountService(new UserCredentialsModelValidator(),
                    new AccountConfig(adminUsername, adminPassword));
            var model = new UserCredentialsModel(username, password);

            bool exists = await accountService.UserWithCredentialsExists(model);
            
            Assert.IsFalse(exists);
        }
    }
}