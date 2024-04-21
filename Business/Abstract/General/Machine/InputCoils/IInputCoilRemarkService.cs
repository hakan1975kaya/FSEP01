using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.InputCoils;

namespace Business.Abstract.General.General
{
    public interface IInputCoilRemarkService
    {
        public Task<IResult> Add(InputCoilRemark inputCoilRemark);
        public Task<IResult> Update(InputCoilRemark inputCoilRemark);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<InputCoilRemark>> GetById(Guid id);
        public Task<IDataResult<List<InputCoilRemark>>> GetAll();
        public Task<IDataResult<List<InputCoilRemark>>> Search(FilterDto filterDto);
    }
}
