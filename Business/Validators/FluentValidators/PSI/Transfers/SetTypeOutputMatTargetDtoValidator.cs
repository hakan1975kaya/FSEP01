using Entities.Concrete.Dtos.PSI.Types;
using FluentValidation;
using PSI.Validators.FluentValidators.Types.TypeOutputMatTargetValidators;
namespace Business.Validators.FluentValidators.PSI.Transfers
{
    public class SetTypeOutputMatTargetDtoValidator : AbstractValidator<SetTypeOutputMatTargetDto>
    {
        public SetTypeOutputMatTargetDtoValidator()
        {
            RuleForEach(x => x.typeOutputMatTargets).SetValidator(new TypeOutputMatTargetValidator());

            RuleFor(x => x.psiTypeMatId).NotEmpty();

            RuleFor(x => x.psiTypeIProcessInstructions).NotEmpty();
        }
    }
}