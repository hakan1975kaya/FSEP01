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
    public class SlitPatternValidator : AbstractValidator<SlitPattern>
    {
        public SlitPatternValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.InputCoilId).NotEmpty();

            RuleFor(x => x.OutputMatPlanId).Length(2, 30);

            RuleFor(x => x.MainCoilProductionId).Length(2, 40);

            RuleFor(x => x.LocalId).Length(2, 40);

            RuleFor(x => x.SpoolType).Length(2, 40);

            RuleFor(x => x.NeededRewinderDiameter).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.NeededRewinderLength).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.Status).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.NeededRewinderWeight).InclusiveBetween(float.MinValue, float.MaxValue);

            RuleFor(x => x.RemainingWeight).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.RemainingLength).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}
