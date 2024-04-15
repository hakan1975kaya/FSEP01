using Business.Abstract.PSI.Telegrams;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages.PSI.Telegrams;
using Business.Validators.FluentValidators.PSI.Telegrams.PSIPingL22PESValidators;
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
    public class PSIPingL22PESManager : IPSIPingL22PESService
    {
        private IPSIPingL22PESDal _psiPingL22PESDal;
        public PSIPingL22PESManager(IPSIPingL22PESDal psiPingL22PESDal)
        {
            _psiPingL22PESDal = psiPingL22PESDal;
        }

        [SecurityAspect("PSIPingL22PES.Add", Priority = 2)]
        [ValidationAspect(typeof(PSIPingL22PESValidator), Priority = 3)]
        [CacheRemoveAspect("IPSIPingL22PESService.Get", Priority = 4)]
        public async Task<IResult> Add(PSIPingL22PES psiPingL22PES)
        {
            await _psiPingL22PESDal.Add(psiPingL22PES);
            return new SuccessResult(PSIPingL22PESMessages.Added);
        }

        [SecurityAspect("PSIPingL22PES.Delete", Priority = 2)]
        [CacheRemoveAspect("IPSIPingL22PESService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var psiPingL22PESDataResult = await GetById(id);
            if (psiPingL22PESDataResult != null)
            {
                if (psiPingL22PESDataResult.Success)
                {
                    var psiPingL22PES = psiPingL22PESDataResult.Data;
                    psiPingL22PES.IsActive = false;
                    await _psiPingL22PESDal.Update(psiPingL22PES);
                    return new SuccessResult(PSIPingL22PESMessages.Deleted);
                }
            }
            return new ErrorResult(PSIPingL22PESMessages.OperationFailed);
        }

        [SecurityAspect("PSIPingL22PES.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<PSIPingL22PES>>> GetAll()
        {
            var PSIPingL22PESs = await _psiPingL22PESDal.GetList(x => x.IsActive == true);
            PSIPingL22PESs = PSIPingL22PESs.OrderBy(x => x.Optime).ToList();
            return new SuccessDataResult<List<PSIPingL22PES>>(PSIPingL22PESs);
        }

        [SecurityAspect("PSIPingL22PES.GetById", Priority = 2)]
        public async Task<IDataResult<PSIPingL22PES>> GetById(Guid id)
        {
            return new SuccessDataResult<PSIPingL22PES>(await _psiPingL22PESDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("PSIPingL22PES.Search", Priority = 2)]
        public async Task<IDataResult<List<PSIPingL22PES>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<PSIPingL22PES>>(await _psiPingL22PESDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("PSIPingL22PES.Update", Priority = 2)]
        [ValidationAspect(typeof(PSIPingL22PESValidator), Priority = 3)]
        [CacheRemoveAspect("IPSIPingL22PESService.Get", Priority = 4)]
        public async Task<IResult> Update(PSIPingL22PES psiPingL22PES)
        {
            await _psiPingL22PESDal.Update(psiPingL22PES);
            return new SuccessResult(PSIPingL22PESMessages.Updated);
        }
    }
}
