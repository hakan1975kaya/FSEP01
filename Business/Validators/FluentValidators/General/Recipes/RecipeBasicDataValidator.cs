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
    public class RecipeBasicDataValidator : AbstractValidator<RecipeBasicData>
    {
        public RecipeBasicDataValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.InputCoilId).NotEmpty();

            RuleFor(x => x.Acceleration).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.Deceleration).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.FastStop).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.JogSpeed).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}
