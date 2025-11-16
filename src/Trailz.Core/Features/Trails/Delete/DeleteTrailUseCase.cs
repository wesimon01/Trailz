using Trailz.Core.Shared;

namespace Trailz.Core.Features.Trails.Delete;

public class DeleteTrailUseCase(IDbContext dbContext)
{
    public async Task<Result> Execute(Guid id, CancellationToken ct)
    {
        var trail = await dbContext.Set<Trail>().FindAsync(id, ct);
        if (trail is null)
        {
            return Result.Failure(new Error(ErrorCode.NotFound, "Trail not found"));
        }

        dbContext.Set<Trail>().Remove(trail);
        await dbContext.SaveChangesAsync(ct);

        return Result.Success();
    }
}
