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
    public class ParameterRewinderValidator : AbstractValidator<ParameterRewinder>
    {
        public ParameterRewinderValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.ParameterId).NotEmpty();

            RuleFor(x => x.RewinderOneTensionSetPoint).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.RewinderOneContactPreSetPoint).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.RewinderOneGapMode).InclusiveBetween(false, true);

            RuleFor(x => x.RewinderOneContactPositionMode).InclusiveBetween(false, true);

            RuleFor(x => x.RewinderOneContactForceMode).InclusiveBetween(false, true);

            RuleFor(x => x.RewinderOnePreSelectionOn).InclusiveBetween(false, true);

            RuleFor(x => x.RewinderOnePreSelectionOff).InclusiveBetween(false, true);

            RuleFor(x => x.RewinderTwoTensionSetPoint).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.RewinderTwoContactPreSetPoint).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.RewinderTwoGapMode).InclusiveBetween(false, true);

            RuleFor(x => x.RewinderTwoContactPositionMode).InclusiveBetween(false, true);

            RuleFor(x => x.RewinderTwoContactForceMode).InclusiveBetween(false, true);

            RuleFor(x => x.RewinderTwoPreSelectionOn).InclusiveBetween(false, true);

            RuleFor(x => x.RewinderTwoPreSelectionOff).InclusiveBetween(false, true);

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}
