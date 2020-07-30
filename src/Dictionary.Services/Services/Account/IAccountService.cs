using System.Threading.Tasks;
using Dictionary.Services.Models.Account;

namespace Dictionary.Services.Services.Account
{
    public interface IAccountService
    {
        Task<bool> UserWithCredentialsExists(UserCredentialsModel model);
    }
}