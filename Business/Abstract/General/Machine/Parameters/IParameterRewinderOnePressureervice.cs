using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.Parameters;

namespace Business.Abstract.General.General
{
    public interface IParameterRewinderOnePressureService
    {
        public Task<IResult> Add(ParameterRewinderOnePressure parameterRewinderOnePressure);
        public Task<IResult> Update(ParameterRewinderOnePressure parameterRewinderOnePressure);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<ParameterRewinderOnePressure>> GetById(Guid id);
        public Task<IDataResult<List<ParameterRewinderOnePressure>>> GetAll();
        public Task<IDataResult<List<ParameterRewinderOnePressure>>> Search(FilterDto filterDto);
    }
}
