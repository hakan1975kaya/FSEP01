using Core.Entities.Concrete;
using Entities.Concrete.Entities.General.Machine.General;
using Entities.Concrete.Entities.General.Machine.InputCoils;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.FluentValidators.General.General.DemandValidators
{
    public class InputCoilDefectValidator : AbstractValidator<InputCoilDefect>
    {
        public InputCoilDefectValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.InputCoilId).NotEmpty();

            RuleFor(x => x.ProcedureInstructionRequestNumber).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.SquenceNumber).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.LocalId).Length(2, 25);

            RuleFor(x => x.DefectCode).Length(2, 25);

            RuleFor(x => x.DefectBlocking).Length(2, 25);

            RuleFor(x => x.DefectSeverity).Length(2, 25);

            RuleFor(x => x.DefectComment).Length(2, 125);

            RuleFor(x => x.DefectLengthStartPosition).InclusiveBetween(float.MinValue, float.MaxValue);

            RuleFor(x => x.DefectLength).InclusiveBetween(float.MinValue, float.MaxValue);

            RuleFor(x => x.DefectWidthStartPosition).InclusiveBetween(float.MinValue, float.MaxValue);

            RuleFor(x => x.DefectWidth).InclusiveBetween(float.MinValue, float.MaxValue);

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}
