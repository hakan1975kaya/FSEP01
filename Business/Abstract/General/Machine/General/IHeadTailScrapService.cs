using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.General;

namespace Business.Abstract.General.General
{
    public interface IHeadTailScrapService
    {
        public Task<IResult> Add(HeadTailScrap headTailScrap);
        public Task<IResult> Update(HeadTailScrap headTailScrap);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<HeadTailScrap>> GetById(Guid id);
        public Task<IDataResult<List<HeadTailScrap>>> GetAll();
        public Task<IDataResult<List<HeadTailScrap>>> Search(FilterDto filterDto);
    }
}
