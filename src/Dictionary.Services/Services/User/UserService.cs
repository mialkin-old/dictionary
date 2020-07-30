using Dictionary.Services.Models.User;

namespace Dictionary.Services.Services.User
{
    public class UserService : IUserService
    {
        public UserInfoModel GetUserInfo(string username)
        {
            return new UserInfoModel(username);
        }
    }
}