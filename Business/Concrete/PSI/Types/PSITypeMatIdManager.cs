using Business.Abstract.PSI.Types;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages.PSI.Types;
using Business.Validators.FluentValidators.PSI.Types.PSITypeMatIdValidators;
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
    public class PSITypeMatIdManager : IPSITypeMatIdService
    {
        private IPSITypeMatIdDal _psiTypeMatIdDal;
        public PSITypeMatIdManager(IPSITypeMatIdDal psiTypeMatIdDal)
        {
            _psiTypeMatIdDal = psiTypeMatIdDal;
        }

        [SecurityAspect("PSITypeMatId.Add", Priority = 2)]
        [ValidationAspect(typeof(PSITypeMatIdValidator), Priority = 3)]
        [CacheRemoveAspect("IPSITypeMatIdService.Get", Priority = 4)]
        public async Task<IResult> Add(PSITypeMatId psiTypeMatId)
        {
            await _psiTypeMatIdDal.Add(psiTypeMatId);
            return new SuccessResult(PSITypeMatIdMessages.Added);
        }

        [SecurityAspect("PSITypeMatId.Delete", Priority = 2)]
        [CacheRemoveAspect("IPSITypeMatIdService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var psiTypeMatIdDataResult = await GetById(id);
            if (psiTypeMatIdDataResult != null)
            {
                if (psiTypeMatIdDataResult.Success)
                {
                    var psiTypeMatId = psiTypeMatIdDataResult.Data;
                    psiTypeMatId.IsActive = false;
                    await _psiTypeMatIdDal.Update(psiTypeMatId);
                    return new SuccessResult(PSITypeMatIdMessages.Deleted);
                }
            }
            return new ErrorResult(PSITypeMatIdMessages.OperationFailed);
        }

        [SecurityAspect("PSITypeMatId.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<PSITypeMatId>>> GetAll()
        {
            var psiTypeMatIds = await _psiTypeMatIdDal.GetList(x => x.IsActive == true);
            psiTypeMatIds = psiTypeMatIds.OrderBy(x => x.Optime).ToList();
            return new SuccessDataResult<List<PSITypeMatId>>(psiTypeMatIds);
        }

        [SecurityAspect("PSITypeMatId.GetById", Priority = 2)]
        public async Task<IDataResult<PSITypeMatId>> GetById(Guid id)
        {
            return new SuccessDataResult<PSITypeMatId>(await _psiTypeMatIdDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("PSITypeMatId.Search", Priority = 2)]
        public async Task<IDataResult<List<PSITypeMatId>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<PSITypeMatId>>(await _psiTypeMatIdDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("PSITypeMatId.Update", Priority = 2)]
        [ValidationAspect(typeof(PSITypeMatIdValidator), Priority = 3)]
        [CacheRemoveAspect("IPSITypeMatIdService.Get", Priority = 4)]
        public async Task<IResult> Update(PSITypeMatId psiTypeMatId)
        {
            await _psiTypeMatIdDal.Update(psiTypeMatId);
            return new SuccessResult(PSITypeMatIdMessages.Updated);
        }
    }
}
