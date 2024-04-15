using Business.Abstract.PSI.Types;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages.PSI.Types;
using Business.Validators.FluentValidators.PSI.Types.PSITypeProcessInstructionsValidators;
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
    public class PSITypeProcessInstructionsManager : IPSITypeProcessInstructionsService
    {
        private IPSITypeProcessInstructionsDal _psiTypeProcessInstructionsDal;
        public PSITypeProcessInstructionsManager(IPSITypeProcessInstructionsDal psiTypeProcessInstructionsDal)
        {
            _psiTypeProcessInstructionsDal = psiTypeProcessInstructionsDal;
        }

        [SecurityAspect("PSITypeProcessInstructions.Add", Priority = 2)]
        [ValidationAspect(typeof(PSITypeProcessInstructionsValidator), Priority = 3)]
        [CacheRemoveAspect("IPSITypeProcessInstructionsService.Get", Priority = 4)]
        public async Task<IResult> Add(PSITypeProcessInstructions psiTypeProcessInstructions)
        {
            await _psiTypeProcessInstructionsDal.Add(psiTypeProcessInstructions);
            return new SuccessResult(PSITypeProcessInstructionsMessages.Added);
        }

        [SecurityAspect("PSITypeProcessInstructions.Delete", Priority = 2)]
        [CacheRemoveAspect("IPSITypeProcessInstructionsService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var psiTypeProcessInstructionsDataResult = await GetById(id);
            if (psiTypeProcessInstructionsDataResult != null)
            {
                if (psiTypeProcessInstructionsDataResult.Success)
                {
                    var psiTypeProcessInstructions = psiTypeProcessInstructionsDataResult.Data;
                    psiTypeProcessInstructions.IsActive = false;
                    await _psiTypeProcessInstructionsDal.Update(psiTypeProcessInstructions);
                    return new SuccessResult(PSITypeProcessInstructionsMessages.Deleted);
                }
            }
            return new ErrorResult(PSITypeProcessInstructionsMessages.OperationFailed);
        }

        [SecurityAspect("PSITypeProcessInstructions.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<PSITypeProcessInstructions>>> GetAll()
        {
            var psiTypeProcessInstructionss = await _psiTypeProcessInstructionsDal.GetList(x => x.IsActive == true);
            psiTypeProcessInstructionss = psiTypeProcessInstructionss.OrderBy(x => x.Optime).ToList();
            return new SuccessDataResult<List<PSITypeProcessInstructions>>(psiTypeProcessInstructionss);
        }

        [SecurityAspect("PSITypeProcessInstructions.GetById", Priority = 2)]
        public async Task<IDataResult<PSITypeProcessInstructions>> GetById(Guid id)
        {
            return new SuccessDataResult<PSITypeProcessInstructions>(await _psiTypeProcessInstructionsDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("PSITypeProcessInstructions.Search", Priority = 2)]
        public async Task<IDataResult<List<PSITypeProcessInstructions>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<PSITypeProcessInstructions>>(await _psiTypeProcessInstructionsDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("PSITypeProcessInstructions.Update", Priority = 2)]
        [ValidationAspect(typeof(PSITypeProcessInstructionsValidator), Priority = 3)]
        [CacheRemoveAspect("IPSITypeProcessInstructionsService.Get", Priority = 4)]
        public async Task<IResult> Update(PSITypeProcessInstructions psiTypeProcessInstructions)
        {
            await _psiTypeProcessInstructionsDal.Update(psiTypeProcessInstructions);
            return new SuccessResult(PSITypeProcessInstructionsMessages.Updated);
        }
    }
}
