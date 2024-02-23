using IMS.Domain.Primitives;
using IMS.Infrastructure.Data.Specifications;
using Microsoft.EntityFrameworkCore;

namespace IMS.Infrastructure.Data.Repositories;
internal class GenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : class, new()
{
    private readonly DbSet<TEntity> _dbSet;

    public GenericRepository(ApplicationDbContext context)
    {
        _dbSet = context.Set<TEntity>();
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default) =>
        await _dbSet.AddAsync(entity, cancellationToken);

    public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default) =>
        await _dbSet.AddRangeAsync(entities, cancellationToken);

    public void Delete(TEntity entity) =>
        _dbSet.Remove(entity);

    public async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await _dbSet.ToListAsync(cancellationToken);

    public async Task<IReadOnlyList<TEntity>> GetAllAsync(ISpecification<TEntity> spec, 
        CancellationToken cancellationToken = default) =>
        await ApplySpecification(spec).ToListAsync(cancellationToken);

    public async Task<TEntity?> GetAsync(ISpecification<TEntity> spec, 
        CancellationToken cancellationToken = default) =>
        await ApplySpecification(spec).FirstOrDefaultAsync(cancellationToken);

    public void Update(TEntity entity)
    {
        _dbSet.Attach(entity);
        _dbSet.Entry(entity).State = EntityState.Modified;
    }

    private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> spec) =>
        SpecificationEvaluator.GetQuery(_dbSet.AsQueryable(), spec);
}
