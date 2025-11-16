using Microsoft.EntityFrameworkCore;
using Trailz.Core.Models;
using Trailz.Core.Shared;

namespace Trailz.Infrastructure.Database;

public class TrailzDbContext(
    DbContextOptions<TrailzDbContext> options,
    TimeProvider timeProvider) : DbContext(options), IDbContext  
{
    public new DbSet<TEntity> Set<TEntity>() where TEntity : class, IEntity
    {
        return base.Set<TEntity>();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken ct = default)
    {
        var currentTime = timeProvider.GetUtcNow();

        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = currentTime;
                    entry.Entity.LastUpdatedAt = currentTime;
                    break;

                case EntityState.Modified:
                    entry.Entity.LastUpdatedAt = currentTime;
                    break;
            }
        }

        return await base.SaveChangesAsync(ct);
    }
}