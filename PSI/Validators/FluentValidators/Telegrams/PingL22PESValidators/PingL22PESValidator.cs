using Entities.Concrete.Entities.PSI.Telegrams;
using FluentValidation;
using PSI.Dtos.Telegrams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI.Validators.FluentValidators.Telegrams.PSIPingL22PESValidators
{
    public class PingL22PESValidator : AbstractValidator<PingL22PES>
    {
        public PingL22PESValidator()
        {
            RuleFor(x => x.Header).NotEmpty();
        }
    }
}
