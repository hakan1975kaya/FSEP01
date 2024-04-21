using Entities.Concrete.Entities.PSI.Telegrams;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.FluentValidators.PSI.Telegrams.PSIProcessDataPES2L2Validators
{
    public class PSIProcessDataPES2L2Validator : AbstractValidator<PSIProcessDataPES2L2>
    {
        public PSIProcessDataPES2L2Validator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.Header).NotEmpty();

            RuleFor(x => x.EventCode).Length(1, 10);

            RuleFor(x => x.LineId).Length(1, 10);

            RuleFor(x => x.LineSequenceId).Length(1, 20);

            RuleFor(x => x.CountLineSeqParameter).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.CountProcessInstructions).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}

