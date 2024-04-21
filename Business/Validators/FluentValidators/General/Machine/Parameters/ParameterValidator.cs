using Core.Entities.Concrete;
using Entities.Concrete.Entities.General.Machine.General;
using Entities.Concrete.Entities.General.Machine.Parameters;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.FluentValidators.General.Machine.Parameters
{
    public class ParameterValidator : AbstractValidator<Parameter>
    {
        public ParameterValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.RecipeNumber).NotEmpty();
            RuleFor(x => x.RecipeNumber).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.Alloy).NotEmpty();
            RuleFor(x => x.Alloy).Length(2, 20);

            RuleFor(x => x.Temper).NotEmpty();
            RuleFor(x => x.Temper).Length(2, 20);

            RuleFor(x => x.ThicknessMinimum).NotEmpty();
            RuleFor(x => x.ThicknessMinimum).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.ThicknessMaximum).NotEmpty();
            RuleFor(x => x.ThicknessMaximum).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.WidthMinimum).NotEmpty();
            RuleFor(x => x.WidthMinimum).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.WidthMaximum).NotEmpty();
            RuleFor(x => x.WidthMaximum).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.DiameterMinimum).NotEmpty();
            RuleFor(x => x.DiameterMinimum).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.DiameterMaximum).NotEmpty();
            RuleFor(x => x.DiameterMaximum).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.UsageArea).NotEmpty();
            RuleFor(x => x.UsageArea).Length(2, 30);

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}
