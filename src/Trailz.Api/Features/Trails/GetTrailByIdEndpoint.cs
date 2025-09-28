using Trailz.Core.Features.Trails.Read;

namespace Trailz.Api.Features.Trails;

public class GetTrailByIdEndpoint : Endpoint<TrailGetByIdRequest, TrailResponse>
{
    public TrailReadService Service { get; set; } = null!;

    public override void Configure()
    {
        Get("/api/Trails/{id:guid}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(TrailGetByIdRequest request, CancellationToken ct)
    {
        var result = await Service.GetByIdAsync(request.Id.GetValueOrDefault(), ct);

        if (result.IsSuccess)
        {
            await Send.OkAsync(result.Value!, ct);
        }
        await Send.NotFoundAsync(ct);
    }
}