using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.Parameters;

namespace Business.Abstract.General.General
{
    public interface IParameterRewinderService
    {
        public Task<IResult> Add(ParameterRewinder parameterRewinder);
        public Task<IResult> Update(ParameterRewinder parameterRewinder);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<ParameterRewinder>> GetById(Guid id);
        public Task<IDataResult<List<ParameterRewinder>>> GetAll();
        public Task<IDataResult<List<ParameterRewinder>>> Search(FilterDto filterDto);
    }
}
