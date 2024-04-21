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
    public class SlitPatternDetailManager : ISlitPatternDetailService
    {
        private ISlitPatternDetailDal _slitPatternDetailDal;
        public SlitPatternDetailManager(ISlitPatternDetailDal slitPatternDetailDal)
        {
            _slitPatternDetailDal = slitPatternDetailDal;
        }

        [SecurityAspect("SlitPatternDetail.Add", Priority = 2)]
        [ValidationAspect(typeof(SlitPatternDetailValidator), Priority = 3)]
        [CacheRemoveAspect("ISlitPatternDetailService.Get", Priority = 4)]
        public async Task<IResult> Add(SlitPatternDetail slitPatternDetail)
        {
            await _slitPatternDetailDal.Add(slitPatternDetail);
            return new SuccessResult(SlitPatternDetailMessages.Added);
        }

        [SecurityAspect("SlitPatternDetail.Delete", Priority = 2)]
        [CacheRemoveAspect("ISlitPatternDetailService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var slitPatternDetailDataResult = await GetById(id);
            if (slitPatternDetailDataResult != null)
            {
                if (slitPatternDetailDataResult.Success)
                {
                    var slitPatternDetail = slitPatternDetailDataResult.Data;
                    slitPatternDetail.IsActive = false;
                    await _slitPatternDetailDal.Update(slitPatternDetail);
                    return new SuccessResult(SlitPatternDetailMessages.Deleted);
                }
            }
            return new ErrorResult(SlitPatternDetailMessages.OperationFailed);
        }

        [SecurityAspect("SlitPatternDetail.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<SlitPatternDetail>>> GetAll()
        {
            var slitPatternDetails = await _slitPatternDetailDal.GetList(x => x.IsActive == true);
            slitPatternDetails = slitPatternDetails.OrderBy(x => x.Optime).ToList();
            return new SuccessDataResult<List<SlitPatternDetail>>(slitPatternDetails);
        }

        [SecurityAspect("SlitPatternDetail.GetById", Priority = 2)]
        public async Task<IDataResult<SlitPatternDetail>> GetById(Guid id)
        {
            return new SuccessDataResult<SlitPatternDetail>(await _slitPatternDetailDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("SlitPatternDetail.Search", Priority = 2)]
        public async Task<IDataResult<List<SlitPatternDetail>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<SlitPatternDetail>>(await _slitPatternDetailDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("SlitPatternDetail.Update", Priority = 2)]
        [ValidationAspect(typeof(SlitPatternDetailValidator), Priority = 3)]
        [CacheRemoveAspect("ISlitPatternDetailService.Get", Priority = 4)]
        public async Task<IResult> Update(SlitPatternDetail slitPatternDetail)
        {
            await _slitPatternDetailDal.Update(slitPatternDetail);
            return new SuccessResult(SlitPatternDetailMessages.Updated);
        }
    }
}
