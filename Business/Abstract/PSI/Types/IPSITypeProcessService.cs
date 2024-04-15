using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.PSI.Types;

namespace Business.Abstract.PSI.Types
{
    public interface IPSITypeProcessService
    {
        public Task<IResult> Add(PSITypeProcess psiTypeProcess);
        public Task<IResult> Update(PSITypeProcess psiTypeProcess);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<PSITypeProcess>> GetById(Guid id);
        public Task<IDataResult<List<PSITypeProcess>>> GetAll();
        public Task<IDataResult<List<PSITypeProcess>>> Search(FilterDto filterDto);
    }
}
