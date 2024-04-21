using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.InputCoils;

namespace Business.Abstract.General.General
{
    public interface IInputCoilAttachmentService
    {
        public Task<IResult> Add(InputCoilAttachment inputCoilAttachment);
        public Task<IResult> Update(InputCoilAttachment inputCoilAttachment);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<InputCoilAttachment>> GetById(Guid id);
        public Task<IDataResult<List<InputCoilAttachment>>> GetAll();
        public Task<IDataResult<List<InputCoilAttachment>>> Search(FilterDto filterDto);
    }
}
