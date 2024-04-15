using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.PSI.Types;

namespace Business.Abstract.PSI.Types
{
    public interface IPSITypeInputMatService
    {
        public Task<IResult> Add(PSITypeInputMat psiTypeInputMat);
        public Task<IResult> Update(PSITypeInputMat psiTypeInputMat);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<PSITypeInputMat>> GetById(Guid id);
        public Task<IDataResult<List<PSITypeInputMat>>> GetAll();
        public Task<IDataResult<List<PSITypeInputMat>>> Search(FilterDto filterDto);
    }
}
