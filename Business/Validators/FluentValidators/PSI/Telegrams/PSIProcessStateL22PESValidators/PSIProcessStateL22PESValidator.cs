using Entities.Concrete.Entities.PSI.Telegrams;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.FluentValidators.PSI.Telegrams.PSIProcessStateL22PESValidators
{
    public class PSIProcessStateL22PESValidator : AbstractValidator<PSIProcessStateL22PES>
    {
        public PSIProcessStateL22PESValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.Header).NotEmpty();

            RuleFor(x => x.Eventmode).Length(1, 3);

            RuleFor(x => x.LineId).Length(1, 10);

            RuleFor(x => x.EventCode).Length(1, 10);

            RuleFor(x => x.SubLine).Length(1, 10);

            RuleFor(x => x.CountEventParameter).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.CountDefectActions).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}
