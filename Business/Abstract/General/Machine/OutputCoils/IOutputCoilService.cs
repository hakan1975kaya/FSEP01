using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.OutputCoils;

namespace Business.Abstract.General.General
{
    public interface IOutputCoilService
    {
        public Task<IResult> Add(OutputCoil outputCoil);
        public Task<IResult> Update(OutputCoil outputCoil);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<OutputCoil>> GetById(Guid id);
        public Task<IDataResult<List<OutputCoil>>> GetAll();
        public Task<IDataResult<List<OutputCoil>>> Search(FilterDto filterDto);
    }
}
