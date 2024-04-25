using Entities.Concrete.Dtos.PSI.Types;
using FluentValidation;
using PSI.Validators.FluentValidators.Types.TypeInputMatValidators;

namespace Business.Validators.FluentValidators.PSI.Transfers
{
    public class SetTypeInputMatDtoValidator: AbstractValidator<SetTypeInputMatDto>
    {
        public SetTypeInputMatDtoValidator()
        {
            RuleFor(x => x.typeInputMat).SetValidator(new TypeInputMatValidator());

            RuleFor(x => x.psiTypeInputMatId).NotEmpty();

            RuleFor(x => x.psiTypeMatId).NotEmpty();
        }
 
    }
}
