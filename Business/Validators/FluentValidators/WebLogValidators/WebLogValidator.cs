﻿using Core.Entities.Concrete;
using Entities.Concrete.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.FluentValidators.WebLogValidators
{
    public class WebLogValidator : AbstractValidator<WebLog>
    {
        public WebLogValidator()
        {
            RuleFor(x => x.Detail).NotEmpty();
            RuleFor(x => x.Detail).Length(2, int.MaxValue);

            RuleFor(x => x.Date).NotEmpty();
            RuleFor(x => x.Date).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.Audit).NotEmpty();
            RuleFor(x => x.Audit).IsInEnum();
        }
    }
}
