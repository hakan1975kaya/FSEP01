using Entities.Concrete.Dtos.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.FluentValidators.UserValidators
{
    public class PasswordChangeDtoValidator : AbstractValidator<PasswordChangeDto>
    {
        public PasswordChangeDtoValidator()
        {
            RuleFor(x => x.RegistrationNumber).NotEmpty();
            RuleFor(x => x.RegistrationNumber).InclusiveBetween(1, 99999);

            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Password).Length(2, 50);
        }
    }
}

