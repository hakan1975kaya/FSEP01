using Entities.Concrete.Entities.PSI.Telegrams;
using FluentValidation;
using PSI.Dtos.Telegrams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI.Validators.FluentValidators.Telegrams.PSIPingAckPES2L2Validators
{
    public class PingAckPES2L2Validator : AbstractValidator<PingAckPES2L2>
    {
        public PingAckPES2L2Validator()
        {
            RuleFor(x => x.Header).NotEmpty();

            RuleFor(x => x.TelegramSeqNo).Length(1, 10);
        }
    }
}

