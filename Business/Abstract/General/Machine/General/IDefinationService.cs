using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.General;

namespace Business.Abstract.General.General
{
    public interface IDefinationService
    {
        public Task<IResult> Add(Defination defination);
        public Task<IResult> Update(Defination defination);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<Defination>> GetById(Guid id);
        public Task<IDataResult<List<Defination>>> GetAll();
        public Task<IDataResult<List<Defination>>> Search(FilterDto filterDto);
    }
}
