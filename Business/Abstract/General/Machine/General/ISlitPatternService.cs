using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.General;

namespace Business.Abstract.General.General
{
    public interface ISlitPatternService
    {
        public Task<IResult> Add(SlitPattern slitPattern);
        public Task<IResult> Update(SlitPattern slitPattern);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<SlitPattern>> GetById(Guid id);
        public Task<IDataResult<List<SlitPattern>>> GetAll();
        public Task<IDataResult<List<SlitPattern>>> Search(FilterDto filterDto);
    }
}
