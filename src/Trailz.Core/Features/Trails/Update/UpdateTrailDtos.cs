
namespace Trailz.Core.Features.Trails.Update;

public record UpdateTrailRequest(
    string Name,
    string Description,
    decimal LengthMiles,
    DifficultyLevel? DifficultyLevel,
    decimal ElevationGainFeet,
    bool IsLoop);

public record UpdateTrailResponse(string Name, string Description);
