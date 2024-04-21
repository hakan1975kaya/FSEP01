using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.General;

namespace Business.Abstract.General.General
{
    public interface ILubracationRollService
    {
        public Task<IResult> Add(LubracationRoll lubracationRoll);
        public Task<IResult> Update(LubracationRoll lubracationRoll);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<LubracationRoll>> GetById(Guid id);
        public Task<IDataResult<List<LubracationRoll>>> GetAll();
        public Task<IDataResult<List<LubracationRoll>>> Search(FilterDto filterDto);
    }
}
