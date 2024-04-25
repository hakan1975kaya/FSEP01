using Entities.Concrete.Entities.PSI.Telegrams;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.FluentValidators.PSI.Telegrams.PSIRequestProcessDataL22PESValidators
{
    public class PSIRequestProcessDataL22PESValidator : AbstractValidator<PSIRequestProcessDataL22PES>
    {
        public PSIRequestProcessDataL22PESValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.Header).NotEmpty();

            RuleFor(x => x.LineId).Length(1, 10);

            RuleFor(x => x.ReqType).Length(1, 3);

            RuleFor(x => x.ReqCategory).Length(1, 20);

            RuleFor(x => x.ReqKey).Length(1, 40);

            RuleFor(x => x.SubLine).Length(1, 10);

            RuleFor(x => x.EventCode).Length(1, 20);

            RuleFor(x => x.Remark).Length(1, 512);

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}
