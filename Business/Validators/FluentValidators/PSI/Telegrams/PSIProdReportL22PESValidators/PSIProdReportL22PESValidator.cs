using Entities.Concrete.Entities.PSI.Telegrams;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.FluentValidators.PSI.Telegrams.PSIProdReportL22PESValidators
{
    public class PSIProdReportL22PESValidator : AbstractValidator<PSIProdReportL22PES>
    {
        public PSIProdReportL22PESValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.Header).NotEmpty();

            RuleFor(x => x.EventTime).NotEmpty();

            RuleFor(x => x.LineId).NotEmpty();
            RuleFor(x => x.LineId).Length(1, 10);

            RuleFor(x => x.ProdCode).NotEmpty();
            RuleFor(x => x.ProdCode).Length(1, 10);

            RuleFor(x => x.CountInputMat).NotEmpty();
            RuleFor(x => x.CountInputMat).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.CountOutputMat).NotEmpty();
            RuleFor(x => x.CountOutputMat).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}
