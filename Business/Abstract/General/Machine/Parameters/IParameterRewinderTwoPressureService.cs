using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.Parameters;

namespace Business.Abstract.General.General
{
    public interface IParameterRewinderTwoPressureService
    {
        public Task<IResult> Add(ParameterRewinderTwoPressure parameterRewinderTwoPressure);
        public Task<IResult> Update(ParameterRewinderTwoPressure parameterRewinderTwoPressure);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<ParameterRewinderTwoPressure>> GetById(Guid id);
        public Task<IDataResult<List<ParameterRewinderTwoPressure>>> GetAll();
        public Task<IDataResult<List<ParameterRewinderTwoPressure>>> Search(FilterDto filterDto);
    }
}
