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
        }
        public IActionResult RegisterUser(UserInfoViewModel userInfo)
        {
            _apiService.Save(userInfo);
            return View();
        }
    }
}
