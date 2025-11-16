using Trailz.Core.Shared;

namespace Trailz.Core.Features.Trails.Create;

public class CreateTrailUseCase
{
    private readonly IDbContext _dbContext;

    public CreateTrailUseCase(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CreateTrailResponse> Execute(CreateTrailRequest request, CancellationToken ct)
    {
        var trail = new Trail
        {
            Name = request.Name,
            Description = request.Description,
            LengthMiles = request.LengthMiles,
            Difficulty = request.DifficultyLevel,
            ElevationGainFeet = request.ElevationGainFeet,
            IsLoop = request.IsLoop
        };

        _dbContext.Set<Trail>().Add(trail);
        await _dbContext.SaveChangesAsync(ct);

        return new CreateTrailResponse(trail.Id, trail.Name, trail.Description);
    }
}
