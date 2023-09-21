using ManagePeople.Business.ApiCallService;
using ManagePeople.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace ManagePeople.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IApiCallService<UserInfoViewModel> _apiService;
        public UserController(IApiCallService<UserInfoViewModel> apiService)
        {
            _apiService = apiService;
            _apiService.requestUrl = "User";
        }

        [HttpPost]
        public async Task<bool> Login(UserInfoViewModel userInfo)
        {
            var results = await _apiService.Login(userInfo);
            return results;
        }

        [HttpPost]
        public async Task<int> RegisterUser(UserInfoViewModel userInfo)
        {
            var results = await _apiService.Save(userInfo);
            return (int) results;
        }
    }
}
