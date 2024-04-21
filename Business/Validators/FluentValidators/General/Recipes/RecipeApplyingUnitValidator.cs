using Core.Entities.Concrete;
using Entities.Concrete.Entities.General.Machine.General;
using Entities.Concrete.Entities.General.Machine.Recipes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.FluentValidators.General.Machine.Recipe
{
    public class RecipeApplyingUnitValidator : AbstractValidator<RecipeApplyingUnit>
    {
        public RecipeApplyingUnitValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.InputCoilId).NotEmpty();

            RuleFor(x => x.LocalId).NotEmpty();
            RuleFor(x => x.LocalId).Length(2, 40);

            RuleFor(x => x.Alloy).NotEmpty();
            RuleFor(x => x.Alloy).Length(2, 20);

            RuleFor(x => x.Temper).NotEmpty();
            RuleFor(x => x.Temper).Length(2, 20);

            RuleFor(x => x.Thickness).NotEmpty();
            RuleFor(x => x.Thickness).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.Width).NotEmpty();
            RuleFor(x => x.Width).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.Diameter).NotEmpty();
            RuleFor(x => x.Diameter).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.UsageArea).NotEmpty();
            RuleFor(x => x.UsageArea).Length(2, 30);

            RuleFor(x => x.LubricatorAutoOn).InclusiveBetween(false, true);

            RuleFor(x => x.RelativeApplyingSpeedSet).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.MinimumApplyingSpeedSet).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.ApplyingUnitTempTrayOneSet).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.ApplyingUnitTempTrayTwoSet).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.PressureAROneLeftSideSet).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.PressureAROneRightSideSet).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}
