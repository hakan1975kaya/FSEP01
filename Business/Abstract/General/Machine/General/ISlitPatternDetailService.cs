using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.General;

namespace Business.Abstract.General.General
{
    public interface ISlitPatternDetailService
    {
        public Task<IResult> Add(SlitPatternDetail slitPatternDetail);
        public Task<IResult> Update(SlitPatternDetail slitPatternDetail);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<SlitPatternDetail>> GetById(Guid id);
        public Task<IDataResult<List<SlitPatternDetail>>> GetAll();
        public Task<IDataResult<List<SlitPatternDetail>>> Search(FilterDto filterDto);
    }
}
