using Trailz.Core.Shared;

namespace Trailz.Core.Features.Trails.Update
{
    public class UpdateTrailUseCase(IDbContext dbContext)
    {
        public async Task<Result<UpdateTrailResponse>> Execute(Guid id, UpdateTrailRequest request, CancellationToken ct)
        {
            var trail = await dbContext.Set<Trail>().FindAsync(id, ct);
            if (trail is null)
            {
                return Result<UpdateTrailResponse>.Failure(new Error(ErrorCode.NotFound, "Trail not found"));
            }

            trail.Name = request.Name;
            trail.Description = request.Description;

            return Result<UpdateTrailResponse>.Success(
                new UpdateTrailResponse(trail.Name, trail.Description));
        }
    }
}
