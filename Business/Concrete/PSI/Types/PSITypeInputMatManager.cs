using Business.Abstract.PSI.Types;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages.PSI.Types;
using Business.Validators.FluentValidators.PSI.Types.PSITypeInputMatValidators;
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
    public class PSITypeInputMatManager : IPSITypeInputMatService
    {
        private IPSITypeInputMatDal _psiTypeInputMatDal;
        public PSITypeInputMatManager(IPSITypeInputMatDal psiTypeInputMatDal)
        {
            _psiTypeInputMatDal = psiTypeInputMatDal;
        }

        [SecurityAspect("PSITypeInputMat.Add", Priority = 2)]
        [ValidationAspect(typeof(PSITypeInputMatValidator), Priority = 3)]
        [CacheRemoveAspect("IPSITypeInputMatService.Get", Priority = 4)]
        public async Task<IResult> Add(PSITypeInputMat psiTypeInputMat)
        {
            await _psiTypeInputMatDal.Add(psiTypeInputMat);
            return new SuccessResult(PSITypeInputMatMessages.Added);
        }

        [SecurityAspect("PSITypeInputMat.Delete", Priority = 2)]
        [CacheRemoveAspect("IPSITypeInputMatService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var psiTypeInputMatDataResult = await GetById(id);
            if (psiTypeInputMatDataResult != null)
            {
                if (psiTypeInputMatDataResult.Success)
                {
                    var psiTypeInputMat = psiTypeInputMatDataResult.Data;
                    psiTypeInputMat.IsActive = false;
                    await _psiTypeInputMatDal.Update(psiTypeInputMat);
                    return new SuccessResult(PSITypeInputMatMessages.Deleted);
                }
            }
            return new ErrorResult(PSITypeInputMatMessages.OperationFailed);
        }

        [SecurityAspect("PSITypeInputMat.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<PSITypeInputMat>>> GetAll()
        {
            var psiTypeInputMats = await _psiTypeInputMatDal.GetList(x => x.IsActive == true);
            psiTypeInputMats = psiTypeInputMats.OrderBy(x => x.Optime).ToList();
            return new SuccessDataResult<List<PSITypeInputMat>>(psiTypeInputMats);
        }

        [SecurityAspect("PSITypeInputMat.GetById", Priority = 2)]
        public async Task<IDataResult<PSITypeInputMat>> GetById(Guid id)
        {
            return new SuccessDataResult<PSITypeInputMat>(await _psiTypeInputMatDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("PSITypeInputMat.Search", Priority = 2)]
        public async Task<IDataResult<List<PSITypeInputMat>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<PSITypeInputMat>>(await _psiTypeInputMatDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("PSITypeInputMat.Update", Priority = 2)]
        [ValidationAspect(typeof(PSITypeInputMatValidator), Priority = 3)]
        [CacheRemoveAspect("IPSITypeInputMatService.Get", Priority = 4)]
        public async Task<IResult> Update(PSITypeInputMat psiTypeInputMat)
        {
            await _psiTypeInputMatDal.Update(psiTypeInputMat);
            return new SuccessResult(PSITypeInputMatMessages.Updated);
        }
    }
}
