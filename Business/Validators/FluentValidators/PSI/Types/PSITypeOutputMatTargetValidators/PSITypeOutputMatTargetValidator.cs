using Entities.Concrete.Entities.PSI.Types;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.FluentValidators.PSI.Types.PSITypeOutputMatTargetValidators
{
    public class PSITypeOutputMatTargetValidator:AbstractValidator<PSITypeOutputMatTarget>
    {
        public PSITypeOutputMatTargetValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.PSITypeIProcessInstructions).NotEmpty();

            RuleFor(x => x.MatId).NotEmpty();

            RuleFor(x => x.CountOutputParameter).NotEmpty();
            RuleFor(x => x.CountOutputParameter).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.CountInputMatRelation).NotEmpty();
            RuleFor(x => x.CountInputMatRelation).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}
