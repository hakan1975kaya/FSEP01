using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.Parameters;

namespace Business.Abstract.General.General
{
    public interface IParameterMachineService
    {
        public Task<IResult> Add(ParameterMachine parameterMachine);
        public Task<IResult> Update(ParameterMachine parameterMachine);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<ParameterMachine>> GetById(Guid id);
        public Task<IDataResult<List<ParameterMachine>>> GetAll();
        public Task<IDataResult<List<ParameterMachine>>> Search(FilterDto filterDto);
    }
}
