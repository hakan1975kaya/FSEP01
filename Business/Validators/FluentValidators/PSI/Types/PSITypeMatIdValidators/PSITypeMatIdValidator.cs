using Entities.Concrete.Entities.PSI.Types;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.FluentValidators.PSI.Types.PSITypeMatIdValidators
{
    public class PSITypeMatIdValidator : AbstractValidator<PSITypeMatId>
    {
        public PSITypeMatIdValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.GlobalId).Length(1, 40);

            RuleFor(x => x.LocalId).Length(1, 40);

            RuleFor(x => x.LocalId).Length(1, 40);

            RuleFor(x => x.InternalId).Length(1, 40);

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}

