using Core.Entities.Concrete;
using Entities.Concrete.Entities.PSI;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.FluentValidators.ProcessStateL22PESValidators
{
    public class ProcessStateL22PESValidator : AbstractValidator<ProcessStateL22PES>
    {
        public ProcessStateL22PESValidator()
        {
            RuleFor(x => x.ProcessStateL22PESName).NotEmpty();
            RuleFor(x => x.ProcessStateL22PESName).Length(2,50);

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}
