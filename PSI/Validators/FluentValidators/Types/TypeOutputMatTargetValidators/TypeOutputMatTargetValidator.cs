using FluentValidation;
using PSI.Dtos.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI.Validators.FluentValidators.Types.TypeOutputMatTargetValidators
{
    public class TypeOutputMatTargetValidator : AbstractValidator<TypeOutputMatTarget>
    {
        public TypeOutputMatTargetValidator()
        {

            RuleFor(x => x.MatId).NotEmpty();

            RuleFor(x => x.CountOutputParameter).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.CountInputMatRelation).InclusiveBetween(decimal.MinValue, decimal.MaxValue);
        }
    }
}
