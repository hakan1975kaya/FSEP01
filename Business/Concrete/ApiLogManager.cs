using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages;
using Business.Validators.FluentValidators.ApiLogValidators;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Dtos.Genaral;
using Entities.Concrete.Entities.WEB;
using log4net;

namespace Business.Concrete
{
    [LogAspect(typeof(DatabaseLogger), Priority = 1)]
    public class ApiLogManager : IApiLogService
    {
        private IApiLogDal _apiLogDal;
        public ApiLogManager(IApiLogDal apiLogDal)
        {
            _apiLogDal = apiLogDal;
        }

        [SecurityAspect("ApiLog.Add", Priority = 2)]
        [ValidationAspect(typeof(ApiLogValidator), Priority = 3)]
        [CacheRemoveAspect("IApiLogService.Get", Priority = 4)]
        public async Task<IResult> Add(ApiLog apiLog)
        {
            await _apiLogDal.Add(apiLog);
            return new SuccessResult(ApiLogMessages.Added);
        }

        [SecurityAspect("ApiLog.Delete", Priority = 2)]
        [CacheRemoveAspect("IApiLogService.Get", Priority = 4)]
        public async Task<IResult> Delete(Guid id)
        {
            var apiLogDataResult = await GetById(id);
            if (apiLogDataResult != null)
            {
                if (apiLogDataResult.Success)
                {
                    var apiLog = apiLogDataResult.Data;
                    await _apiLogDal.Delete(apiLog);
                    return new SuccessResult(ApiLogMessages.Deleted);
                }
            }
            return new ErrorResult(ApiLogMessages.OperationFailed);
        }

        [SecurityAspect("ApiLog.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<ApiLog>>> GetAll()
        {
            return new SuccessDataResult<List<ApiLog>>(await _apiLogDal.GetList());
        }

        [SecurityAspect("ApiLog.GetById", Priority = 2)]
        public async Task<IDataResult<ApiLog>> GetById(Guid id)
        {
            return new SuccessDataResult<ApiLog>(await _apiLogDal.Get(x => x.Id == id));
        }

        [SecurityAspect("ApiLog.Search", Priority = 2)]
        public async Task<IDataResult<List<ApiLog>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<ApiLog>>(await _apiLogDal.GetList( x => filterDto.Filter.Contains(x.Audit.ToString()) || filterDto.Filter.Contains(x.Date.ToString()) || filterDto.Filter.Contains(x.Detail)));
        }

        [SecurityAspect("ApiLog.Update", Priority = 2)]
        [ValidationAspect(typeof(ApiLogValidator), Priority = 3)]
        [CacheRemoveAspect("IApiLogService.Get", Priority = 4)]
        public async Task<IResult> Update(ApiLog apiLog)
        {
            await _apiLogDal.Update(apiLog);
            return new SuccessResult(ApiLogMessages.Updated);
        }
    }
}
