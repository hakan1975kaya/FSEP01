using Core.Entities.Concrete;
using Entities.Concrete.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.FluentValidators.General.General.MenuValidators
{
    public class MenuValidator : AbstractValidator<Menu>
    {
        public MenuValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.MenuName).NotEmpty();
            RuleFor(x => x.MenuName).Length(2, 50);

            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Description).Length(2, 100);

            RuleFor(x => x.Path).NotEmpty();
            RuleFor(x => x.Path).Length(2, 200);

            RuleFor(x => x.MenuOrder).NotEmpty();
            RuleFor(x => x.MenuOrder).InclusiveBetween(1, 200);

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}
