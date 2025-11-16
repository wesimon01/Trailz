using Trailz.Core.Shared;

namespace Trailz.Core.Features.Trails.Read
{
    public  class TrailReadService(IDbContext dbContext)
    {
        public async Task<IEnumerable<TrailResponse>> GetAllAsync(int page, int pageSize, CancellationToken ct)
        {
            if (page == 0) page = 1;
            if (pageSize == 0) pageSize = 12;

            return await dbContext
                .Set<Trail>()
                .OrderBy(x => x.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new TrailResponse(x.Id, x.Name, x.Description, x.LengthMiles, x.Difficulty, x.ElevationGainFeet, x.IsLoop))
                .ToListAsync(ct);
        }

        public async Task<Result<TrailResponse>> GetByIdAsync(Guid id, CancellationToken ct)
        {
            var trail = await dbContext
                .Set<Trail>()
                .Where(x => x.Id == id)
                .Select(x => new TrailResponse(x.Id, x.Name, x.Description, x.LengthMiles, x.Difficulty, x.ElevationGainFeet, x.IsLoop))
                .FirstOrDefaultAsync(ct);

            if (trail is null) 
            {
                return Result<TrailResponse>.Failure(new Error(ErrorCode.NotFound, "Trail not found"));
            }

            return Result<TrailResponse>.Success(trail);
        }
    }
}
