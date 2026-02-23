using Restaurant.WebUI.Models;
using Restaurant.WebUI.Services.Interfaces;
using System.Security.Claims;

namespace Restaurant.WebUI.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetAllUserCount()
        {
           return await _httpClient.GetFromJsonAsync<int>("/api/users/getallusercount");
           
        }

        public async Task<UserDetailViewModel> GetUserInfo()
        {
            return await _httpClient.GetFromJsonAsync<UserDetailViewModel>("/api/users/getuser");
        }
    }
}
