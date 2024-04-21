using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.General;

namespace Business.Abstract.General.General
{
    public interface IUsageAreaService
    {
        public Task<IResult> Add(UsageArea usageArea);
        public Task<IResult> Update(UsageArea usageArea);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<UsageArea>> GetById(Guid id);
        public Task<IDataResult<List<UsageArea>>> GetAll();
        public Task<IDataResult<List<UsageArea>>> Search(FilterDto filterDto);
    }
}
