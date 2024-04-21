using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.Parameters;

namespace Business.Abstract.General.General
{
    public interface IParameterRewinderTwoTensionService
    {
        public Task<IResult> Add(ParameterRewinderTwoTension parameterRewinderTwoTension);
        public Task<IResult> Update(ParameterRewinderTwoTension parameterRewinderTwoTension);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<ParameterRewinderTwoTension>> GetById(Guid id);
        public Task<IDataResult<List<ParameterRewinderTwoTension>>> GetAll();
        public Task<IDataResult<List<ParameterRewinderTwoTension>>> Search(FilterDto filterDto);
    }
}
