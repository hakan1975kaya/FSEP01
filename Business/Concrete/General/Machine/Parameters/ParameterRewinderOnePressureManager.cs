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
    public class ParameterRewinderOnePressureManager : IParameterRewinderOnePressureService
    {
        private IParameterRewinderOnePressureDal _parameterRewinderOnePressureDal;
        public ParameterRewinderOnePressureManager(IParameterRewinderOnePressureDal parameterRewinderOnePressureDal)
        {
            _parameterRewinderOnePressureDal = parameterRewinderOnePressureDal;
        }

        [SecurityAspect("ParameterRewinderOnePressure.Add", Priority = 2)]
        [ValidationAspect(typeof(ParameterRewinderOnePressureValidator), Priority = 3)]
        [CacheRemoveAspect("IParameterRewinderOnePressureService.Get", Priority = 4)]
        public async Task<IResult> Add(ParameterRewinderOnePressure parameterRewinderOnePressure)
        {
            await _parameterRewinderOnePressureDal.Add(parameterRewinderOnePressure);
            return new SuccessResult(ParameterRewinderOnePressureMessages.Added);
        }

        [SecurityAspect("ParameterRewinderOnePressure.Delete", Priority = 2)]
        [CacheRemoveAspect("IParameterRewinderOnePressureService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var parameterRewinderOnePressureDataResult = await GetById(id);
            if (parameterRewinderOnePressureDataResult != null)
            {
                if (parameterRewinderOnePressureDataResult.Success)
                {
                    var parameterRewinderOnePressure = parameterRewinderOnePressureDataResult.Data;
                    parameterRewinderOnePressure.IsActive = false;
                    await _parameterRewinderOnePressureDal.Update(parameterRewinderOnePressure);
                    return new SuccessResult(ParameterRewinderOnePressureMessages.Deleted);
                }
            }
            return new ErrorResult(ParameterRewinderOnePressureMessages.OperationFailed);
        }

        [SecurityAspect("ParameterRewinderOnePressure.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<ParameterRewinderOnePressure>>> GetAll()
        {
            var parameterRewinderOnePressures = await _parameterRewinderOnePressureDal.GetList(x => x.IsActive == true);
            parameterRewinderOnePressures = parameterRewinderOnePressures.OrderBy(x => x.Optime).ToList();
            return new SuccessDataResult<List<ParameterRewinderOnePressure>>(parameterRewinderOnePressures);
        }

        [SecurityAspect("ParameterRewinderOnePressure.GetById", Priority = 2)]
        public async Task<IDataResult<ParameterRewinderOnePressure>> GetById(Guid id)
        {
            return new SuccessDataResult<ParameterRewinderOnePressure>(await _parameterRewinderOnePressureDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("ParameterRewinderOnePressure.Search", Priority = 2)]
        public async Task<IDataResult<List<ParameterRewinderOnePressure>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<ParameterRewinderOnePressure>>(await _parameterRewinderOnePressureDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("ParameterRewinderOnePressure.Update", Priority = 2)]
        [ValidationAspect(typeof(ParameterRewinderOnePressureValidator), Priority = 3)]
        [CacheRemoveAspect("IParameterRewinderOnePressureService.Get", Priority = 4)]
        public async Task<IResult> Update(ParameterRewinderOnePressure parameterRewinderOnePressure)
        {
            await _parameterRewinderOnePressureDal.Update(parameterRewinderOnePressure);
            return new SuccessResult(ParameterRewinderOnePressureMessages.Updated);
        }
    }
}
