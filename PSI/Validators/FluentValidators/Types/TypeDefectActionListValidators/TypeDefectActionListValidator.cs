using FluentValidation;
using PSI.Dtos.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI.Validators.FluentValidators.Types.TypeDefectActionListValidators
{
    public class TypeDefectActionListValidator : AbstractValidator<TypeDefectActionList>
    {
        public TypeDefectActionListValidator()
        {
            RuleFor(x => x.Action).Length(1, 10);

            RuleFor(x => x.CountDefects).Length(1, 1);
        }
    }
}
