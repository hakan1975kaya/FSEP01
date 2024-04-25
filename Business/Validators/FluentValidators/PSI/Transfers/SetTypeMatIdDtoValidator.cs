using Entities.Concrete.Dtos.PSI.Types;
using FluentValidation;
using PSI.Validators.FluentValidators.Types.TypeMatIdValidators;

namespace Business.Validators.FluentValidators.PSI.Transfers
{
    public class SetTypeMatIdDtoValidator : AbstractValidator<SetTypeMatIdDto>
    {
        public SetTypeMatIdDtoValidator()
        {
            RuleFor(x => x.typeMatId).SetValidator(new TypeMatIdValidator());

            RuleFor(x => x.psiTypeMatIdId).NotEmpty();

        }
    }
}