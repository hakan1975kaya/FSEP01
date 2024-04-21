using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.FluentValidators.General.General.DemandValidators
{
    public class DemandValidator : AbstractValidator<Demand>
    {
        public DemandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.DemandName).NotEmpty();
            RuleFor(x => x.DemandName).Length(2, 50);

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}
