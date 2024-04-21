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
    public class ParameterRewinderTwoPressureManager : IParameterRewinderTwoPressureService
    {
        private IParameterRewinderTwoPressureDal _parameterRewinderTwoPressureDal;
        public ParameterRewinderTwoPressureManager(IParameterRewinderTwoPressureDal parameterRewinderTwoPressureDal)
        {
            _parameterRewinderTwoPressureDal = parameterRewinderTwoPressureDal;
        }

        [SecurityAspect("ParameterRewinderTwoPressure.Add", Priority = 2)]
        [ValidationAspect(typeof(ParameterRewinderTwoPressureValidator), Priority = 3)]
        [CacheRemoveAspect("IParameterRewinderTwoPressureService.Get", Priority = 4)]
        public async Task<IResult> Add(ParameterRewinderTwoPressure parameterRewinderTwoPressure)
        {
            await _parameterRewinderTwoPressureDal.Add(parameterRewinderTwoPressure);
            return new SuccessResult(ParameterRewinderTwoPressureMessages.Added);
        }

        [SecurityAspect("ParameterRewinderTwoPressure.Delete", Priority = 2)]
        [CacheRemoveAspect("IParameterRewinderTwoPressureService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var parameterRewinderTwoPressureDataResult = await GetById(id);
            if (parameterRewinderTwoPressureDataResult != null)
            {
                if (parameterRewinderTwoPressureDataResult.Success)
                {
                    var parameterRewinderTwoPressure = parameterRewinderTwoPressureDataResult.Data;
                    parameterRewinderTwoPressure.IsActive = false;
                    await _parameterRewinderTwoPressureDal.Update(parameterRewinderTwoPressure);
                    return new SuccessResult(ParameterRewinderTwoPressureMessages.Deleted);
                }
            }
            return new ErrorResult(ParameterRewinderTwoPressureMessages.OperationFailed);
        }

        [SecurityAspect("ParameterRewinderTwoPressure.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<ParameterRewinderTwoPressure>>> GetAll()
        {
            var parameterRewinderTwoPressures = await _parameterRewinderTwoPressureDal.GetList(x => x.IsActive == true);
            parameterRewinderTwoPressures = parameterRewinderTwoPressures.OrderBy(x => x.Optime).ToList();
            return new SuccessDataResult<List<ParameterRewinderTwoPressure>>(parameterRewinderTwoPressures);
        }

        [SecurityAspect("ParameterRewinderTwoPressure.GetById", Priority = 2)]
        public async Task<IDataResult<ParameterRewinderTwoPressure>> GetById(Guid id)
        {
            return new SuccessDataResult<ParameterRewinderTwoPressure>(await _parameterRewinderTwoPressureDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("ParameterRewinderTwoPressure.Search", Priority = 2)]
        public async Task<IDataResult<List<ParameterRewinderTwoPressure>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<ParameterRewinderTwoPressure>>(await _parameterRewinderTwoPressureDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("ParameterRewinderTwoPressure.Update", Priority = 2)]
        [ValidationAspect(typeof(ParameterRewinderTwoPressureValidator), Priority = 3)]
        [CacheRemoveAspect("IParameterRewinderTwoPressureService.Get", Priority = 4)]
        public async Task<IResult> Update(ParameterRewinderTwoPressure parameterRewinderTwoPressure)
        {
            await _parameterRewinderTwoPressureDal.Update(parameterRewinderTwoPressure);
            return new SuccessResult(ParameterRewinderTwoPressureMessages.Updated);
        }
    }
}
