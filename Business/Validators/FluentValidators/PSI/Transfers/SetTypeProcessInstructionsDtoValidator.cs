using Entities.Concrete.Dtos.PSI.Types;
using FluentValidation;
using PSI.Validators.FluentValidators.Types.TypeProcessInstructionsValidators;

namespace Business.Validators.FluentValidators.PSI.Transfers
{
    public class SetTypeProcessInstructionsDtoValidator : AbstractValidator<SetTypeProcessInstructionsDto>
    {
        public SetTypeProcessInstructionsDtoValidator()
        {
            RuleForEach(x => x.typeProcessInstructions).SetValidator(new TypeProcessInstructionsValidator());

            RuleFor(x => x.psiProcessDataPES2L2).NotEmpty();
        }
    }
}
