using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.Parameters;

namespace Business.Abstract.General.General
{
    public interface IParameterSuctionService
    {
        public Task<IResult> Add(ParameterSuction parameterSuction);
        public Task<IResult> Update(ParameterSuction parameterSuction);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<ParameterSuction>> GetById(Guid id);
        public Task<IDataResult<List<ParameterSuction>>> GetAll();
        public Task<IDataResult<List<ParameterSuction>>> Search(FilterDto filterDto);
    }
}
