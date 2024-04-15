using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.PSI.Types;

namespace Business.Abstract.PSI.Types
{
    public interface IPSITypeOutputMatService
    {
        public Task<IResult> Add(PSITypeOutputMat psiTypeOutputMat);
        public Task<IResult> Update(PSITypeOutputMat psiTypeOutputMat);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<PSITypeOutputMat>> GetById(Guid id);
        public Task<IDataResult<List<PSITypeOutputMat>>> GetAll();
        public Task<IDataResult<List<PSITypeOutputMat>>> Search(FilterDto filterDto);
    }
}
