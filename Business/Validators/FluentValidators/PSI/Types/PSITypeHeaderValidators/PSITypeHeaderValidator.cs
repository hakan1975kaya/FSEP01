using Entities.Concrete.Entities.PSI.Types;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.FluentValidators.PSI.Types.PSITypeHeaderValidators
{
    public class PSITypeHeaderValidator:AbstractValidator<PSITypeHeader>
    {
        public PSITypeHeaderValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.TelegramType).NotEmpty();
            RuleFor(x => x.TelegramType).Length(1, 30);

            RuleFor(x => x.TelegramLength).NotEmpty();
            RuleFor(x => x.TelegramLength).Length(1, 5);

            RuleFor(x => x.Sender).NotEmpty();
            RuleFor(x => x.Sender).Length(1, 10);

            RuleFor(x => x.Receiver).NotEmpty();
            RuleFor(x => x.Receiver).Length(1, 10);

            RuleFor(x => x.TelegramSeqNo).NotEmpty();
            RuleFor(x => x.TelegramSeqNo).Length(1, 10);

            RuleFor(x => x.TimeStamp).NotEmpty();

            RuleFor(x => x.TelegramSeqNo).NotEmpty();
            RuleFor(x => x.TelegramSeqNo).Length(1, 3);

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);

        }
    }
}
