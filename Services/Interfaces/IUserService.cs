using Misoso.Api.DTOs.Requests;
using Misoso.Api.DTOs.Responses;

namespace Misoso.Api.Services.Interfaces
{
    public interface IUserService
    {
        public Task<UserResponse> Login(string email, string password);
        public Task<UserResponse> GetUserAsync(int userId);
        public Task<UserResponse> GetUserByExternalIdAsync(string externalId);
        public Task<UserResponse> CreateUserAsync(CreateUserRequest createUserRequest);
    }
}
