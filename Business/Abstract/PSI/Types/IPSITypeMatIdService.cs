using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.PSI.Types;

namespace Business.Abstract.PSI.Types
{
    public interface IPSITypeMatIdService
    {
        public Task<IResult> Add(PSITypeMatId psiTypeMatId);
        public Task<IResult> Update(PSITypeMatId psiTypeMatId);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<PSITypeMatId>> GetById(Guid id);
        public Task<IDataResult<List<PSITypeMatId>>> GetAll();
        public Task<IDataResult<List<PSITypeMatId>>> Search(FilterDto filterDto);
    }
}
