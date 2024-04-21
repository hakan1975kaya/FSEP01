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
    public class HeadTailScrapManager : IHeadTailScrapService
    {
        private IHeadTailScrapDal _headTailScrapDal;
        public HeadTailScrapManager(IHeadTailScrapDal headTailScrapDal)
        {
            _headTailScrapDal = headTailScrapDal;
        }

        [SecurityAspect("HeadTailScrap.Add", Priority = 2)]
        [ValidationAspect(typeof(HeadTailScrapValidator), Priority = 3)]
        [CacheRemoveAspect("IHeadTailScrapService.Get", Priority = 4)]
        public async Task<IResult> Add(HeadTailScrap headTailScrap)
        {
            await _headTailScrapDal.Add(headTailScrap);
            return new SuccessResult(HeadTailScrapMessages.Added);
        }

        [SecurityAspect("HeadTailScrap.Delete", Priority = 2)]
        [CacheRemoveAspect("IHeadTailScrapService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var headTailScrapDataResult = await GetById(id);
            if (headTailScrapDataResult != null)
            {
                if (headTailScrapDataResult.Success)
                {
                    var headTailScrap = headTailScrapDataResult.Data;
                    headTailScrap.IsActive = false;
                    await _headTailScrapDal.Update(headTailScrap);
                    return new SuccessResult(HeadTailScrapMessages.Deleted);
                }
            }
            return new ErrorResult(HeadTailScrapMessages.OperationFailed);
        }

        [SecurityAspect("HeadTailScrap.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<HeadTailScrap>>> GetAll()
        {
            var HeadTailScraps = await _headTailScrapDal.GetList(x => x.IsActive == true);
            HeadTailScraps = HeadTailScraps.OrderBy(x => x.ScrapValue).ToList();
            return new SuccessDataResult<List<HeadTailScrap>>(HeadTailScraps);
        }

        [SecurityAspect("HeadTailScrap.GetById", Priority = 2)]
        public async Task<IDataResult<HeadTailScrap>> GetById(Guid id)
        {
            return new SuccessDataResult<HeadTailScrap>(await _headTailScrapDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("HeadTailScrap.Search", Priority = 2)]
        public async Task<IDataResult<List<HeadTailScrap>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<HeadTailScrap>>(await _headTailScrapDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("HeadTailScrap.Update", Priority = 2)]
        [ValidationAspect(typeof(HeadTailScrapValidator), Priority = 3)]
        [CacheRemoveAspect("IHeadTailScrapService.Get", Priority = 4)]
        public async Task<IResult> Update(HeadTailScrap headTailScrap)
        {
            await _headTailScrapDal.Update(headTailScrap);
            return new SuccessResult(HeadTailScrapMessages.Updated);
        }
    }
}
