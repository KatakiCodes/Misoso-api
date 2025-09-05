using Misoso.api.Entities;

namespace Misoso.api.Contracts
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetUsersAsync();
        public Task<User> GetUserByIdAsync(int id);
        public Task<User> GetUserByExternalIdAsync(string externalId);
        public Task<User>CreateUserAsync(User user);
        public Task<User> UpdateUserAsync(User user);
    }
}
