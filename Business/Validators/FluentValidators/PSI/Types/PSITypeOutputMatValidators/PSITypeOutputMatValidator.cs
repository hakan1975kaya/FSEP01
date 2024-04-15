using Entities.Concrete.Entities.PSI.Types;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.FluentValidators.PSI.Types.PSITypeOutputMatValidators
{
    public class PSITypeOutputMatValidator:AbstractValidator<PSITypeOutputMat>
    {
        public PSITypeOutputMatValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.PSIProdReportL22PES).NotEmpty();

            RuleFor(x => x.MatId).NotEmpty();

            RuleFor(x => x.KindOfOutput).NotEmpty();
            RuleFor(x => x.KindOfOutput).Length(1, 10);

            RuleFor(x => x.ProdStart).NotEmpty();

            RuleFor(x => x.ProdEnd).NotEmpty();

            RuleFor(x => x.ProdDuration).NotEmpty();
            RuleFor(x => x.ProdDuration).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.CountOutputParameter).NotEmpty();
            RuleFor(x => x.CountOutputParameter).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.CountOutputDefects).NotEmpty();
            RuleFor(x => x.CountOutputDefects).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}
