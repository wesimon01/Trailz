namespace Trailz.Core.Features.Trails.Read;

public record TrailResponse(
    Guid Id,
    string Name, 
    string Description, 
    decimal LengthMiles, 
    DifficultyLevel? Difficulty, 
    decimal ElevationGainFeet, 
    bool isLoop);

public record TrailGetAllRequest(int? Page, int? PageSize);

public record TrailGetByIdRequest(Guid? Id);

