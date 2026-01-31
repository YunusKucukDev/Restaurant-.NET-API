using Restaurant.WebUI.Models;

namespace Restaurant.WebUI.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDetailViewModel> GetUserInfo();
    }
}
