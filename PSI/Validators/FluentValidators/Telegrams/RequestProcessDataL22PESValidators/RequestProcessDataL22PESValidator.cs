using FluentValidation;
using PSI.Dtos.Telegrams;
using PSI.Dtos.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI.Validators.FluentValidators.Telegrams.PSIRequestProcessDataL22PESValidators
{
    public class RequestProcessDataL22PESValidator : AbstractValidator<RequestProcessDataL22PES>
    {
        public RequestProcessDataL22PESValidator()
        {
            RuleFor(x => x.Header).NotEmpty();

            RuleFor(x => x.LineId).Length(1, 10);

            RuleFor(x => x.ReqType).Length(1, 3);

            RuleFor(x => x.ReqCategory).Length(1, 20);

            RuleFor(x => x.ReqKey).Length(1, 40);

            RuleFor(x => x.SubLine).Length(1, 10);

            RuleFor(x => x.EventCode).Length(1, 20);

            RuleFor(x => x.Remark).Length(1, 512);
        }
    }
}