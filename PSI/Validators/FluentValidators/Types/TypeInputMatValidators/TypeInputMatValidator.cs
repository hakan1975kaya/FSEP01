using FluentValidation;
using PSI.Dtos.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI.Validators.FluentValidators.Types.TypeInputMatValidators
{
    public class TypeInputMatValidator : AbstractValidator<TypeInputMat>
    {
        public TypeInputMatValidator()
        {
            RuleFor(x => x.MatId).NotEmpty();

            RuleFor(x => x.FlagConsumed).Length(1, 1);

            RuleFor(x => x.FlagConsumed).Length(1, 1);

            RuleFor(x => x.UsageOfInput).Length(1, 10);

            RuleFor(x => x.CountInputParameter).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.CountInputDefects).InclusiveBetween(decimal.MinValue, decimal.MaxValue);
        }
    }
}


