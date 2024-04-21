using Core.Entities.Concrete;
using Entities.Concrete.Entities.General.Machine.General;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.FluentValidators.General.General.DemandValidators
{
    public class LevelThreeTelegramValidator : AbstractValidator<LevelThreeTelegram>
    {
        public LevelThreeTelegramValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.LineId).Length(2, 25);

            RuleFor(x => x.TelegramType).Length(2, 25);

            RuleFor(x => x.TelegramOccurrenceTime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.TelegramSendTime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.Payload).Length(2, int.MaxValue);

            RuleFor(x => x.TelegramContent).Length(2, int.MaxValue);

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}
