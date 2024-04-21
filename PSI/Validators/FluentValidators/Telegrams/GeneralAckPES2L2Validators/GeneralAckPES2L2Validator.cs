using FluentValidation;
using PSI.Dtos.Telegrams;
using PSI.Dtos.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI.Validators.FluentValidators.Telegrams.GeneralAckPES2L2Validators
{
    public class GeneralAckPES2L2Validator : AbstractValidator<GeneralAckPES2L2>
    {
        public GeneralAckPES2L2Validator()
        {

            RuleFor(x => x.Header).NotEmpty();

            RuleFor(x => x.AckState).Length(1, 3);

            RuleFor(x => x.InfoCode).Length(1, 10);

            RuleFor(x => x.InfoText).Length(1, 80);

            RuleFor(x => x.TelegramSeqNo).Length(1, 10);

            RuleFor(x => x.CountParameter).InclusiveBetween(decimal.MinValue, decimal.MaxValue);
        }
    }
}