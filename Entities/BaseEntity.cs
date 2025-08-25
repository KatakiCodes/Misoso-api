using System.ComponentModel.DataAnnotations.Schema;
using Dapper.Contrib.Extensions;

namespace Misoso.api.Entities
{
    public abstract class BaseEntity :IEquatable<BaseEntity>
    {
        [Key]
        public int id { get; private set; }
        protected BaseEntity(int id)
        {
            this.id = id;
        }
        protected BaseEntity()
        {}

        public bool Equals(BaseEntity? other)
        {
            if (other is null)
                return false;
            return this.id == other.id;
        }
    }
}
