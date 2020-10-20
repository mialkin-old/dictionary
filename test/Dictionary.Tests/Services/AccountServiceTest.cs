using System.Threading.Tasks;
using Dictionary.Services.Configs;
using Dictionary.Services.Models.Account;
using Dictionary.Services.Services.Account;
using FluentValidation;
using NUnit.Framework;
using UserCredentials = Dictionary.Services.Models.Account.UserCredentials;

namespace Dictionary.Tests.Services
{
    [TestFixture]
    public class AccountServiceTest
    {
        [Test]
        public void InvalidUsername([Values(null, "", " ", "   ")] string username)
        {
            var accountService =
                new AccountService(new UserCredentialsValidator(),
                    new Dictionary.Services.Configs.UserCredentialsConfig("admin", "password"));
            var model = new UserCredentials(username, "password");

            Assert.ThrowsAsync<ValidationException>(async () => await accountService.UserExists(model));
        }

        [Test]
        public void InvalidPassword([Values(null, "", " ", "   ")] string password)
        {
            var accountService =
                new AccountService(new UserCredentialsValidator(),
                    new Dictionary.Services.Configs.UserCredentialsConfig("admin", "password"));
            var model = new UserCredentials("admin", password);

            Assert.ThrowsAsync<ValidationException>(async () => await accountService.UserExists(model));
        }

        [Test]
        public void InvalidCredentials(
            [Values(null, "", " ", "   ")] string username,
            [Values(null, "", " ", "   ")] string password)
        {
            var accountService = new AccountService(new UserCredentialsValidator(), new Dictionary.Services.Configs.UserCredentialsConfig("admin", "password"));
            var model = new UserCredentials(username, password);

            Assert.ThrowsAsync<ValidationException>(async () => await accountService.UserExists(model));
        }

        [Test]
        public void ValidCredentials(
            [Values("a", "admin")] string username,
            [Values("p", "password")] string password)
        {
            var accountService = new AccountService(new UserCredentialsValidator(), new Dictionary.Services.Configs.UserCredentialsConfig("admin", "password"));
            var model = new UserCredentials(username, password);

            accountService.UserExists(model);
        }

        [TestCase("admin", "password", "admin", "password")]
        [TestCase("ADMIN", "password", "ADMIN", "password")]
        [TestCase("admin", "PASSWORD", "admin", "PASSWORD")]
        public async Task UserWithCredentialsExists(string username, string password, string adminUsername,
            string adminPassword)
        {
            var accountService = new AccountService(new UserCredentialsValidator(), new Dictionary.Services.Configs.UserCredentialsConfig(adminUsername, adminPassword));
            var model = new UserCredentials(username, password);

            bool exists = await accountService.UserExists(model);

            Assert.IsTrue(exists);
        }

        [TestCase("admin", "password", "wrong-username", "password")]
        [TestCase("admin", "password", "admin", "wrong-password")]
        [TestCase("admin", "password", "admin", "PASSWORD")]
        [TestCase("admin", "password", "ADMIN", "password")]
        public async Task UserWithCredentialsDoesntExist(string username, string password, string adminUsername,
            string adminPassword)
        {
            var accountService = new AccountService(new UserCredentialsValidator(), new Dictionary.Services.Configs.UserCredentialsConfig(adminUsername, adminPassword));
            var model = new UserCredentials(username, password);

            bool exists = await accountService.UserExists(model);

            Assert.IsFalse(exists);
        }
    }
}