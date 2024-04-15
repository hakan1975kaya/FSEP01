using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.PSI.Types;

namespace Business.Abstract.PSI.Types
{
    public interface IPSITypeHeaderService
    {
        public Task<IResult> Add(PSITypeHeader psiTypeHeader);
        public Task<IResult> Update(PSITypeHeader psiTypeHeader);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<PSITypeHeader>> GetById(Guid id);
        public Task<IDataResult<List<PSITypeHeader>>> GetAll();
        public Task<IDataResult<List<PSITypeHeader>>> Search(FilterDto filterDto);
    }
}
