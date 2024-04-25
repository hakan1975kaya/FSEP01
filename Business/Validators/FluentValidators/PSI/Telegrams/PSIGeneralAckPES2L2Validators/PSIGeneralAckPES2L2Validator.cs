using Entities.Concrete.Entities.PSI.Telegrams;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.FluentValidators.PSI.Telegrams.PSIGeneralAckPES2L2Validators
{
    public class PSIGeneralAckPES2L2Validator:AbstractValidator<PSIGeneralAckPES2L2>
    {
        public PSIGeneralAckPES2L2Validator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.Header).NotEmpty();

            RuleFor(x => x.AckState).Length(1, 3);

            RuleFor(x => x.InfoCode).Length(1, 10);

            RuleFor(x => x.InfoText).Length(1, 80);

            RuleFor(x => x.TelegramSeqNo).Length(1, 10);

            RuleFor(x => x.CountParameter).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}
