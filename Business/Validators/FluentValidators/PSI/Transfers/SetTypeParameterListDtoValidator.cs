using Entities.Concrete.Dtos.PSI.Types;
using FluentValidation;
using PSI.Validators.FluentValidators.Types.TypeParameterListValidators;
namespace Business.Validators.FluentValidators.PSI.Transfers
{
    public class SetTypeParameterListDtoValidator : AbstractValidator<SetTypeParameterListDto>
    {
        public SetTypeParameterListDtoValidator()
        {
            RuleForEach(x => x.typeParameterLists).SetValidator(new TypeParameterListValidator());
        }
    }
}
