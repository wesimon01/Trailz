using Trailz.Core.Features.Reviews.Read;
using Trailz.Core.Features.Trails.Read;

namespace Trailz.Api.Features.Reviews
{
    public class GetAllReviewsEndpoint : Endpoint<ReviewsGetAllRequest, IEnumerable<ReviewResponse>>
    {
        public ReviewReadService Service { get; set; } = null!;

        public override void Configure()
        {
            Get("/api/Trails");
            AllowAnonymous();
        }

        public override async Task HandleAsync(ReviewsGetAllRequest request, CancellationToken ct)
        {
            var results = await Service.GetAllAsync(
                request.Page.GetValueOrDefault(),
                request.PageSize.GetValueOrDefault(),
                ct);

            await Send.OkAsync(results);
        }
    }
}
