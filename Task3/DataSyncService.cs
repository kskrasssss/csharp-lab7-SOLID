namespace Lab_7;

public class DataSyncService<T> where T : class
{
    public void SyncEntities(IWriteRepository<T> target, IEnumerable<T> incomingData)
    {
        foreach (var item in incomingData)
            target.Add(item);
    }
}