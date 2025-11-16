using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Trailz.Core.Features.Trails.Create
{
    public class CreateTrailValidator : AbstractValidator<CreateTrailRequest>
    {
        public CreateTrailValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(Trail.MaxLengths.Name);

            RuleFor(x => x.Description)
              .NotEmpty()
              .MaximumLength(Trail.MaxLengths.Description);

            RuleFor(x => x.LengthMiles).NotEmpty(); 
            RuleFor(x => x.ElevationGainFeet).NotEmpty();
        }
    }
}
