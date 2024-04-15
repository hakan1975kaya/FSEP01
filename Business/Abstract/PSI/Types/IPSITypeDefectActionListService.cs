using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.PSI.Types;

namespace Business.Abstract.PSI.Types
{
    public interface IPSITypeDefectActionListService
    {
        public Task<IResult> Add(PSITypeDefectActionList psiTypeDefectActionList);
        public Task<IResult> Update(PSITypeDefectActionList psiTypeDefectActionList);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<PSITypeDefectActionList>> GetById(Guid id);
        public Task<IDataResult<List<PSITypeDefectActionList>>> GetAll();
        public Task<IDataResult<List<PSITypeDefectActionList>>> Search(FilterDto filterDto);
    }
}
