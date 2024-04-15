using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.PSI.Types;

namespace Business.Abstract.PSI.Types
{
    public interface IPSITypeOutputMatTargetService
    {
        public Task<IResult> Add(PSITypeOutputMatTarget psiTypeOutputMatTarget);
        public Task<IResult> Update(PSITypeOutputMatTarget psiTypeOutputMatTarget);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<PSITypeOutputMatTarget>> GetById(Guid id);
        public Task<IDataResult<List<PSITypeOutputMatTarget>>> GetAll();
        public Task<IDataResult<List<PSITypeOutputMatTarget>>> Search(FilterDto filterDto);
    }
}
