using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.General;
using Entities.Concrete.Entities.General.Machine.ProcessCoils;

namespace Business.Abstract.General.General
{
    public interface IProcessCoilService
    {
        public Task<IResult> Add(ProcessCoil processCoil);
        public Task<IResult> Update(ProcessCoil processCoil);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<ProcessCoil>> GetById(Guid id);
        public Task<IDataResult<List<ProcessCoil>>> GetAll();
        public Task<IDataResult<List<ProcessCoil>>> Search(FilterDto filterDto);
    }
}
