using Entities.Concrete.Dtos.PSI.Types;
using FluentValidation;
using PSI.Validators.FluentValidators.Types.TypeTimeStampValidators;
namespace Business.Validators.FluentValidators.PSI.Transfers
{
    public class SetTypeTimeStampDtoValidator : AbstractValidator<SetTypeTimeStampDto>
    {
        public SetTypeTimeStampDtoValidator()
        {
            RuleFor(x => x.typeTimeStamp).SetValidator(new TypeTimeStampValidator());

            RuleFor(x => x.psiTypeTimeStampId).NotEmpty();
        }
    }
}
