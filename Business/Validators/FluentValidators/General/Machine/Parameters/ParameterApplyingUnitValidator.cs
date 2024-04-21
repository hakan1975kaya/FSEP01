using Core.Entities.Concrete;
using Entities.Concrete.Entities.General.Machine.General;
using Entities.Concrete.Entities.General.Machine.Parameters;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.FluentValidators.General.Machine.Parameters
{
    public class ParameterApplyingUnitValidator : AbstractValidator<ParameterApplyingUnit>
    {
        public ParameterApplyingUnitValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.ParameterId).NotEmpty();

            RuleFor(x => x.LubricatorAutoOn).InclusiveBetween(false, true);

            RuleFor(x => x.RelativeApplyingSpeedSet).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.MinimumApplyingSpeedSet).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.ApplyingUnitTempTrayOneSet).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.ApplyingUnitTempTrayTwoSet).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.PressureAROneLeftSideSet).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.PressureAROneRightSideSet).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}
