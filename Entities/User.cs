using System.ComponentModel.DataAnnotations.Schema;

namespace Misoso.api.Entities
{
    [Table("Users")]
    public class User : BaseEntity
    {
        public User()
        {}
        public User(string email, string userName, string password)
        {
            Email = email;
            UserName = userName;
            Password = password;
        }
        public User(int id,string email, string userName, string password) : base(id)
        {
            Email = email;
            UserName = userName;
            Password = password;
        }
        public string Email { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
    }
}
