using Entities.Concrete.Entities.PSI.Types;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.FluentValidators.PSI.Types.PSITypeProcessInstructionsValidators
{
    internal class PSITypeProcessInstructionsValidator:AbstractValidator<PSITypeProcessInstructions>
    {
        public PSITypeProcessInstructionsValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.PSIProcessDataPES2L2).NotEmpty();

            RuleFor(x => x.InputMat).NotEmpty();

            RuleFor(x => x.CountOutputMat).NotEmpty();
            RuleFor(x => x.CountOutputMat).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.CountProdParameter).NotEmpty();
            RuleFor(x => x.CountProdParameter).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}
