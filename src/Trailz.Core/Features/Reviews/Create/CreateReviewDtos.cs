using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trailz.Core.Features.Reviews.Create
{
    public record CreateReviewRequest();

    public record CreateReviewResponse(long Id, string Name, string Description);
}
