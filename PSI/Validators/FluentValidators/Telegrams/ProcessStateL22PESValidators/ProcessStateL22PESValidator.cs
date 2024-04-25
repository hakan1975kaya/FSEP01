using FluentValidation;
using PSI.Dtos.Telegrams;
using PSI.Dtos.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI.Validators.FluentValidators.Telegrams.PSIProcessStateL22PESValidators
{
    public class ProcessStateL22PESValidator : AbstractValidator<ProcessStateL22PES>
    {
        public ProcessStateL22PESValidator()
        {

            RuleFor(x => x.Header).NotEmpty();

            RuleFor(x => x.Eventmode).Length(1, 3);

            RuleFor(x => x.LineId).Length(1, 10);

            RuleFor(x => x.EventCode).Length(1, 10);

            RuleFor(x => x.SubLine).Length(1, 10);

            RuleFor(x => x.CountEventParameter).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.CountDefectActions).InclusiveBetween(decimal.MinValue, decimal.MaxValue);
        }
    }
}
