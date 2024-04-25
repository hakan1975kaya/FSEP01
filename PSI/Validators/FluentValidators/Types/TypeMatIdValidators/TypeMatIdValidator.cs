using FluentValidation;
using PSI.Dtos.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI.Validators.FluentValidators.Types.TypeMatIdValidators
{
    public class TypeMatIdValidator : AbstractValidator<TypeMatId>
    {
        public TypeMatIdValidator()
        {
            RuleFor(x => x.GlobalId).Length(1, 40);

            RuleFor(x => x.LocalId).Length(1, 40);

            RuleFor(x => x.LocalId).Length(1, 40);

            RuleFor(x => x.InternalId).Length(1, 40);
        }
    }
}

