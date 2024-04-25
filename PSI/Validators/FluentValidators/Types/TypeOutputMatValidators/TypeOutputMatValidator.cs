using FluentValidation;
using PSI.Dtos.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI.Validators.FluentValidators.Types.TypeOutputMatValidators
{
    public class TypeOutputMatValidator : AbstractValidator<TypeOutputMat>
    {
        public TypeOutputMatValidator()
        {
            RuleFor(x => x.MatId).NotEmpty();

            RuleFor(x => x.KindOfOutput).Length(1, 10);

            RuleFor(x => x.ProdDuration).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.CountOutputParameter).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.CountOutputDefects).InclusiveBetween(decimal.MinValue, decimal.MaxValue);
        }
    }
}
