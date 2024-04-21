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
    public class ParameterRewinderManager : IParameterRewinderService
    {
        private IParameterRewinderDal _parameterRewinderDal;
        public ParameterRewinderManager(IParameterRewinderDal parameterRewinderDal)
        {
            _parameterRewinderDal = parameterRewinderDal;
        }

        [SecurityAspect("ParameterRewinder.Add", Priority = 2)]
        [ValidationAspect(typeof(ParameterRewinderValidator), Priority = 3)]
        [CacheRemoveAspect("IParameterRewinderService.Get", Priority = 4)]
        public async Task<IResult> Add(ParameterRewinder parameterRewinder)
        {
            await _parameterRewinderDal.Add(parameterRewinder);
            return new SuccessResult(ParameterRewinderMessages.Added);
        }

        [SecurityAspect("ParameterRewinder.Delete", Priority = 2)]
        [CacheRemoveAspect("IParameterRewinderService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var parameterRewinderDataResult = await GetById(id);
            if (parameterRewinderDataResult != null)
            {
                if (parameterRewinderDataResult.Success)
                {
                    var parameterRewinder = parameterRewinderDataResult.Data;
                    parameterRewinder.IsActive = false;
                    await _parameterRewinderDal.Update(parameterRewinder);
                    return new SuccessResult(ParameterRewinderMessages.Deleted);
                }
            }
            return new ErrorResult(ParameterRewinderMessages.OperationFailed);
        }

        [SecurityAspect("ParameterRewinder.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<ParameterRewinder>>> GetAll()
        {
            var parameterRewinders = await _parameterRewinderDal.GetList(x => x.IsActive == true);
            parameterRewinders = parameterRewinders.OrderBy(x => x.Optime).ToList();
            return new SuccessDataResult<List<ParameterRewinder>>(parameterRewinders);
        }

        [SecurityAspect("ParameterRewinder.GetById", Priority = 2)]
        public async Task<IDataResult<ParameterRewinder>> GetById(Guid id)
        {
            return new SuccessDataResult<ParameterRewinder>(await _parameterRewinderDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("ParameterRewinder.Search", Priority = 2)]
        public async Task<IDataResult<List<ParameterRewinder>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<ParameterRewinder>>(await _parameterRewinderDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("ParameterRewinder.Update", Priority = 2)]
        [ValidationAspect(typeof(ParameterRewinderValidator), Priority = 3)]
        [CacheRemoveAspect("IParameterRewinderService.Get", Priority = 4)]
        public async Task<IResult> Update(ParameterRewinder parameterRewinder)
        {
            await _parameterRewinderDal.Update(parameterRewinder);
            return new SuccessResult(ParameterRewinderMessages.Updated);
        }
    }
}
