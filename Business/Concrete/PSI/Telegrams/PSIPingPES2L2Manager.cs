using Business.Abstract.PSI.Telegrams;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages.PSI.Telegrams;
using Business.Validators.FluentValidators.PSI.Telegrams.PSIPingPES2L2Validators;
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
    public class PSIPingPES2L2Manager : IPSIPingPES2L2Service
    {
        private IPSIPingPES2L2Dal _psiPingPES2L2Dal;
        public PSIPingPES2L2Manager(IPSIPingPES2L2Dal psiPingPES2L2Dal)
        {
            _psiPingPES2L2Dal = psiPingPES2L2Dal;
        }

        [SecurityAspect("PSIPingPES2L2.Add", Priority = 2)]
        [ValidationAspect(typeof(PSIPingPES2L2Validator), Priority = 3)]
        [CacheRemoveAspect("IPSIPingPES2L2Service.Get", Priority = 4)]
        public async Task<IResult> Add(PSIPingPES2L2 psiPingPES2L2)
        {
            await _psiPingPES2L2Dal.Add(psiPingPES2L2);
            return new SuccessResult(PSIPingPES2L2Messages.Added);
        }

        [SecurityAspect("PSIPingPES2L2.Delete", Priority = 2)]
        [CacheRemoveAspect("IPSIPingPES2L2Service.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var psiPingPES2L2DataResult = await GetById(id);
            if (psiPingPES2L2DataResult != null)
            {
                if (psiPingPES2L2DataResult.Success)
                {
                    var psiPingPES2L2 = psiPingPES2L2DataResult.Data;
                    psiPingPES2L2.IsActive = false;
                    await _psiPingPES2L2Dal.Update(psiPingPES2L2);
                    return new SuccessResult(PSIPingPES2L2Messages.Deleted);
                }
            }
            return new ErrorResult(PSIPingPES2L2Messages.OperationFailed);
        }

        [SecurityAspect("PSIPingPES2L2.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<PSIPingPES2L2>>> GetAll()
        {
            var psiPingPES2L2s = await _psiPingPES2L2Dal.GetList(x => x.IsActive == true);
            psiPingPES2L2s = psiPingPES2L2s.OrderBy(x => x.Optime).ToList();
            return new SuccessDataResult<List<PSIPingPES2L2>>(psiPingPES2L2s);
        }

        [SecurityAspect("PSIPingPES2L2.GetById", Priority = 2)]
        public async Task<IDataResult<PSIPingPES2L2>> GetById(Guid id)
        {
            return new SuccessDataResult<PSIPingPES2L2>(await _psiPingPES2L2Dal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("PSIPingPES2L2.Search", Priority = 2)]
        public async Task<IDataResult<List<PSIPingPES2L2>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<PSIPingPES2L2>>(await _psiPingPES2L2Dal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("PSIPingPES2L2.Update", Priority = 2)]
        [ValidationAspect(typeof(PSIPingPES2L2Validator), Priority = 3)]
        [CacheRemoveAspect("IPSIPingPES2L2Service.Get", Priority = 4)]
        public async Task<IResult> Update(PSIPingPES2L2 psiPingPES2L2)
        {
            await _psiPingPES2L2Dal.Update(psiPingPES2L2);
            return new SuccessResult(PSIPingPES2L2Messages.Updated);
        }
    }
}
