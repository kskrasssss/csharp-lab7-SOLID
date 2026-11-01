#nullable disable

namespace Lab_7.Legacy.Task3;

public class DataRepository<T> where T : class
{
    protected readonly List<T> items = new List<T>();

    public virtual void Add(T entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        items.Add(entity);
        Console.WriteLine($"[Repository] Entity of type {typeof(T).Name} added.");
    }

    public virtual void Update(T entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        Console.WriteLine($"[Repository] Entity of type {typeof(T).Name} updated.");
    }

    public virtual void Remove(T entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        items.Remove(entity);
        Console.WriteLine($"[Repository] Entity of type {typeof(T).Name} removed.");
    }

    public virtual IEnumerable<T> GetAll()
    {
        return items.AsReadOnly();
    }
}

public class ReadOnlyAuditRepository<T> : DataRepository<T> where T : class
{
    public override void Add(T entity)
    {
        // Порушення LSP: Аудит-журнал є закритим від прямих додавань
        throw new NotSupportedException("Direct addition is disabled for ReadOnlyAuditRepository.");
    }

    public override void Update(T entity)
    {
        // Порушення LSP: Заборона модифікації історичних записів аудиту
        throw new InvalidOperationException("Audit records are immutable and cannot be updated.");
    }

    public override void Remove(T entity)
    {
        // Порушення LSP: Заборона видалення записів аудиту
        throw new InvalidOperationException("Audit records cannot be deleted.");
    }
}

public class DataSyncService<T> where T : class
{
    public void SyncEntities(DataRepository<T> targetRepository, List<T> incomingData)
    {
        // Модуль синхронізації передбачає, що у будь-який DataRepository можна додавати нові дані
        foreach (var item in incomingData)
        {
            targetRepository.Add(item);
        }
    }
}