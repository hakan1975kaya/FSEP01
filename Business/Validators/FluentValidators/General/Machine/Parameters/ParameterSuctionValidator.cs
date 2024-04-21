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
    public class ParameterSuctionValidator : AbstractValidator<ParameterSuction>
    {
        public ParameterSuctionValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.ParameterId).NotEmpty();

            RuleFor(x => x.PrecutterRpmSet).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.PrecutterSpeedSet).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.PrecutterOneTwoOnOff).InclusiveBetween(false, true);

            RuleFor(x => x.SuctionRpmSet).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.SuctionSpeedSet).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.BoosterSortOneOnOff).InclusiveBetween(false, true);

            RuleFor(x => x.BoosterSortTwoOnOff).InclusiveBetween(false, true);

            RuleFor(x => x.BoosterSortThreeOnOff).InclusiveBetween(false, true);

            RuleFor(x => x.AirFlapOneSet).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.AirFlapTwoSet).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}
