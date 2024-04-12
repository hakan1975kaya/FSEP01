using Core.Entities.Concrete;
using Entities.Concrete.Dtos.General.Auth;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.FluentValidators.General.General.AuthValidators
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(x => x.RegistrationNumber).NotEmpty();
            RuleFor(x => x.RegistrationNumber).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Password).Length(2, 10);

            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.FirstName).Length(2, 50);

            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.LastName).Length(2, 50);
        }
    }
}
