using System;
using System.Collections.Generic;
using System.Text;

namespace Trailz.Core.Features.Trails.Create;

public record CreateTrailRequest(
    string Name, 
    string Description, 
    decimal LengthMiles, 
    DifficultyLevel? DifficultyLevel,
    decimal ElevationGainFeet,
    bool IsLoop);

public record CreateTrailResponse(Guid Id, string Name, string Description);