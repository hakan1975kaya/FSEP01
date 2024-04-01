using Entities.Concrete.Dtos.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.FluentValidators.UserValidators
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(x => x.RegistrationNumber).NotEmpty();
            RuleFor(x => x.RegistrationNumber).InclusiveBetween(1, 99999);

            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.FirstName).Length(2, 50);

            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.LastName).Length(2, 50);

            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Password).Length(2, 50);

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}

