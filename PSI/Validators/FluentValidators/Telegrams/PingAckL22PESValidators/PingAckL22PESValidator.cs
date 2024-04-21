using FluentValidation;
using PSI.Dtos.Telegrams;

namespace PSI.Validators.FluentValidators.Telegrams.PingAckL22PESValidators
{
    public class PingAckL22PESValidator : AbstractValidator<PingAckL22PES>
    {
        public PingAckL22PESValidator()
        {

            RuleFor(x => x.Header).NotEmpty();

            RuleFor(x => x.TelegramSeqNo).Length(1, 10);
        }
    }
}

