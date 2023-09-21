using ManagePeople.Business.MappingProfiles;
using ManagePeople.Data.DataModels.User;
using ManagePeople.Repository.Interface;
using ManagePeople.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace ManagePeople.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;
        public UserController(IUserRepository repository)
        {
            _repository= repository;
        }

        [Route("Login")]
        [HttpPost]
        public async Task<bool> Login(UserInfoViewModel userInfo)
        {
            var userInfoModel = ObjectMapper.Mapper.Map<UserInfo>(userInfo);
            var results = await _repository.AllowUserLogin(userInfoModel);
            return results;
        }

        [HttpPost]
        public async Task<int> RegisterUser(UserInfoViewModel userInfo)
        {
            var userInfoModel = ObjectMapper.Mapper.Map<UserInfo>(userInfo);
            return await _repository.Register(userInfoModel);
        }
    }
}
