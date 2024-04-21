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
    public class InputCoilAttachmentValidator : AbstractValidator<InputCoilAttachment>
    {
        public InputCoilAttachmentValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.InputCoilId).NotEmpty();

            RuleFor(x => x.FileName).Length(2, 100);

            RuleFor(x => x.Path).Length(2, 300);

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}
