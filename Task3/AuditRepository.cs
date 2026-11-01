namespace Lab_7;

public class AuditRepository<T> : IReadRepository<T> where T : class
{
    private readonly List<T> _records = new();

    public IReadOnlyList<T> GetAll() => _records.AsReadOnly();

    // Єдина точка запису в аудит: лише додавання, без Update/Remove у контракті
    internal void Append(T record)
    {
        ArgumentNullException.ThrowIfNull(record);
        _records.Add(record);
    }
}

public class AuditLogWriter<T> where T : class
{
    private readonly AuditRepository<T> _repository;

    public AuditLogWriter(AuditRepository<T> repository)
    {
        _repository = repository;
    }

    public void Write(T record)
    {
        _repository.Append(record);
        Console.WriteLine($"[Audit] Record of type {typeof(T).Name} appended.");
    }
}