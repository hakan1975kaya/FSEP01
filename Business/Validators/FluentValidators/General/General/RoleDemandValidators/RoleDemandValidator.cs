using Core.Entities.Concrete;
using Entities.Concrete.Entities.General.General;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.FluentValidators.General.General.RoleDemandValidators
{
    public class RoleDemandValidator : AbstractValidator<RoleDemand>
    {
        public RoleDemandValidator()
        {
            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}
