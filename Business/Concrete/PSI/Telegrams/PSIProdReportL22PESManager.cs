using Business.Abstract.PSI.Telegrams;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages.PSI.Telegrams;
using Business.Validators.FluentValidators.PSI.Telegrams.PSIProdReportL22PESValidators;
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
    public class PSIProdReportL22PESManager : IPSIProdReportL22PESService
    {
        private IPSIProdReportL22PESDal _psiProdReportL22PESDal;
        public PSIProdReportL22PESManager(IPSIProdReportL22PESDal psiProdReportL22PESDal)
        {
            _psiProdReportL22PESDal = psiProdReportL22PESDal;
        }

        [SecurityAspect("PSIProdReportL22PES.Add", Priority = 2)]
        [ValidationAspect(typeof(PSIProdReportL22PESValidator), Priority = 3)]
        [CacheRemoveAspect("IPSIProdReportL22PESService.Get", Priority = 4)]
        public async Task<IResult> Add(PSIProdReportL22PES PSIProdReportL22PES)
        {
            await _psiProdReportL22PESDal.Add(PSIProdReportL22PES);
            return new SuccessResult(PSIProdReportL22PESMessages.Added);
        }

        [SecurityAspect("PSIProdReportL22PES.Delete", Priority = 2)]
        [CacheRemoveAspect("IPSIProdReportL22PESService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var psiProdReportL22PESDataResult = await GetById(id);
            if (psiProdReportL22PESDataResult != null)
            {
                if (psiProdReportL22PESDataResult.Success)
                {
                    var psiProdReportL22PES = psiProdReportL22PESDataResult.Data;
                    psiProdReportL22PES.IsActive = false;
                    await _psiProdReportL22PESDal.Update(psiProdReportL22PES);
                    return new SuccessResult(PSIProdReportL22PESMessages.Deleted);
                }
            }
            return new ErrorResult(PSIProdReportL22PESMessages.OperationFailed);
        }

        [SecurityAspect("PSIProdReportL22PES.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<PSIProdReportL22PES>>> GetAll()
        {
            var psiProdReportL22PESs = await _psiProdReportL22PESDal.GetList(x => x.IsActive == true);
            psiProdReportL22PESs = psiProdReportL22PESs.OrderBy(x => x.Optime).ToList();
            return new SuccessDataResult<List<PSIProdReportL22PES>>(psiProdReportL22PESs);
        }

        [SecurityAspect("PSIProdReportL22PES.GetById", Priority = 2)]
        public async Task<IDataResult<PSIProdReportL22PES>> GetById(Guid id)
        {
            return new SuccessDataResult<PSIProdReportL22PES>(await _psiProdReportL22PESDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("PSIProdReportL22PES.Search", Priority = 2)]
        public async Task<IDataResult<List<PSIProdReportL22PES>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<PSIProdReportL22PES>>(await _psiProdReportL22PESDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("PSIProdReportL22PES.Update", Priority = 2)]
        [ValidationAspect(typeof(PSIProdReportL22PESValidator), Priority = 3)]
        [CacheRemoveAspect("IPSIProdReportL22PESService.Get", Priority = 4)]
        public async Task<IResult> Update(PSIProdReportL22PES psiProdReportL22PES)
        {
            await _psiProdReportL22PESDal.Update(psiProdReportL22PES);
            return new SuccessResult(PSIProdReportL22PESMessages.Updated);
        }
    }
}
