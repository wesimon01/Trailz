using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Trailz.Core.Models;
using Trailz.Core.Shared;

namespace Trailz.Infrastructure.Database;

public class TrailzDbContext : DbContext, IDbContext  
{
    private readonly TimeProvider timeProvider;

    public TrailzDbContext(
        DbContextOptions<TrailzDbContext> options, 
        TimeProvider timeProvider) : base(options)
    {
        this.timeProvider = timeProvider;
    }

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

    public Task<int> SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}