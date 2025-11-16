using Azure.Core;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace Trailz.Api.Features.Reviews
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewEndpoints : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllReviews()
        {
            //var results = await Service.GetAllAsync(
            //    request.Page.GetValueOrDefault(),
            //    request.PageSize.GetValueOrDefault(),
            //    ct);

            //await Send.OkAsync(results);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetReviewsByTrailId()
        {
            //var results = await Service.GetByTrailIdAsync(request.TrailId.GetValueOrDefault(), ct);

            //await Send.OkAsync(results.Value!);

            return Ok();
        }
    }
}
