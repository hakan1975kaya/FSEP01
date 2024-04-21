using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.Parameters;

namespace Business.Abstract.General.General
{
    public interface IParameterRewinderOneTensionService
    {
        public Task<IResult> Add(ParameterRewinderOneTension parameterRewinderOneTension);
        public Task<IResult> Update(ParameterRewinderOneTension parameterRewinderOneTension);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<ParameterRewinderOneTension>> GetById(Guid id);
        public Task<IDataResult<List<ParameterRewinderOneTension>>> GetAll();
        public Task<IDataResult<List<ParameterRewinderOneTension>>> Search(FilterDto filterDto);
    }
}
