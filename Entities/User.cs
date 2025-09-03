using System.ComponentModel.DataAnnotations.Schema;

namespace Misoso.api.Entities
{
    [Table("Users")]
    public class User : BaseEntity
    {
        public User()
        {}
        public User(string email, string userName, string? password = default, string? externalId = default)
        {
            Email = email;
            UserName = userName;
            Password = password;
            ExternalId = externalId;
        }
        public User(int id,string email, string userName, string? password = default, string? externalId = default) : base(id)
        {
            Email = email;
            UserName = userName;
            Password = password;
            ExternalId = externalId;
        }
        public string Email { get; private set; }
        public string UserName { get; private set; }
        public string? Password { get; private set; }
        public string? ExternalId { get; private set; }
    }
}
