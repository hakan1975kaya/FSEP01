using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.General;

namespace Business.Abstract.General.General
{
    public interface IDensityService
    {
        public Task<IResult> Add(Density density);
        public Task<IResult> Update(Density density);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<Density>> GetById(Guid id);
        public Task<IDataResult<List<Density>>> GetAll();
        public Task<IDataResult<List<Density>>> Search(FilterDto filterDto);
    }
}
