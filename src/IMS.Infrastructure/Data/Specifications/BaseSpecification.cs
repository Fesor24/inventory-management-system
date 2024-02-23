using IMS.Domain.Primitives;
using System.Linq.Expressions;

namespace IMS.Infrastructure.Data.Specifications;
public class BaseSpecification<TEntity> : ISpecification<TEntity>
    where TEntity : class, new()
{
    public BaseSpecification()
    {
        
    }

    public BaseSpecification(Expression<Func<TEntity, bool>> criteria) => Criteria = criteria;

    public Expression<Func<TEntity, bool>> Criteria { get; private set; }

    public Expression<Func<TEntity, object>> OrderByDescending { get; private set; }

    public List<Expression<Func<TEntity, object>>> Includes { get; private set; } =  new();

    protected void AddInclude(Expression<Func<TEntity, object>> includeExp) =>
        Includes.Add(includeExp);

    protected void SetOrderByDesc(Expression<Func<TEntity, object>> orderByDesc) =>
        OrderByDescending = orderByDesc;
}
