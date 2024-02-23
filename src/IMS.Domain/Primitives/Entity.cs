namespace IMS.Domain.Primitives;
public abstract class Entity<TKey> : IEquatable<Entity<TKey>> where TKey : IEquatable<TKey>
{
    protected Entity() { }
    protected Entity(TKey id) => Id = id;

    public TKey Id { get; private set; }

    public static bool operator ==(Entity<TKey>? first, Entity<TKey>? second) =>
        first is not null && second is not null && first.Equals(second);

    public static bool operator !=(Entity<TKey>? first, Entity<TKey>? second) =>
        !(first == second);

    public bool Equals(Entity<TKey>? other)
    {
        if (other is null) return false;

        return other.Id.Equals(Id);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;

        if (obj.GetType() != GetType()) return false;

        if (obj is not Entity<TKey> entity) return false;

        return Equals(entity);
    }

    public override int GetHashCode() =>
        (GetType().ToString() + Id).GetHashCode();
}
