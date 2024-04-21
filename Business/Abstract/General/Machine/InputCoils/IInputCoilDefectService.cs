using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.InputCoils;

namespace Business.Abstract.General.General
{
    public interface IInputCoilDefectService
    {
        public Task<IResult> Add(InputCoilDefect inputCoilDefect);
        public Task<IResult> Update(InputCoilDefect inputCoilDefect);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<InputCoilDefect>> GetById(Guid id);
        public Task<IDataResult<List<InputCoilDefect>>> GetAll();
        public Task<IDataResult<List<InputCoilDefect>>> Search(FilterDto filterDto);
    }
}
