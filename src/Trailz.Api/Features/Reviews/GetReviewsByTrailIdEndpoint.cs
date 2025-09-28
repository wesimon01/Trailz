using Trailz.Core.Features.Reviews.Read;

namespace Trailz.Api.Features.Reviews;

public class GetReviewsByTrailIdEndpoint : Endpoint<ReviewsGetByTrailIdRequest, IEnumerable<ReviewResponse>>
{
    public ReviewReadService Service { get; set; } = null!;

    public override void Configure()
    {
        Get("/api/Trails/{id:guid}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(ReviewsGetByTrailIdRequest request, CancellationToken ct)
    {
        var results = await Service.GetByTrailIdAsync(request.TrailId.GetValueOrDefault(), ct);

        await Send.OkAsync(results.Value!);
    }
}