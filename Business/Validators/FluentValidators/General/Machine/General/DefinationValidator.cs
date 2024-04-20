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
    public class DefinationValidator : AbstractValidator<Defination>
    {
        public DefinationValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.MessageId).NotEmpty();
            RuleFor(x => x.MessageId).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.TelegramType).NotEmpty();
            RuleFor(x => x.TelegramType).Length(2, 30);

            RuleFor(x => x.TelegramLength).Length(2, 5);

            RuleFor(x => x.Sender).Length(2, 10);

            RuleFor(x => x.Reciever).Length(2, 10);

            RuleFor(x => x.TelegramSequenceNumber).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.TimeStamp).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.AckReq).Length(2, 3);

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}
