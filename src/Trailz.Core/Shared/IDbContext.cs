namespace Trailz.Core.Shared
{
    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class, IEntity;
        Task<int> SaveChangesAsync(CancellationToken ct = default);
    }
}
