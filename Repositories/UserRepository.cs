using Microsoft.EntityFrameworkCore;
using Misoso.api.Contracts;
using Misoso.api.Entities;
using Misoso.Api.Data;
using Misoso.Api.Repositories;
using System.Data;

namespace Misoso.api.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(DataContext dataContext) : base(dataContext)
        {}

        public async Task<User> CreateUserAsync(User user)
        {
            await _Context.Users.AddAsync(user);
            await _Context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetUserByExternalIdAsync(string externalId)
        {
            return await _Context.Users.Where(x=>x.ExternalId == externalId).FirstOrDefaultAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _Context.FindAsync<User>(id);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            var users = await _Context.Users.AsNoTracking().ToListAsync();
            return users.AsEnumerable();
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            _Context.Entry<User>(user).State = EntityState.Modified;
            await _Context.SaveChangesAsync();
            return user;
        }
    }
}
