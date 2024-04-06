using Business.Abstract.General;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages;
using Business.Validators.FluentValidators.WebLogValidators;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract.General;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General;

namespace Business.Concrete
{
    [LogAspect(typeof(DatabaseLogger), Priority = 1)]
    public class WebLogManager : IWebLogService
    {
        private IWebLogDal _webLogDal;
        public WebLogManager(IWebLogDal webLogDal)
        {
            _webLogDal = webLogDal;
        }

        [SecurityAspect("WebLog.Add", Priority = 2)]
        [ValidationAspect(typeof(WebLogValidator),Priority =3)]
        [CacheRemoveAspect("IWebLogService.Get", Priority = 4)]
        public async Task<IResult> Add(WebLog webLog)
        {
            await _webLogDal.Add(webLog);
            return new SuccessResult(WebLogMessages.Added);
        }

        [SecurityAspect("WebLog.Delete", Priority =2)]
        [CacheRemoveAspect("IWebLogService.Get", Priority = 4)]
        public async Task<IResult> Delete(Guid id)
        {
            var webLogDataResult = await GetById(id);
            if (webLogDataResult != null)
            {
                if (webLogDataResult.Success)
                {
                    var webLog = webLogDataResult.Data;
                    await _webLogDal.Delete(webLog);
                    return new SuccessResult(WebLogMessages.Deleted);
                }
            }
            return new ErrorResult(WebLogMessages.OperationFailed);
        }

        [SecurityAspect("WebLog.GetAll", Priority = 2)]
        [CacheAspect(Priority =3)]
        public async Task<IDataResult<List<WebLog>>> GetAll()
        {
            return new SuccessDataResult<List<WebLog>>(await _webLogDal.GetList());
        }

        [SecurityAspect("WebLog.GetById", Priority = 2)]
        public async Task<IDataResult<WebLog>> GetById(Guid id)
        {
            return new SuccessDataResult<WebLog>(await _webLogDal.Get(x => x.Id == id));
        }

        [SecurityAspect("WebLog.Search", Priority = 2)]
        public async Task<IDataResult<List<WebLog>>> Search(FilterDto filterDto)
        {
           return new SuccessDataResult<List<WebLog>>(await _webLogDal.GetList(x=>filterDto.Filter.Contains(x.Audit.ToString())|| filterDto.Filter.Contains(x.Detail)|| filterDto.Filter.Contains(x.Date.ToString())));
        }

        [SecurityAspect("WebLog.Update", Priority = 2)]
        [ValidationAspect(typeof(WebLogValidator), Priority = 3)]
        [CacheRemoveAspect("IWebLogService.Get", Priority = 4)]
        public async Task<IResult> Update(WebLog webLog)
        {
            await _webLogDal.Update(webLog);
            return new SuccessResult(WebLogMessages.Updated);
        }
    }
}
