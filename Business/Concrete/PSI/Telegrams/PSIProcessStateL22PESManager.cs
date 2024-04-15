using Business.Abstract.PSI.Telegrams;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages.PSI.Telegrams;
using Business.Validators.FluentValidators.PSI.Telegrams.PSIProcessStateL22PESValidators;
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
    public class PSIProcessStateL22PESManager : IPSIProcessStateL22PESService
    {
        private IPSIProcessStateL22PESDal _psiProcessStateL22PESDal;
        public PSIProcessStateL22PESManager(IPSIProcessStateL22PESDal psiProcessStateL22PESDal)
        {
            _psiProcessStateL22PESDal = psiProcessStateL22PESDal;
        }

        [SecurityAspect("PSIProcessStateL22PES.Add", Priority = 2)]
        [ValidationAspect(typeof(PSIProcessStateL22PESValidator), Priority = 3)]
        [CacheRemoveAspect("IPSIProcessStateL22PESService.Get", Priority = 4)]
        public async Task<IResult> Add(PSIProcessStateL22PES psiProcessStateL22PES)
        {
            await _psiProcessStateL22PESDal.Add(psiProcessStateL22PES);
            return new SuccessResult(PSIProcessStateL22PESMessages.Added);
        }

        [SecurityAspect("PSIProcessStateL22PES.Delete", Priority = 2)]
        [CacheRemoveAspect("IPSIProcessStateL22PESService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var psiProcessStateL22PESDataResult = await GetById(id);
            if (psiProcessStateL22PESDataResult != null)
            {
                if (psiProcessStateL22PESDataResult.Success)
                {
                    var psiProcessStateL22PES = psiProcessStateL22PESDataResult.Data;
                    psiProcessStateL22PES.IsActive = false;
                    await _psiProcessStateL22PESDal.Update(psiProcessStateL22PES);
                    return new SuccessResult(PSIProcessStateL22PESMessages.Deleted);
                }
            }
            return new ErrorResult(PSIProcessStateL22PESMessages.OperationFailed);
        }

        [SecurityAspect("PSIProcessStateL22PES.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<PSIProcessStateL22PES>>> GetAll()
        {
            var PSIProcessStateL22PESs = await _psiProcessStateL22PESDal.GetList(x => x.IsActive == true);
            PSIProcessStateL22PESs = PSIProcessStateL22PESs.OrderBy(x => x.Optime).ToList();
            return new SuccessDataResult<List<PSIProcessStateL22PES>>(PSIProcessStateL22PESs);
        }

        [SecurityAspect("PSIProcessStateL22PES.GetById", Priority = 2)]
        public async Task<IDataResult<PSIProcessStateL22PES>> GetById(Guid id)
        {
            return new SuccessDataResult<PSIProcessStateL22PES>(await _psiProcessStateL22PESDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("PSIProcessStateL22PES.Search", Priority = 2)]
        public async Task<IDataResult<List<PSIProcessStateL22PES>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<PSIProcessStateL22PES>>(await _psiProcessStateL22PESDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("PSIProcessStateL22PES.Update", Priority = 2)]
        [ValidationAspect(typeof(PSIProcessStateL22PESValidator), Priority = 3)]
        [CacheRemoveAspect("IPSIProcessStateL22PESService.Get", Priority = 4)]
        public async Task<IResult> Update(PSIProcessStateL22PES psiProcessStateL22PES)
        {
            await _psiProcessStateL22PESDal.Update(psiProcessStateL22PES);
            return new SuccessResult(PSIProcessStateL22PESMessages.Updated);
        }
    }
}
