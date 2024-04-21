using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.General;

namespace Business.Abstract.General.General
{
    public interface IEventService
    {
        public Task<IResult> Add(Event events);
        public Task<IResult> Update(Event events);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<Event>> GetById(Guid id);
        public Task<IDataResult<List<Event>>> GetAll();
        public Task<IDataResult<List<Event>>> Search(FilterDto filterDto);
    }
}
