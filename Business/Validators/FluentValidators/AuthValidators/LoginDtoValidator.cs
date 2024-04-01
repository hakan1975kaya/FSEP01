using Core.Entities.Concrete;
using Entities.Concrete.Dtos.Auth;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.FluentValidators.AuthValidators
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.RegistrationNumber).NotEmpty();
            RuleFor(x => x.RegistrationNumber).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Password).Length(2,10);
        }
    }
}
