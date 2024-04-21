using FluentValidation;
using PSI.Dtos.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI.Validators.FluentValidators.Types.TypeProcessValidators
{
    public class TypeProcessValidator : AbstractValidator<TypeProcess>
    {
        public TypeProcessValidator()
        {
            RuleFor(x => x.ProcessId).NotEmpty();
            RuleFor(x => x.ProcessId).Length(1, 100);

            RuleFor(x => x.ProcessPhase).Length(1, 100);
        }
    }
}
