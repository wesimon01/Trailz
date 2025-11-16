using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trailz.Core.Features.Trails.Create;
using Trailz.Core.Features.Trails.Delete;
using Trailz.Core.Features.Trails.Read;

namespace Trailz.Api.Features.Trails;

[Route("/trails")]
[ApiController]
[AllowAnonymous]
public class TrailsEndpoints : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTrailById(
        Guid id, 
        TrailReadService service, 
        CancellationToken ct)
    {
        var result = await service.GetByIdAsync(id, ct);

        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }
        return NotFound(result.Error.Message);
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


    public async Task<IActionResult> CreateTrail(
        CreateTrailRequest request, 
        CreateTrailUseCase useCase, 
        CancellationToken ct)
    {
        var result = await useCase.Execute(request, ct);

        return Ok(result);
    }

    //[HttpPut("{id}")]
    //public IActionResult UpdateTrail(Guid id, 
    //    UpdateTrailRequest request, 
    //    [FromServices] UpdateCategoryUseCase useCase, 
    //    CancellationToken ct)
    //{

    //}

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTrail(Guid id, DeleteTrailUseCase useCase, CancellationToken ct)
    {
        var result = await useCase.Execute(id, ct);

        if (result.IsSuccess)
        {
            return NoContent();
        }

        return result.Error.Code == ""
            ? NotFound(result.Error.Message)
            : BadRequest(result.Error.Message);
    }

}
