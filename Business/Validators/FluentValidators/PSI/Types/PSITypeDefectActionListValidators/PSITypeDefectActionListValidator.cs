using Entities.Concrete.Entities.PSI.Types;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.FluentValidators.PSI.Types.PSITypeDefectActionListValidators
{
    public class PSITypeDefectActionListValidator:AbstractValidator<PSITypeDefectActionList>
    {
        public PSITypeDefectActionListValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.PSIProcessStateL22PES).NotEmpty();

            RuleFor(x => x.Action).NotEmpty();
            RuleFor(x => x.Action).Length(1, 10);

            RuleFor(x => x.CountDefects).NotEmpty();
            RuleFor(x => x.CountDefects).Length(1, 1);

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}
