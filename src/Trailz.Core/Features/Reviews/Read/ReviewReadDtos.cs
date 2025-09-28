using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trailz.Core.Features.Reviews.Read
{
    public record ReviewResponse(Guid Id, 
        Guid TraiId, 
        string UserId, 
        int Rating, 
        string Comments, 
        DateTime ReviewDate);

    public record ReviewsGetAllRequest(int? Page, int? PageSize);

    public record ReviewsGetByTrailIdRequest(Guid? TrailId);

    public record ReviewsGetByUserIdRequest(string? UserId);
}
