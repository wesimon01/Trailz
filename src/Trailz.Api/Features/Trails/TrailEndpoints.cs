using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trailz.Api.Filters;
using Trailz.Core.Features.Trails.Create;
using Trailz.Core.Features.Trails.Delete;
using Trailz.Core.Features.Trails.Read;
using Trailz.Core.Features.Trails.Update;

namespace Trailz.Api.Features.Trails;

[Route("/trails")]
[ApiController]
[AllowAnonymous]
public class TrailEndpoints : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTrailById(
        Guid id, 
        TrailReadService service, 
        CancellationToken ct)
    {
        var result = await service.GetByIdAsync(id, ct);

        return result.IsSuccess ? 
            Ok(result.Value) :
            NotFound(result.Error.Message);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTrails(
        TrailGetAllRequest request, 
        TrailReadService service, 
        CancellationToken ct)
    {
        var results = await service.GetAllAsync(
            request.Page.GetValueOrDefault(), 
            request.PageSize.GetValueOrDefault(), 
            ct);

        return Ok(results);
    }

    [HttpPost]
    [ServiceFilter(typeof(ValidationActionFilter<CreateTrailValidator>))]
    public async Task<IActionResult> CreateTrail(
        CreateTrailRequest request, 
        CreateTrailUseCase useCase, 
        CancellationToken ct)
    {
        var result = await useCase.Execute(request, ct);

        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidationActionFilter<UpdateTrailValidator>))]
    public async Task<IActionResult> UpdateTrail(
        Guid id,
        UpdateTrailRequest request,
        UpdateTrailUseCase useCase,
        CancellationToken ct)
    {
        var result = await useCase.Execute(id, request, ct);

        return result.IsSuccess ?
          Ok(result.Value) :
          NotFound(result.Error.Message);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteTrail(
        Guid id, 
        DeleteTrailUseCase useCase, 
        CancellationToken ct)
    {
        var result = await useCase.Execute(id, ct);

        if (result.IsSuccess)
        {
            return NoContent();
        }

        return result.Error.Code == ErrorCode.NotFound
            ? NotFound(result.Error.Message)
            : BadRequest(result.Error.Message);
    }

}
