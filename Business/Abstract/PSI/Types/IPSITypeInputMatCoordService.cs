using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.PSI.Types;

namespace Business.Abstract.PSI.Types
{
    public interface IPSITypeInputMatCoordService
    {
        public Task<IResult> Add(PSITypeInputMatCoord psiTypeInputMatCoord);
        public Task<IResult> Update(PSITypeInputMatCoord psiTypeInputMatCoord);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<PSITypeInputMatCoord>> GetById(Guid id);
        public Task<IDataResult<List<PSITypeInputMatCoord>>> GetAll();
        public Task<IDataResult<List<PSITypeInputMatCoord>>> Search(FilterDto filterDto);
    }
}
