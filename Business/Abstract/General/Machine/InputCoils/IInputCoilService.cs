using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.InputCoils;

namespace Business.Abstract.General.General
{
    public interface IInputCoilService
    {
        public Task<IResult> Add(InputCoil inputCoil);
        public Task<IResult> Update(InputCoil inputCoil);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<InputCoil>> GetById(Guid id);
        public Task<IDataResult<List<InputCoil>>> GetAll();
        public Task<IDataResult<List<InputCoil>>> Search(FilterDto filterDto);
    }
}
