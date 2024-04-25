using Entities.Concrete.Entities.PSI.Telegrams;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.FluentValidators.PSI.Telegrams.PSIPingAckPES2L2Validators
{
    public class PSIPingAckPES2L2Validator : AbstractValidator<PSIPingAckPES2L2>
    {
        public PSIPingAckPES2L2Validator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.Header).NotEmpty();

            RuleFor(x => x.TelegramSeqNo).Length(1, 10);

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}

