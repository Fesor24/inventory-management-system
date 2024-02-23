using IMS.Domain.Primitives;
using System.Collections;

namespace IMS.Infrastructure.Data.Repositories;
internal class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private Hashtable _repo;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Complete() =>
        await _context.SaveChangesAsync();

    public void Dispose() => 
        _context.Dispose();

    public IGenericRepository<TEntity> Repository<TEntity>()
        where TEntity : class, new()
    {
        _repo ??= new();

        string key = typeof(TEntity).Name;

        if (!_repo.ContainsKey(key))
        {
            var genericType = typeof(GenericRepository<>);

            var genericInstance = Activator.CreateInstance(genericType.MakeGenericType(typeof(TEntity)), _context);

            _repo.Add(key, genericInstance);
        }

        return (IGenericRepository<TEntity>)_repo[key];

        
    }
}
