using Entities.Concrete.Entities.PSI.Types;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.FluentValidators.PSI.Types.PSITypeDefectListValidators
{
    public class PSITypeDefectListValidator:AbstractValidator<PSITypeDefectList>
    {
        public PSITypeDefectListValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.DefectCode).Length(1, 10);

            RuleFor(x => x.DefectBlocking).Length(1, 1);

            RuleFor(x => x.DefectSeverity).Length(1, 1);

            RuleFor(x => x.DefectComment).Length(1, 250);

            RuleFor(x => x.DefectLengthStartPos).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.DefectLength).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.DefectWidthStartPos).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.DefectWidth).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}

