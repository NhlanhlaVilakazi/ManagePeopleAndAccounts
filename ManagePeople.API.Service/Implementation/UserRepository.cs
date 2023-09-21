using ManagePeople.Data;
using ManagePeople.Data.DataModels.User;
using ManagePeople.Repository.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ManagePeople.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dbContext;
        public UserRepository()
        {
            _dbContext = new DataContext();
        }
        public async Task<bool> AllowUserLogin(UserInfo userInfo)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@username", userInfo.username),
                new SqlParameter("@password", userInfo.password),
                new SqlParameter("@results", 0){  Direction = ParameterDirection.Output, SqlDbType = SqlDbType.Bit }
            };

            await _dbContext.Database.ExecuteSqlRawAsync("[Login] @username, @password, @results OUT", parameters);
            return (bool)(parameters[2].Value ?? false);
        }

        public async Task<int> Register(UserInfo userInfo)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@username", userInfo.username),
                new SqlParameter("@password", userInfo.password)
            };
            const string query = "[RegisterAppUser] @username, @password";
           return await _dbContext.Database.ExecuteSqlRawAsync(query, parameters);
        }
    }
}
