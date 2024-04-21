using FluentValidation;
using PSI.Dtos.Telegrams;
using PSI.Dtos.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI.Validators.FluentValidators.Telegrams.PSIProdReportL22PESValidators
{
    public class ProdReportL22PESValidator : AbstractValidator<ProdReportL22PES>
    {
        public ProdReportL22PESValidator()
        {
            RuleFor(x => x.Header).NotEmpty();

            RuleFor(x => x.LineId).Length(1, 10);

            RuleFor(x => x.ProdCode).Length(1, 10);

            RuleFor(x => x.CountInputMat).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.CountOutputMat).InclusiveBetween(decimal.MinValue, decimal.MaxValue);
        }
    }
}