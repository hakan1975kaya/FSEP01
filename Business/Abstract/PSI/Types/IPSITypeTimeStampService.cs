using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.PSI.Types;

namespace Business.Abstract.PSI.Types
{
    public interface IPSITypeTimeStampService
    {
        public Task<IResult> Add(PSITypeTimeStamp psiTypeTimeStamp);
        public Task<IResult> Update(PSITypeTimeStamp psiTypeTimeStamp);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<PSITypeTimeStamp>> GetById(Guid id);
        public Task<IDataResult<List<PSITypeTimeStamp>>> GetAll();
        public Task<IDataResult<List<PSITypeTimeStamp>>> Search(FilterDto filterDto);
    }
}
