using FluentValidation;
using PSI.Dtos.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI.Validators.FluentValidators.Types.TypeDefectListValidators
{
    public class TypeDefectListValidator : AbstractValidator<TypeDefectList>
    {
        public TypeDefectListValidator()
        {

            RuleFor(x => x.DefectCode).Length(1, 10);

            RuleFor(x => x.DefectBlocking).Length(1, 1);

            RuleFor(x => x.DefectSeverity).Length(1, 1);

            RuleFor(x => x.DefectComment).Length(1, 250);

            RuleFor(x => x.DefectLengthStartPos).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.DefectLength).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.DefectWidthStartPos).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.DefectWidth).InclusiveBetween(decimal.MinValue, decimal.MaxValue);
        }
    }
}

