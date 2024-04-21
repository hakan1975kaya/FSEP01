using Core.Entities.Concrete;
using Entities.Concrete.Entities.General.Machine.General;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.FluentValidators.General.General.DemandValidators
{
    public class DensityValidator : AbstractValidator<Density>
    {
        public DensityValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.Alloy).Length(2, 20);

            RuleFor(x => x.Value).InclusiveBetween(float.MinValue, float.MaxValue);

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}
