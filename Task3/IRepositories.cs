namespace Lab_7;

public interface IReadRepository<T> where T : class
{
    IReadOnlyList<T> GetAll();
}

public interface IWriteRepository<T> where T : class
{
    void Add(T entity);
    void Update(T entity);
    void Remove(T entity);
}