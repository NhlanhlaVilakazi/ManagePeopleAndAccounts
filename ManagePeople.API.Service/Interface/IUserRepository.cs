using ManagePeople.Data.DataModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ManagePeople.Repository.Interface
{
    public interface IUserRepository
    {
        Task<bool> AllowUserLogin(UserInfo userInfo);
        Task<int> Register(UserInfo userInfo);
    }
}
