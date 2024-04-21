using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.Parameters;

namespace Business.Abstract.General.General
{
    public interface IParameterSpeedCharacteristicService
    {
        public Task<IResult> Add(ParameterSpeedCharacteristic parameterSpeedCharacteristic);
        public Task<IResult> Update(ParameterSpeedCharacteristic parameterSpeedCharacteristic);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<ParameterSpeedCharacteristic>> GetById(Guid id);
        public Task<IDataResult<List<ParameterSpeedCharacteristic>>> GetAll();
        public Task<IDataResult<List<ParameterSpeedCharacteristic>>> Search(FilterDto filterDto);
    }
}
