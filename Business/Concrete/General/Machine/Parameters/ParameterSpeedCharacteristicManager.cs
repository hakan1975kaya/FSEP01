using Business.Abstract.General.General;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages.General.General;
using Business.Validators.FluentValidators.General.Machine.Parameters;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract.General.Machine.Parameters;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.Parameters;

namespace Business.Concrete.General.General
{
    [LogAspect(typeof(DatabaseLogger), Priority = 1)]
    public class ParameterSpeedCharacteristicManager : IParameterSpeedCharacteristicService
    {
        private IParameterSpeedCharacteristicDal _parameterSpeedCharacteristicDal;
        public ParameterSpeedCharacteristicManager(IParameterSpeedCharacteristicDal parameterSpeedCharacteristicDal)
        {
            _parameterSpeedCharacteristicDal = parameterSpeedCharacteristicDal;
        }

        [SecurityAspect("ParameterSpeedCharacteristic.Add", Priority = 2)]
        [ValidationAspect(typeof(ParameterSpeedCharacteristicValidator), Priority = 3)]
        [CacheRemoveAspect("IParameterSpeedCharacteristicService.Get", Priority = 4)]
        public async Task<IResult> Add(ParameterSpeedCharacteristic parameterSpeedCharacteristic)
        {
            await _parameterSpeedCharacteristicDal.Add(parameterSpeedCharacteristic);
            return new SuccessResult(ParameterSpeedCharacteristicMessages.Added);
        }

        [SecurityAspect("ParameterSpeedCharacteristic.Delete", Priority = 2)]
        [CacheRemoveAspect("IParameterSpeedCharacteristicService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var parameterSpeedCharacteristicDataResult = await GetById(id);
            if (parameterSpeedCharacteristicDataResult != null)
            {
                if (parameterSpeedCharacteristicDataResult.Success)
                {
                    var parameterSpeedCharacteristic = parameterSpeedCharacteristicDataResult.Data;
                    parameterSpeedCharacteristic.IsActive = false;
                    await _parameterSpeedCharacteristicDal.Update(parameterSpeedCharacteristic);
                    return new SuccessResult(ParameterSpeedCharacteristicMessages.Deleted);
                }
            }
            return new ErrorResult(ParameterSpeedCharacteristicMessages.OperationFailed);
        }

        [SecurityAspect("ParameterSpeedCharacteristic.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<ParameterSpeedCharacteristic>>> GetAll()
        {
            var parameterSpeedCharacteristics = await _parameterSpeedCharacteristicDal.GetList(x => x.IsActive == true);
            parameterSpeedCharacteristics = parameterSpeedCharacteristics.OrderBy(x => x.Optime).ToList();
            return new SuccessDataResult<List<ParameterSpeedCharacteristic>>(parameterSpeedCharacteristics);
        }

        [SecurityAspect("ParameterSpeedCharacteristic.GetById", Priority = 2)]
        public async Task<IDataResult<ParameterSpeedCharacteristic>> GetById(Guid id)
        {
            return new SuccessDataResult<ParameterSpeedCharacteristic>(await _parameterSpeedCharacteristicDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("ParameterSpeedCharacteristic.Search", Priority = 2)]
        public async Task<IDataResult<List<ParameterSpeedCharacteristic>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<ParameterSpeedCharacteristic>>(await _parameterSpeedCharacteristicDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("ParameterSpeedCharacteristic.Update", Priority = 2)]
        [ValidationAspect(typeof(ParameterSpeedCharacteristicValidator), Priority = 3)]
        [CacheRemoveAspect("IParameterSpeedCharacteristicService.Get", Priority = 4)]
        public async Task<IResult> Update(ParameterSpeedCharacteristic parameterSpeedCharacteristic)
        {
            await _parameterSpeedCharacteristicDal.Update(parameterSpeedCharacteristic);
            return new SuccessResult(ParameterSpeedCharacteristicMessages.Updated);
        }
    }
}
