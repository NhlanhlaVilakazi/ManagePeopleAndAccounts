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

        [HttpPost]
        public async Task<int> RegisterUser(UserInfoViewModel userInfo)
        {
            var userInfoModel = ObjectMapper.Mapper.Map<UserInfo>(userInfo);
            return await _repository.Register(userInfoModel);
        }
    }
}
