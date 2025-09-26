using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Trailz.Core.Models;

namespace Trailz.Infrastructure.Database;

public class TrailzDbContext(
    DbContextOptions<TrailzDbContext> options, 
    TimeProvider timeProvider) : DbContext(options)
{
    public DbSet<Trail> Trails => Set<Trail>();
    public DbSet<Review> Reviews => Set<Review>();
    public DbSet<TrailPhoto> TrailPhotos => Set<TrailPhoto>();
    public DbSet<Waypoint> Waypoints => Set<Waypoint>();

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