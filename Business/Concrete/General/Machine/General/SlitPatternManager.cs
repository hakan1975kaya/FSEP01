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
    public class SlitPatternManager : ISlitPatternService
    {
        private ISlitPatternDal _slitPatternDal;
        public SlitPatternManager(ISlitPatternDal slitPatternDal)
        {
            _slitPatternDal = slitPatternDal;
        }

        [SecurityAspect("SlitPattern.Add", Priority = 2)]
        [ValidationAspect(typeof(SlitPatternValidator), Priority = 3)]
        [CacheRemoveAspect("ISlitPatternService.Get", Priority = 4)]
        public async Task<IResult> Add(SlitPattern slitPattern)
        {
            await _slitPatternDal.Add(slitPattern);
            return new SuccessResult(SlitPatternMessages.Added);
        }

        [SecurityAspect("SlitPattern.Delete", Priority = 2)]
        [CacheRemoveAspect("ISlitPatternService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var slitPatternDataResult = await GetById(id);
            if (slitPatternDataResult != null)
            {
                if (slitPatternDataResult.Success)
                {
                    var slitPattern = slitPatternDataResult.Data;
                    slitPattern.IsActive = false;
                    await _slitPatternDal.Update(slitPattern);
                    return new SuccessResult(SlitPatternMessages.Deleted);
                }
            }
            return new ErrorResult(SlitPatternMessages.OperationFailed);
        }

        [SecurityAspect("SlitPattern.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<SlitPattern>>> GetAll()
        {
            var slitPatterns = await _slitPatternDal.GetList(x => x.IsActive == true);
            slitPatterns = slitPatterns.OrderBy(x => x.LocalId).ToList();
            return new SuccessDataResult<List<SlitPattern>>(slitPatterns);
        }

        [SecurityAspect("SlitPattern.GetById", Priority = 2)]
        public async Task<IDataResult<SlitPattern>> GetById(Guid id)
        {
            return new SuccessDataResult<SlitPattern>(await _slitPatternDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("SlitPattern.Search", Priority = 2)]
        public async Task<IDataResult<List<SlitPattern>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<SlitPattern>>(await _slitPatternDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("SlitPattern.Update", Priority = 2)]
        [ValidationAspect(typeof(SlitPatternValidator), Priority = 3)]
        [CacheRemoveAspect("ISlitPatternService.Get", Priority = 4)]
        public async Task<IResult> Update(SlitPattern slitPattern)
        {
            await _slitPatternDal.Update(slitPattern);
            return new SuccessResult(SlitPatternMessages.Updated);
        }
    }
}
