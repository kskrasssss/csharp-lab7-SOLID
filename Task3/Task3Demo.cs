namespace Lab_7;

public record Customer(int Id, string Name);

public static class Task3Demo
{
    public static void Run()
    {
        var sync = new DataSyncService<Customer>();
        var incoming = new List<Customer> { new(1, "Іван"), new(2, "Олена") };

        // Будь-який IWriteRepository можна підставити без збоїв
        var repo = new DataRepository<Customer>();
        sync.SyncEntities(repo, incoming);
        Console.WriteLine($"У репозиторії: {repo.GetAll().Count} записів");

        // Аудит: лише читання. Передати його в SyncEntities компілятор не дозволить:
        // sync.SyncEntities(auditRepo, incoming);   // помилка компіляції (Fail-fast)
        var audit = new AuditRepository<Customer>();
        var writer = new AuditLogWriter<Customer>(audit);
        writer.Write(new Customer(99, "Системна подія"));
        Console.WriteLine($"В аудиті: {audit.GetAll().Count} записів");
    }
}