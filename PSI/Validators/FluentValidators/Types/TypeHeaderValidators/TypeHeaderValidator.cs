using FluentValidation;
using PSI.Dtos.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI.Validators.FluentValidators.Types.TypeHeaderValidators
{
    public class TypeHeaderValidator : AbstractValidator<TypeHeader>
    {
        public TypeHeaderValidator()
        {
            RuleFor(x => x.TelegramType).NotEmpty();
            RuleFor(x => x.TelegramType).Length(1, 30);

            RuleFor(x => x.TelegramLength).Length(1, 5);

            RuleFor(x => x.Sender).Length(1, 10);

            RuleFor(x => x.Receiver).Length(1, 10);

            RuleFor(x => x.TelegramSeqNo).Length(1, 10);

            RuleFor(x => x.TimeStamp).NotEmpty();

            RuleFor(x => x.TelegramSeqNo).Length(1, 3);
        }
    }
}
