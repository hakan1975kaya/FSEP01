using Business.Abstract.PSI.Telegrams;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages.PSI.Telegrams;
using Business.Validators.FluentValidators.PSI.Telegrams.PSIPingAckL22PESValidators;
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
    public class PSIPingAckL22PESManager : IPSIPingAckL22PESService
    {
        private IPSIPingAckL22PESDal _psiPingAckL22PESDal;
        public PSIPingAckL22PESManager(IPSIPingAckL22PESDal psiPingAckL22PESDal)
        {
            _psiPingAckL22PESDal = psiPingAckL22PESDal;
        }

        [SecurityAspect("PSIPingAckL22PES.Add", Priority = 2)]
        [ValidationAspect(typeof(PSIPingAckL22PESValidator), Priority = 3)]
        [CacheRemoveAspect("IPSIPingAckL22PESService.Get", Priority = 4)]
        public async Task<IResult> Add(PSIPingAckL22PES psiPingAckL22PES)
        {
            await _psiPingAckL22PESDal.Add(psiPingAckL22PES);
            return new SuccessResult(PSIPingAckL22PESMessages.Added);
        }

        [SecurityAspect("PSIPingAckL22PES.Delete", Priority = 2)]
        [CacheRemoveAspect("IPSIPingAckL22PESService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var psiPingAckL22PESDataResult = await GetById(id);
            if (psiPingAckL22PESDataResult != null)
            {
                if (psiPingAckL22PESDataResult.Success)
                {
                    var PSIPingAckL22PES = psiPingAckL22PESDataResult.Data;
                    PSIPingAckL22PES.IsActive = false;
                    await _psiPingAckL22PESDal.Update(PSIPingAckL22PES);
                    return new SuccessResult(PSIPingAckL22PESMessages.Deleted);
                }
            }
            return new ErrorResult(PSIPingAckL22PESMessages.OperationFailed);
        }

        [SecurityAspect("PSIPingAckL22PES.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<PSIPingAckL22PES>>> GetAll()
        {
            var psiPingAckL22PESs = await _psiPingAckL22PESDal.GetList(x => x.IsActive == true);
            psiPingAckL22PESs = psiPingAckL22PESs.OrderBy(x => x.Optime).ToList();
            return new SuccessDataResult<List<PSIPingAckL22PES>>(psiPingAckL22PESs);
        }

        [SecurityAspect("PSIPingAckL22PES.GetById", Priority = 2)]
        public async Task<IDataResult<PSIPingAckL22PES>> GetById(Guid id)
        {
            return new SuccessDataResult<PSIPingAckL22PES>(await _psiPingAckL22PESDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("PSIPingAckL22PES.Search", Priority = 2)]
        public async Task<IDataResult<List<PSIPingAckL22PES>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<PSIPingAckL22PES>>(await _psiPingAckL22PESDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("PSIPingAckL22PES.Update", Priority = 2)]
        [ValidationAspect(typeof(PSIPingAckL22PESValidator), Priority = 3)]
        [CacheRemoveAspect("IPSIPingAckL22PESService.Get", Priority = 4)]
        public async Task<IResult> Update(PSIPingAckL22PES psiPingAckL22PES)
        {
            await _psiPingAckL22PESDal.Update(psiPingAckL22PES);
            return new SuccessResult(PSIPingAckL22PESMessages.Updated);
        }
    }
}
