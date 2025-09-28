using Trailz.Core.Features.Trails.Read;

namespace Trailz.Api.Features.Trails;

public class GetAllTrailsEndpoint : Endpoint<TrailGetAllRequest, IEnumerable<TrailResponse>>
{
    public TrailReadService Service { get; set; } = null!;
    
    public override void Configure()
    {
        Get("/api/Trails");
        AllowAnonymous();
    }

    public override async Task HandleAsync(TrailGetAllRequest request, CancellationToken ct)
    {
        var results = await Service.GetAllAsync(
            request.Page.GetValueOrDefault(), 
            request.PageSize.GetValueOrDefault(), 
            ct);
        
        await Send.OkAsync(results);
    }  
}
