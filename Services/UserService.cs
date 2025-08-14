using Misoso.api.Contracts;
using Misoso.api.Entities;
using Misoso.Api.DTOs.Requests;
using Misoso.Api.DTOs.Responses;
using Misoso.Api.Services.Interfaces;

namespace Misoso.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _UserRepository;

        public UserService(IUserRepository userRepository)
        {
            _UserRepository = userRepository;
        }

        public async Task<UserResponse?> AuthAsync(string email, string password)
        {
            var getUsers = await _UserRepository.GetUsersAsync();
            var user = getUsers.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
            return new UserResponse().ToResponseDto(user);
        }

        public async Task<UserResponse?> CreateUserAsync(CreateUserRequest userRequest)
        {
            var user = new User(userRequest.Email, userRequest.UserName, userRequest.Password);
            var response = await _UserRepository.CreateUserAsync(user);
            return new UserResponse().ToResponseDto(response);
        }

        public async Task<UserResponse?> GetUserAsync(int userId)
        {
            var response = await _UserRepository.GetUserByIdAsync(userId);
            return new UserResponse().ToResponseDto(response);
        }
    }
}
