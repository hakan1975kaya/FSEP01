using Business.Abstract.PSI.Types;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages.PSI.Types;
using Business.Validators.FluentValidators.PSI.Types.PSITypeOutputMatValidators;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract.PSI.Types;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.PSI.Types;


namespace Business.Concrete.PSI.Telegrams
{
    [LogAspect(typeof(DatabaseLogger), Priority = 1)]
    public class PSITypeOutputMatManager : IPSITypeOutputMatService
    {
        private IPSITypeOutputMatDal _psiTypeOutputMatDal;
        public PSITypeOutputMatManager(IPSITypeOutputMatDal psiTypeOutputMatDal)
        {
            _psiTypeOutputMatDal = psiTypeOutputMatDal;
        }

        [SecurityAspect("PSITypeOutputMat.Add", Priority = 2)]
        [ValidationAspect(typeof(PSITypeOutputMatValidator), Priority = 3)]
        [CacheRemoveAspect("IPSITypeOutputMatService.Get", Priority = 4)]
        public async Task<IResult> Add(PSITypeOutputMat psiTypeOutputMat)
        {
            await _psiTypeOutputMatDal.Add(psiTypeOutputMat);
            return new SuccessResult(PSITypeOutputMatMessages.Added);
        }

        [SecurityAspect("PSITypeOutputMat.Delete", Priority = 2)]
        [CacheRemoveAspect("IPSITypeOutputMatService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var psiTypeOutputMatDataResult = await GetById(id);
            if (psiTypeOutputMatDataResult != null)
            {
                if (psiTypeOutputMatDataResult.Success)
                {
                    var psiTypeOutputMat = psiTypeOutputMatDataResult.Data;
                    psiTypeOutputMat.IsActive = false;
                    await _psiTypeOutputMatDal.Update(psiTypeOutputMat);
                    return new SuccessResult(PSITypeOutputMatMessages.Deleted);
                }
            }
            return new ErrorResult(PSITypeOutputMatMessages.OperationFailed);
        }

        [SecurityAspect("PSITypeOutputMat.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<PSITypeOutputMat>>> GetAll()
        {
            var psiTypeOutputMats = await _psiTypeOutputMatDal.GetList(x => x.IsActive == true);
            psiTypeOutputMats = psiTypeOutputMats.OrderBy(x => x.Optime).ToList();
            return new SuccessDataResult<List<PSITypeOutputMat>>(psiTypeOutputMats);
        }

        [SecurityAspect("PSITypeOutputMat.GetById", Priority = 2)]
        public async Task<IDataResult<PSITypeOutputMat>> GetById(Guid id)
        {
            return new SuccessDataResult<PSITypeOutputMat>(await _psiTypeOutputMatDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("PSITypeOutputMat.Search", Priority = 2)]
        public async Task<IDataResult<List<PSITypeOutputMat>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<PSITypeOutputMat>>(await _psiTypeOutputMatDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("PSITypeOutputMat.Update", Priority = 2)]
        [ValidationAspect(typeof(PSITypeOutputMatValidator), Priority = 3)]
        [CacheRemoveAspect("IPSITypeOutputMatService.Get", Priority = 4)]
        public async Task<IResult> Update(PSITypeOutputMat psiTypeOutputMat)
        {
            await _psiTypeOutputMatDal.Update(psiTypeOutputMat);
            return new SuccessResult(PSITypeOutputMatMessages.Updated);
        }
    }
}
