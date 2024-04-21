using FluentValidation;
using PSI.Dtos.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI.Validators.FluentValidators.Types.TypeParameterListValidators
{
    public class TypeParameterListValidator : AbstractValidator<TypeParameterList>
    {
        public TypeParameterListValidator()
        {
            RuleFor(x => x.ParameterName).NotEmpty();
            RuleFor(x => x.ParameterName).Length(1, 40);

            RuleFor(x => x.ParameterValueString).Length(1, 512);

            RuleFor(x => x.ParameterValueNumber).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.UnitOfMeasurement).Length(1,20);
        }
    }
}
