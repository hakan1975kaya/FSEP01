using Core.Entities.Concrete;
using Entities.Concrete.Entities.General.Machine.General;
using Entities.Concrete.Entities.General.Machine.Parameters;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.FluentValidators.General.Machine.Parameters
{
    public class ParameterMachineValidator : AbstractValidator<ParameterMachine>
    {
        public ParameterMachineValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.ParameterId).NotEmpty();

            RuleFor(x => x.TransportMachineTension).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.TransportOneTension).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.TransportTwoTension).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.MachineSpeedSet).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.Acceleration).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}
