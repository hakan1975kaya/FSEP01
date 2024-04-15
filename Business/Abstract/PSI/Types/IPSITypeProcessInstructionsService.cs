using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.PSI.Types;

namespace Business.Abstract.PSI.Types
{
    public interface IPSITypeProcessInstructionsService
    {
        public Task<IResult> Add(PSITypeProcessInstructions psiTypeProcessInstructions);
        public Task<IResult> Update(PSITypeProcessInstructions psiTypeProcessInstructions);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<PSITypeProcessInstructions>> GetById(Guid id);
        public Task<IDataResult<List<PSITypeProcessInstructions>>> GetAll();
        public Task<IDataResult<List<PSITypeProcessInstructions>>> Search(FilterDto filterDto);
    }
}
