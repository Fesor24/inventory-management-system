using IMS.Domain.Primitives;
using Microsoft.EntityFrameworkCore;

namespace IMS.Infrastructure.Data.Specifications;
internal static class SpecificationEvaluator
{
    internal static IQueryable<TEntity> GetQuery<TEntity>(IQueryable<TEntity> entity, 
        ISpecification<TEntity> spec)
        where TEntity : class, new()
    {
        IQueryable<TEntity> query = entity.AsQueryable();

        if (spec.Criteria is not null)
            query = query.Where(spec.Criteria);

        if(spec.OrderByDescending is not null)
            query = query.OrderByDescending(spec.OrderByDescending);

        query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

        return query;
    }
}
