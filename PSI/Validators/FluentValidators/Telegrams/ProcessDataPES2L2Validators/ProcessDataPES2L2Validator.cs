using FluentValidation;
using PSI.Dtos.Telegrams;
using PSI.Dtos.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI.Validators.FluentValidators.Telegrams.PSIProcessDataPES2L2Validators
{
    public class ProcessDataPES2L2Validator : AbstractValidator<ProcessDataPES2L2>
    {
        public ProcessDataPES2L2Validator()
        {

            RuleFor(x => x.Header).NotEmpty();

            RuleFor(x => x.EventCode).Length(1, 10);

            RuleFor(x => x.LineId).Length(1, 10);

            RuleFor(x => x.LineSequenceId).Length(1, 20);

            RuleFor(x => x.CountLineSeqParameter).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.CountProcessInstructions).InclusiveBetween(decimal.MinValue, decimal.MaxValue);
        }
    }
}
