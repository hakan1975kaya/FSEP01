﻿using Core.Entities.Concrete;
using Entities.Concrete.Entities.General.Machine.General;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.FluentValidators.General.General.DemandValidators
{
    public class ContactRollValidator : AbstractValidator<ContactRoll>
    {
        public ContactRollValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.RollNumber).NotEmpty();
            RuleFor(x => x.RollNumber).Length(2, 50);

            RuleFor(x => x.RollDiameter).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.GroupName).Length(2, 60);

            RuleFor(x => x.RollName).Length(2, 60);

            RuleFor(x => x.Hardness).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.Roughness).Length(2, 50);

            RuleFor(x => x.Status).Length(2, 50);

            RuleFor(x => x.Location).Length(2, 50);

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}
