using FluentValidation;
using PSI.Dtos.Telegrams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI.Validators.FluentValidators.Telegrams.PSIPingPES2L2Validators
{
    public class PingPES2L2Validator : AbstractValidator<PingPES2L2>
    {
        public PingPES2L2Validator()
        {
            RuleFor(x => x.Header).NotEmpty();
        }
    }
}

