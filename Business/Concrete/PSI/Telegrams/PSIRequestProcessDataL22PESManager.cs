using Business.Abstract.PSI.Telegrams;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages.PSI.Telegrams;
using Business.Validators.FluentValidators.PSI.Telegrams.PSIRequestProcessDataL22PESValidators;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract.PSI.Telegrams;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.PSI.Telegrams;

namespace Business.Concrete.PSI.Telegrams
{
    [LogAspect(typeof(DatabaseLogger), Priority = 1)]
    public class PSIRequestProcessDataL22PESManager : IPSIRequestProcessDataL22PESService
    {
        private IPSIRequestProcessDataL22PESDal _psiRequestProcessDataL22PESDal;
        public PSIRequestProcessDataL22PESManager(IPSIRequestProcessDataL22PESDal psiRequestProcessDataL22PESDal)
        {
            _psiRequestProcessDataL22PESDal = psiRequestProcessDataL22PESDal;
        }

        [SecurityAspect("PSIRequestProcessDataL22PES.Add", Priority = 2)]
        [ValidationAspect(typeof(PSIRequestProcessDataL22PESValidator), Priority = 3)]
        [CacheRemoveAspect("IPSIRequestProcessDataL22PESService.Get", Priority = 4)]
        public async Task<IResult> Add(PSIRequestProcessDataL22PES psiRequestProcessDataL22PES)
        {
            await _psiRequestProcessDataL22PESDal.Add(psiRequestProcessDataL22PES);
            return new SuccessResult(PSIRequestProcessDataL22PESMessages.Added);
        }

        [SecurityAspect("PSIRequestProcessDataL22PES.Delete", Priority = 2)]
        [CacheRemoveAspect("IPSIRequestProcessDataL22PESService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var psiRequestProcessDataL22PESDataResult = await GetById(id);
            if (psiRequestProcessDataL22PESDataResult != null)
            {
                if (psiRequestProcessDataL22PESDataResult.Success)
                {
                    var psiRequestProcessDataL22PES = psiRequestProcessDataL22PESDataResult.Data;
                    psiRequestProcessDataL22PES.IsActive = false;
                    await _psiRequestProcessDataL22PESDal.Update(psiRequestProcessDataL22PES);
                    return new SuccessResult(PSIRequestProcessDataL22PESMessages.Deleted);
                }
            }
            return new ErrorResult(PSIRequestProcessDataL22PESMessages.OperationFailed);
        }

        [SecurityAspect("PSIRequestProcessDataL22PES.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<PSIRequestProcessDataL22PES>>> GetAll()
        {
            var psiRequestProcessDataL22PESs = await _psiRequestProcessDataL22PESDal.GetList(x => x.IsActive == true);
            psiRequestProcessDataL22PESs = psiRequestProcessDataL22PESs.OrderBy(x => x.Optime).ToList();
            return new SuccessDataResult<List<PSIRequestProcessDataL22PES>>(psiRequestProcessDataL22PESs);
        }

        [SecurityAspect("PSIRequestProcessDataL22PES.GetById", Priority = 2)]
        public async Task<IDataResult<PSIRequestProcessDataL22PES>> GetById(Guid id)
        {
            return new SuccessDataResult<PSIRequestProcessDataL22PES>(await _psiRequestProcessDataL22PESDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("PSIRequestProcessDataL22PES.Search", Priority = 2)]
        public async Task<IDataResult<List<PSIRequestProcessDataL22PES>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<PSIRequestProcessDataL22PES>>(await _psiRequestProcessDataL22PESDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("PSIRequestProcessDataL22PES.Update", Priority = 2)]
        [ValidationAspect(typeof(PSIRequestProcessDataL22PESValidator), Priority = 3)]
        [CacheRemoveAspect("IPSIRequestProcessDataL22PESService.Get", Priority = 4)]
        public async Task<IResult> Update(PSIRequestProcessDataL22PES psiRequestProcessDataL22PES)
        {
            await _psiRequestProcessDataL22PESDal.Update(psiRequestProcessDataL22PES);
            return new SuccessResult(PSIRequestProcessDataL22PESMessages.Updated);
        }
    }
}
