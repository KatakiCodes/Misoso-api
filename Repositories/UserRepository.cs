using Dapper;
using Dapper.Contrib.Extensions;
using Misoso.api.Contracts;
using Misoso.api.Entities;
using Misoso.Api.Repositories;
using System.Data;

namespace Misoso.api.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration)
        {}

        public async Task<User> CreateUserAsync(User user)
        {
            string sql = "INSERT INTO Users (Email, UserName, Password) OUTPUT INSERTED.ID VALUES (@Email, @UserName, @Password);";
            var createdId = await _Connection.ExecuteScalarAsync<int>(sql,
                new
                {
                    user.Email,
                    user.UserName,
                    user.Password
                }
            );
            return await GetUserByIdAsync(createdId);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _Connection.GetAsync<User>(id);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _Connection.GetAllAsync<User>();
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            await _Connection.UpdateAsync(user);
            return user;
        }
    }
}
