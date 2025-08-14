namespace Misoso.api.Entities
{
    public abstract class BaseEntity :IEquatable<BaseEntity>
    {
        public int Id { get; private set; }
        protected BaseEntity(int id)
        {
            Id = id;
        }
        protected BaseEntity()
        {}

        public bool Equals(BaseEntity? other)
        {
            if (other is null)
                return false;
            return Id == other.Id;
        }
    }
}
