using Entities.Concrete.Entities.PSI.Types;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.FluentValidators.PSI.Types.PSITypeInputMatCoordValidators
{
    public class PSITypeInputMatCoordValidator : AbstractValidator<PSITypeInputMatCoord>
    {
        public PSITypeInputMatCoordValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.PSITypeOutputMatTarget).NotEmpty();

            RuleFor(x => x.OutputMatStartX).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.OutputMatEndX).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.OutputMatStartY).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.OutputMatEndY).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}

