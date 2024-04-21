using Entities.Concrete.Entities.PSI.Types;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.FluentValidators.PSI.Types.PSITypeInputMatValidators
{
    public class PSITypeInputMatValidator:AbstractValidator<PSITypeInputMat>
    {
        public PSITypeInputMatValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.MatId).NotEmpty();

            RuleFor(x => x.FlagConsumed).Length(1, 1);

            RuleFor(x => x.FlagConsumed).Length(1, 1);

            RuleFor(x => x.UsageOfInput).Length(1, 10);

            RuleFor(x => x.CountInputParameter).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.CountInputDefects).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}


