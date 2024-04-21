using FluentValidation;
using PSI.Dtos.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI.Validators.FluentValidators.Types.TypeProcessInstructionsValidators
{
    internal class TypeProcessInstructionsValidator : AbstractValidator<TypeProcessInstructions>
    {
        public TypeProcessInstructionsValidator()
        {
            RuleFor(x => x.CountOutputMat).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.CountProdParameter).InclusiveBetween(decimal.MinValue, decimal.MaxValue);
        }
    }
}
