namespace Lab_7;

public class DataRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : class
{
    protected readonly List<T> Items = new();

    public virtual void Add(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        Items.Add(entity);
        Console.WriteLine($"[Repository] Entity of type {typeof(T).Name} added.");
    }

    public virtual void Update(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        Console.WriteLine($"[Repository] Entity of type {typeof(T).Name} updated.");
    }

    public virtual void Remove(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        Items.Remove(entity);
        Console.WriteLine($"[Repository] Entity of type {typeof(T).Name} removed.");
    }

    public IReadOnlyList<T> GetAll() => Items.AsReadOnly();
}