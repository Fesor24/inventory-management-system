using System.Linq.Expressions;

namespace IMS.Domain.Primitives;
public interface ISpecification<TEntity> 
    where TEntity: class, new()
{
    Expression<Func<TEntity, bool>> Criteria { get; }
    Expression<Func<TEntity, object>> OrderByDescending { get; }
    List<Expression<Func<TEntity, object>>> Includes { get; }
}
