using Entities.Concrete.Dtos.PSI.Types;
using FluentValidation;
using PSI.Validators.FluentValidators.Types.TypeHeaderValidators;

namespace Business.Validators.FluentValidators.PSI.Transfers
{
    public class SetTypeHeaderDtoValidator : AbstractValidator<SetTypeHeaderDto>
    {
        public SetTypeHeaderDtoValidator()
        {
            RuleFor(x => x.typeHeader).SetValidator(new TypeHeaderValidator());

            RuleFor(x => x.psiTypeHeaderId).NotEmpty();

            RuleFor(x => x.psiTypeTimeStampId).NotEmpty();
        }
    }
}
