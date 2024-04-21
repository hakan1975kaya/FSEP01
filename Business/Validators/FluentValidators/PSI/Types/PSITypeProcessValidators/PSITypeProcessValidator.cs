using Entities.Concrete.Entities.PSI.Types;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.FluentValidators.PSI.Types.PSITypeProcessValidators
{
    public class PSITypeProcessValidator:AbstractValidator<PSITypeProcess>
    {
        public PSITypeProcessValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.ProcessId).NotEmpty();
            RuleFor(x => x.ProcessId).Length(1, 100);

            RuleFor(x => x.ProcessPhase).Length(1, 100);

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}
