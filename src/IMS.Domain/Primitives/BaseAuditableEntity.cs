namespace IMS.Domain.Primitives;
public abstract class BaseAuditableEntity<TKey> : Entity<TKey> where TKey: IEquatable<TKey>
{
    public BaseAuditableEntity(TKey key): base(key) { }
    public BaseAuditableEntity()
    {
        
    }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set;}
}
