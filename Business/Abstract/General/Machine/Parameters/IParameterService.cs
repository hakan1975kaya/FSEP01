using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.Parameters;

namespace Business.Abstract.General.General
{
    public interface IParameterService
    {
        public Task<IResult> Add(Parameter parameter);
        public Task<IResult> Update(Parameter parameter);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<Parameter>> GetById(Guid id);
        public Task<IDataResult<List<Parameter>>> GetAll();
        public Task<IDataResult<List<Parameter>>> Search(FilterDto filterDto);
    }
}
