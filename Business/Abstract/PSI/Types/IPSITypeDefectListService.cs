using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.PSI.Types;

namespace Business.Abstract.PSI.Types
{
    public interface IPSITypeDefectListService
    {
        public Task<IResult> Add(PSITypeDefectList psiTypeDefectList);
        public Task<IResult> Update(PSITypeDefectList psiTypeDefectList);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<PSITypeDefectList>> GetById(Guid id);
        public Task<IDataResult<List<PSITypeDefectList>>> GetAll();
        public Task<IDataResult<List<PSITypeDefectList>>> Search(FilterDto filterDto);
    }
}
