using Dictionary.Services.Models.User;

namespace Dictionary.Services.Services.User
{
    public class UserService : IUserService
    {
        public UserInfo GetUserInfo(string username)
        {
            return new UserInfo(username);
        }
    }
}