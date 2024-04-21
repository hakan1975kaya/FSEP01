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
    public class RecipeRewinderOnePressureValidator : AbstractValidator<RecipeRewinderOnePressure>
    {
        public RecipeRewinderOnePressureValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.InputCoilId).NotEmpty();

            RuleFor(x => x.DiameterOne).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.DiameterTwo).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.DiameterThree).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.DiameterFour).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.DiameterFive).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.DiameterSix).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.DiameterSeven).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.DiameterEight).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.DiameterNine).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.DiameterTen).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}
