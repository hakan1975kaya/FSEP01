using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.OutputCoils;

namespace Business.Abstract.General.General
{
    public interface IOutputCoilOtherService
    {
        public Task<IResult> Add(OutputCoilOther outputCoilOther);
        public Task<IResult> Update(OutputCoilOther outputCoilOther);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<OutputCoilOther>> GetById(Guid id);
        public Task<IDataResult<List<OutputCoilOther>>> GetAll();
        public Task<IDataResult<List<OutputCoilOther>>> Search(FilterDto filterDto);
    }
}
