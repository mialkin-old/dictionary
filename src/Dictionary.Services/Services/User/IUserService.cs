using Dictionary.Services.Models.User;

namespace Dictionary.Services.Services.User
{
    public interface IUserService
    {
        UserInfo GetUserInfo(string username);
    }
}