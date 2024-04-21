using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.Parameters;

namespace Business.Abstract.General.General
{
    public interface IParameterBasicDataService
    {
        public Task<IResult> Add(ParameterBasicData parameterBasicData);
        public Task<IResult> Update(ParameterBasicData parameterBasicData);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<ParameterBasicData>> GetById(Guid id);
        public Task<IDataResult<List<ParameterBasicData>>> GetAll();
        public Task<IDataResult<List<ParameterBasicData>>> Search(FilterDto filterDto);
    }
}
