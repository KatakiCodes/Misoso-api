using Misoso.api.Entities;

namespace Misoso.Api.DTOs.Responses
{
    public record UserResponse
    {
        public UserResponse()
        {}
        public UserResponse(int id,string email, string userName)
        {
            Id = id;
            Email = email;
            UserName = userName;
        }

        public int Id { get; private set; }
        public string Email { get; private set; }
        public string UserName { get; private set; }


        public UserResponse? ToResponseDto(User entity)
        {
            return (entity is null) ? null : new UserResponse(entity.Id, entity.Email, entity.UserName);
        }
        public void Dispose()
        {}
    }
}
