using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.Parameters;

namespace Business.Abstract.General.General
{
    public interface IParameterApplyingUnitService
    {
        public Task<IResult> Add(ParameterApplyingUnit parameterApplyingUnit);
        public Task<IResult> Update(ParameterApplyingUnit parameterApplyingUnit);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<ParameterApplyingUnit>> GetById(Guid id);
        public Task<IDataResult<List<ParameterApplyingUnit>>> GetAll();
        public Task<IDataResult<List<ParameterApplyingUnit>>> Search(FilterDto filterDto);
    }
}
