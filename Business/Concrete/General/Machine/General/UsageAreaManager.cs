using Business.Abstract.General.General;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages.General.Machine.General;
using Business.Validators.FluentValidators.General.General.DemandValidators;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract.General.Machine.General;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.General;

namespace Business.Concrete.General.General
{
    [LogAspect(typeof(DatabaseLogger), Priority = 1)]
    public class UsageAreaManager : IUsageAreaService
    {
        private IUsageAreaDal _usageAreaDal;
        public UsageAreaManager(IUsageAreaDal usageAreaDal)
        {
            _usageAreaDal = usageAreaDal;
        }

        [SecurityAspect("UsageArea.Add", Priority = 2)]
        [ValidationAspect(typeof(UsageAreaValidator), Priority = 3)]
        [CacheRemoveAspect("IUsageAreaService.Get", Priority = 4)]
        public async Task<IResult> Add(UsageArea usageArea)
        {
            await _usageAreaDal.Add(usageArea);
            return new SuccessResult(UsageAreaMessages.Added);
        }

        [SecurityAspect("UsageArea.Delete", Priority = 2)]
        [CacheRemoveAspect("IUsageAreaService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var usageAreaDataResult = await GetById(id);
            if (usageAreaDataResult != null)
            {
                if (usageAreaDataResult.Success)
                {
                    var usageArea = usageAreaDataResult.Data;
                    usageArea.IsActive = false;
                    await _usageAreaDal.Update(usageArea);
                    return new SuccessResult(UsageAreaMessages.Deleted);
                }
            }
            return new ErrorResult(UsageAreaMessages.OperationFailed);
        }

        [SecurityAspect("UsageArea.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<UsageArea>>> GetAll()
        {
            var usageAreas = await _usageAreaDal.GetList(x => x.IsActive == true);
            usageAreas = usageAreas.OrderBy(x => x.Value).ToList();
            return new SuccessDataResult<List<UsageArea>>(usageAreas);
        }

        [SecurityAspect("UsageArea.GetById", Priority = 2)]
        public async Task<IDataResult<UsageArea>> GetById(Guid id)
        {
            return new SuccessDataResult<UsageArea>(await _usageAreaDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("UsageArea.Search", Priority = 2)]
        public async Task<IDataResult<List<UsageArea>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<UsageArea>>(await _usageAreaDal.GetList(x => 
            x.IsActive == true && (x.Optime.ToString().Contains(filterDto.Filter)||
            x.Value.Contains(filterDto.Filter))));
        }

        [SecurityAspect("UsageArea.Update", Priority = 2)]
        [ValidationAspect(typeof(UsageAreaValidator), Priority = 3)]
        [CacheRemoveAspect("IUsageAreaService.Get", Priority = 4)]
        public async Task<IResult> Update(UsageArea usageArea)
        {
            await _usageAreaDal.Update(usageArea);
            return new SuccessResult(UsageAreaMessages.Updated);
        }
    }
}
