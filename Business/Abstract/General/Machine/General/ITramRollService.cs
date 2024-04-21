using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.General;

namespace Business.Abstract.General.General
{
    public interface ITramRollService
    {
        public Task<IResult> Add(TramRoll tramRoll);
        public Task<IResult> Update(TramRoll tramRoll);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<TramRoll>> GetById(Guid id);
        public Task<IDataResult<List<TramRoll>>> GetAll();
        public Task<IDataResult<List<TramRoll>>> Search(FilterDto filterDto);
    }
}
