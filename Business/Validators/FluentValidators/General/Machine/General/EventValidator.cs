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
    public class EventValidator : AbstractValidator<Event>
    {
        public EventValidator()
        {
            RuleFor(x => x.Id).NotEmpty();


            RuleFor(x => x.TNumber).NotEmpty();
            RuleFor(x => x.TNumber).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.LocalId).NotEmpty();
            RuleFor(x => x.LocalId).Length(2, 20);

            RuleFor(x => x.TType).NotEmpty();
            RuleFor(x => x.TType).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.IPara).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.FPara).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}
