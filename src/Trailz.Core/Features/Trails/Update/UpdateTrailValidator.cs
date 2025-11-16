using FluentValidation;

namespace Trailz.Core.Features.Trails.Update;

public class UpdateTrailValidator : AbstractValidator<UpdateTrailRequest>
{
    public UpdateTrailValidator()
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
