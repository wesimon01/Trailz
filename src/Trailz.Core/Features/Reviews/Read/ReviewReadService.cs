using Trailz.Core.Features.Trails.Read;
using Trailz.Core.Shared;

namespace Trailz.Core.Features.Reviews.Read
{
    public class ReviewReadService
    {
        private readonly IDbContext dbCtx;

        public ReviewReadService(IDbContext dbCtx)
        {
            this.dbCtx = dbCtx;
        }

        public async Task<IEnumerable<ReviewResponse>> GetAllAsync(int page, int pageSize, CancellationToken ct)
        {
            if (page == 0) page = 1;
            if (pageSize == 0) pageSize = 10;

            return await dbCtx
                .Set<Review>()
                .OrderByDescending(r => r.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(r => new ReviewResponse(r.Id, r.TrailId, r.UserId, r.Rating, r.Comments, r.ReviewDate))
                .ToListAsync(ct);
        }

        public async Task<Result<IEnumerable<ReviewResponse>>> GetByTrailIdAsync(Guid id, CancellationToken ct)
        {
            var review = await dbCtx
                .Set<Review>()
                .Where(r => r.Id == id)
                .Select(r => new ReviewResponse(r.Id, r.TrailId, r.UserId, r.Rating, r.Comments, r.ReviewDate))
                .ToListAsync(ct);

            if (review is null)
            {
                return Result<IEnumerable<ReviewResponse>>.Failure(new Error("", ""));
            }

            return Result<IEnumerable<ReviewResponse>>.Success(review);
        }

        public async Task GetByUserId(string userId, CancellationToken ct)
        {

        }
    }
}
