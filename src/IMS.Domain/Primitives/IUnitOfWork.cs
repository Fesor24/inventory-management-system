namespace IMS.Domain.Primitives;
public interface IUnitOfWork : IDisposable
{
    IGenericRepository<TEntity> Repository<TEntity>()
          where TEntity : class, new();

    Task<int> Complete();
}
