using IMS.Domain.Primitives;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace IMS.Infrastructure.Data.Interceptors;
internal class AuditableEntityInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateAuditableEntities(eventData.Context);

        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        UpdateAuditableEntities(eventData.Context);

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    internal static void UpdateAuditableEntities(DbContext? context)
    {
        if (context is null) return;

        var entities = context.ChangeTracker.Entries<BaseAuditableEntity<Guid>>().ToList();

        foreach(var entity in entities)
        {
            entity.Entity.UpdatedAt = DateTime.UtcNow;

            if(entity.State == EntityState.Added)
                entity.Entity.CreatedAt = DateTime.UtcNow;
        }
    }
}
