using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.General;

namespace Business.Abstract.General.General
{
    public interface IContactRollService
    {
        public Task<IResult> Add(ContactRoll contactRoll);
        public Task<IResult> Update(ContactRoll contactRoll);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<ContactRoll>> GetById(Guid id);
        public Task<IDataResult<List<ContactRoll>>> GetAll();
        public Task<IDataResult<List<ContactRoll>>> Search(FilterDto filterDto);
    }
}
