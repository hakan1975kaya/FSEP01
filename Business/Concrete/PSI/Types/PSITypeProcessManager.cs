using Business.Abstract.PSI.Types;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages.PSI.Types;
using Business.Validators.FluentValidators.PSI.Types.PSITypeProcessValidators;
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
    public class PSITypeProcessManager : IPSITypeProcessService
    {
        private IPSITypeProcessDal _psiTypeProcessDal;
        public PSITypeProcessManager(IPSITypeProcessDal psiTypeProcessDal)
        {
            _psiTypeProcessDal = psiTypeProcessDal;
        }

        [SecurityAspect("PSITypeProcess.Add", Priority = 2)]
        [ValidationAspect(typeof(PSITypeProcessValidator), Priority = 3)]
        [CacheRemoveAspect("IPSITypeProcessService.Get", Priority = 4)]
        public async Task<IResult> Add(PSITypeProcess psiTypeProcess)
        {
            await _psiTypeProcessDal.Add(psiTypeProcess);
            return new SuccessResult(PSITypeProcessMessages.Added);
        }

        [SecurityAspect("PSITypeProcess.Delete", Priority = 2)]
        [CacheRemoveAspect("IPSITypeProcessService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var psiTypeProcessDataResult = await GetById(id);
            if (psiTypeProcessDataResult != null)
            {
                if (psiTypeProcessDataResult.Success)
                {
                    var psiTypeProcess = psiTypeProcessDataResult.Data;
                    psiTypeProcess.IsActive = false;
                    await _psiTypeProcessDal.Update(psiTypeProcess);
                    return new SuccessResult(PSITypeProcessMessages.Deleted);
                }
            }
            return new ErrorResult(PSITypeProcessMessages.OperationFailed);
        }

        [SecurityAspect("PSITypeProcess.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<PSITypeProcess>>> GetAll()
        {
            var psiTypeProcesss = await _psiTypeProcessDal.GetList(x => x.IsActive == true);
            psiTypeProcesss = psiTypeProcesss.OrderBy(x => x.Optime).ToList();
            return new SuccessDataResult<List<PSITypeProcess>>(psiTypeProcesss);
        }

        [SecurityAspect("PSITypeProcess.GetById", Priority = 2)]
        public async Task<IDataResult<PSITypeProcess>> GetById(Guid id)
        {
            return new SuccessDataResult<PSITypeProcess>(await _psiTypeProcessDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("PSITypeProcess.Search", Priority = 2)]
        public async Task<IDataResult<List<PSITypeProcess>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<PSITypeProcess>>(await _psiTypeProcessDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("PSITypeProcess.Update", Priority = 2)]
        [ValidationAspect(typeof(PSITypeProcessValidator), Priority = 3)]
        [CacheRemoveAspect("IPSITypeProcessService.Get", Priority = 4)]
        public async Task<IResult> Update(PSITypeProcess psiTypeProcess)
        {
            await _psiTypeProcessDal.Update(psiTypeProcess);
            return new SuccessResult(PSITypeProcessMessages.Updated);
        }
    }
}
