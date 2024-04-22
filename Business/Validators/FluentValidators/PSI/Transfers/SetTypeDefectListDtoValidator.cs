using Entities.Concrete.Dtos.PSI.Types;
using FluentValidation;
using PSI.Validators.FluentValidators.Types.TypeDefectListValidators;

namespace Business.Validators.FluentValidators.PSI.Transfers
{
    public class SetTypeDefectListDtoValidator : AbstractValidator<SetTypeDefectListDto>
    {
        public SetTypeDefectListDtoValidator()
        {
            RuleForEach(x => x.typeDefectLists).SetValidator(new TypeDefectListValidator());
        }
    }
}
