using Business.Abstract.PSI.Types;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages.PSI.Types;
using Business.Validators.FluentValidators.PSI.Types.PSITypeOutputMatTargetValidators;
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
    public class PSITypeOutputMatTargetManager : IPSITypeOutputMatTargetService
    {
        private IPSITypeOutputMatTargetDal _psiTypeOutputMatTargetDal;
        public PSITypeOutputMatTargetManager(IPSITypeOutputMatTargetDal psiTypeOutputMatTargetDal)
        {
            _psiTypeOutputMatTargetDal = psiTypeOutputMatTargetDal;
        }

        [SecurityAspect("PSITypeOutputMatTarget.Add", Priority = 2)]
        [ValidationAspect(typeof(PSITypeOutputMatTargetValidator), Priority = 3)]
        [CacheRemoveAspect("IPSITypeOutputMatTargetService.Get", Priority = 4)]
        public async Task<IResult> Add(PSITypeOutputMatTarget psiTypeOutputMatTarget)
        {
            await _psiTypeOutputMatTargetDal.Add(psiTypeOutputMatTarget);
            return new SuccessResult(PSITypeOutputMatTargetMessages.Added);
        }

        [SecurityAspect("PSITypeOutputMatTarget.Delete", Priority = 2)]
        [CacheRemoveAspect("IPSITypeOutputMatTargetService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var psiTypeOutputMatTargetDataResult = await GetById(id);
            if (psiTypeOutputMatTargetDataResult != null)
            {
                if (psiTypeOutputMatTargetDataResult.Success)
                {
                    var psiTypeOutputMatTarget = psiTypeOutputMatTargetDataResult.Data;
                    psiTypeOutputMatTarget.IsActive = false;
                    await _psiTypeOutputMatTargetDal.Update(psiTypeOutputMatTarget);
                    return new SuccessResult(PSITypeOutputMatTargetMessages.Deleted);
                }
            }
            return new ErrorResult(PSITypeOutputMatTargetMessages.OperationFailed);
        }

        [SecurityAspect("PSITypeOutputMatTarget.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<PSITypeOutputMatTarget>>> GetAll()
        {
            var psiTypeOutputMatTargets = await _psiTypeOutputMatTargetDal.GetList(x => x.IsActive == true);
            psiTypeOutputMatTargets = psiTypeOutputMatTargets.OrderBy(x => x.Optime).ToList();
            return new SuccessDataResult<List<PSITypeOutputMatTarget>>(psiTypeOutputMatTargets);
        }

        [SecurityAspect("PSITypeOutputMatTarget.GetById", Priority = 2)]
        public async Task<IDataResult<PSITypeOutputMatTarget>> GetById(Guid id)
        {
            return new SuccessDataResult<PSITypeOutputMatTarget>(await _psiTypeOutputMatTargetDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("PSITypeOutputMatTarget.Search", Priority = 2)]
        public async Task<IDataResult<List<PSITypeOutputMatTarget>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<PSITypeOutputMatTarget>>(await _psiTypeOutputMatTargetDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("PSITypeOutputMatTarget.Update", Priority = 2)]
        [ValidationAspect(typeof(PSITypeOutputMatTargetValidator), Priority = 3)]
        [CacheRemoveAspect("IPSITypeOutputMatTargetService.Get", Priority = 4)]
        public async Task<IResult> Update(PSITypeOutputMatTarget psiTypeOutputMatTarget)
        {
            await _psiTypeOutputMatTargetDal.Update(psiTypeOutputMatTarget);
            return new SuccessResult(PSITypeOutputMatTargetMessages.Updated);
        }
    }
}
