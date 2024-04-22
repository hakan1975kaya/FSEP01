using Entities.Concrete.Dtos.PSI.Types;
using FluentValidation;
using PSI.Validators.FluentValidators.Types.TypeInputMatCoordValidators;

namespace Business.Validators.FluentValidators.PSI.Transfers
{
    public class SetTypeInputMatCoordsDtoValidator : AbstractValidator<SetTypeInputMatCoordsDto>
    {
        public SetTypeInputMatCoordsDtoValidator()
        {
            RuleForEach(x => x.typeInputMatCoords).SetValidator(new TypeInputMatCoordValidator());

            RuleFor(x => x.psiTypeOutputMatTarget).NotEmpty();
        }
    }
}
