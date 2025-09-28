using Trailz.Core.Shared;

namespace Trailz.Core.Features.Trails.Read
{
    public  class TrailReadService
    {
        private readonly IDbContext dbCtx;

        public TrailReadService(IDbContext dbCtx)
        {
            this.dbCtx = dbCtx;
        }

        public async Task<IEnumerable<TrailResponse>> GetAllAsync(int page, int pageSize, CancellationToken ct)
        {
            if (page == 0) page = 1;
            if (pageSize == 0) pageSize = 12;

            return await dbCtx
                .Set<Trail>()
                .OrderBy(x => x.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new TrailResponse(x.Id, x.Name, x.Description, x.LengthMiles, x.Difficulty, x.ElevationGainFeet, x.IsLoop))
                .ToListAsync(ct);
        }

        public async Task<Result<TrailResponse>> GetByIdAsync(Guid id, CancellationToken ct)
        {
            var trail = await dbCtx
                .Set<Trail>()
                .Where(x => x.Id == id)
                .Select(x => new TrailResponse(x.Id, x.Name, x.Description, x.LengthMiles, x.Difficulty, x.ElevationGainFeet, x.IsLoop))
                .FirstOrDefaultAsync(ct);

            if (trail == null)
            {
                return Result<TrailResponse>.Failure(new Error("", ""));
            }

            return Result<TrailResponse>.Success(trail);
        }
    }
}
