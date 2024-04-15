using Entities.Concrete.Entities.PSI.Types;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.FluentValidators.PSI.Types.PSITypeParameterListValidators
{
    public class PSITypeParameterListValidator:AbstractValidator<PSITypeParameterList>
    {
        public PSITypeParameterListValidator()
        {

            RuleFor(x => x.Id).NotEmpty();


            RuleFor(x => x.ParameterName).NotEmpty();
            RuleFor(x => x.ParameterName).Length(1, 40);

            RuleFor(x => x.ParameterValueString).NotEmpty();
            RuleFor(x => x.ParameterValueString).Length(1, 512);

            RuleFor(x => x.ParameterValueNumber).NotEmpty();
            RuleFor(x => x.ParameterValueNumber).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.ParameterDate).NotEmpty();

            RuleFor(x => x.UnitOfMeasurement).NotEmpty();
            RuleFor(x => x.UnitOfMeasurement).Length(1,20);

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}
