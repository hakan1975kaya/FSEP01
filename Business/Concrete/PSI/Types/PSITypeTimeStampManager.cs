using Business.Abstract.PSI.Types;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages.PSI.Types;
using Business.Validators.FluentValidators.PSI.Types.PSITypeTimeStampValidators;
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
    public class PSITypeTimeStampManager : IPSITypeTimeStampService
    {
        private IPSITypeTimeStampDal _psiTypeTimeStampDal;
        public PSITypeTimeStampManager(IPSITypeTimeStampDal psiTypeTimeStampDal)
        {
            _psiTypeTimeStampDal = psiTypeTimeStampDal;
        }

        [SecurityAspect("PSITypeTimeStamp.Add", Priority = 2)]
        [ValidationAspect(typeof(PSITypeTimeStampValidator), Priority = 3)]
        [CacheRemoveAspect("IPSITypeTimeStampService.Get", Priority = 4)]
        public async Task<IResult> Add(PSITypeTimeStamp psiTypeTimeStamp)
        {
            await _psiTypeTimeStampDal.Add(psiTypeTimeStamp);
            return new SuccessResult(PSITypeTimeStampMessages.Added);
        }

        [SecurityAspect("PSITypeTimeStamp.Delete", Priority = 2)]
        [CacheRemoveAspect("IPSITypeTimeStampService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var psiTypeTimeStampDataResult = await GetById(id);
            if (psiTypeTimeStampDataResult != null)
            {
                if (psiTypeTimeStampDataResult.Success)
                {
                    var psiTypeTimeStamp = psiTypeTimeStampDataResult.Data;
                    psiTypeTimeStamp.IsActive = false;
                    await _psiTypeTimeStampDal.Update(psiTypeTimeStamp);
                    return new SuccessResult(PSITypeTimeStampMessages.Deleted);
                }
            }
            return new ErrorResult(PSITypeTimeStampMessages.OperationFailed);
        }

        [SecurityAspect("PSITypeTimeStamp.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<PSITypeTimeStamp>>> GetAll()
        {
            var psiTypeTimeStamps = await _psiTypeTimeStampDal.GetList(x => x.IsActive == true);
            psiTypeTimeStamps = psiTypeTimeStamps.OrderBy(x => x.Optime).ToList();
            return new SuccessDataResult<List<PSITypeTimeStamp>>(psiTypeTimeStamps);
        }

        [SecurityAspect("PSITypeTimeStamp.GetById", Priority = 2)]
        public async Task<IDataResult<PSITypeTimeStamp>> GetById(Guid id)
        {
            return new SuccessDataResult<PSITypeTimeStamp>(await _psiTypeTimeStampDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("PSITypeTimeStamp.Search", Priority = 2)]
        public async Task<IDataResult<List<PSITypeTimeStamp>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<PSITypeTimeStamp>>(await _psiTypeTimeStampDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("PSITypeTimeStamp.Update", Priority = 2)]
        [ValidationAspect(typeof(PSITypeTimeStampValidator), Priority = 3)]
        [CacheRemoveAspect("IPSITypeTimeStampService.Get", Priority = 4)]
        public async Task<IResult> Update(PSITypeTimeStamp psiTypeTimeStamp)
        {
            await _psiTypeTimeStampDal.Update(psiTypeTimeStamp);
            return new SuccessResult(PSITypeTimeStampMessages.Updated);
        }
    }
}
