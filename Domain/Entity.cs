namespace Task5_CRUD.Domain;

public abstract class Entity<TKey>
{   
    public TKey Id { get; set; }

    // Constructor for ORMs
    protected Entity()
    {

    }

    protected Entity(TKey id)
    {
        Id = id;
    }

    // Check if this entity is transient, i.e. without identity
    public bool IsTransient()
    {
        return EqualityComparer<TKey>.Default.Equals(default, Id);
    }

    public override bool Equals(object obj)
    {
        if (!(obj is Entity<TKey>))
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        var item = (Entity<TKey>)obj;

        var equals = Id.Equals(item.Id);

        return equals;
    }

    public override int GetHashCode()
    {
        if (IsTransient())
            return base.GetHashCode();

        // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)
        return Id.GetHashCode() ^ 31;
    }

    public static bool operator ==(Entity<TKey> left, Entity<TKey> right)
    {
        return left?.Equals(right) ?? Equals(right, null);
    }

    public static bool operator !=(Entity<TKey> left, Entity<TKey> right)
    {
        return !(left == right);
    }
}