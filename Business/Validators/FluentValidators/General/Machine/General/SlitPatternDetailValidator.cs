using Core.Entities.Concrete;
using Entities.Concrete.Entities.General.Machine.General;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.FluentValidators.General.General.DemandValidators
{
    public class SlitPatternDetailValidator : AbstractValidator<SlitPatternDetail>
    {
        public SlitPatternDetailValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.InputCoilSlitPatternId).NotEmpty();

            RuleFor(x => x.MainCoilProductionId).Length(2, 40);

            RuleFor(x => x.Width).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.Length).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.MinimumOuterDiameter).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.MaximumOuterDiameter).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.MinimumWidth).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.MaximumWidth).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.MinimumThickness).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.MaximumThickness).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.TargetLength).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.MinimumLength).NotEmpty();
            RuleFor(x => x.MinimumLength).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.MaximumLength).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}
