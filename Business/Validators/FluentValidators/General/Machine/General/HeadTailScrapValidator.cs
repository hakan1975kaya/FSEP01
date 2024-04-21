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
    public class HeadTailScrapValidator : AbstractValidator<HeadTailScrap>
    {
        public HeadTailScrapValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.UsageArea).NotEmpty();
            RuleFor(x => x.UsageArea).Length(2, 30);

            RuleFor(x => x.PreviousLine).NotEmpty();
            RuleFor(x => x.PreviousLine).Length(2, 20);

            RuleFor(x => x.ThicknessMinimum).NotEmpty();
            RuleFor(x => x.ThicknessMinimum).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.ThicknessMaximum).NotEmpty();
            RuleFor(x => x.ThicknessMaximum).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.ScrapValue).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}

