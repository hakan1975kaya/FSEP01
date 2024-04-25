using FluentValidation;
using PSI.Dtos.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI.Validators.FluentValidators.Types.TypeInputMatCoordValidators
{
    public class TypeInputMatCoordValidator : AbstractValidator<TypeInputMatCoord>
    {
        public TypeInputMatCoordValidator()
        {

            RuleFor(x => x.OutputMatStartX).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.OutputMatEndX).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.OutputMatStartY).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.OutputMatEndY).InclusiveBetween(decimal.MinValue, decimal.MaxValue);
        }
    }
}

