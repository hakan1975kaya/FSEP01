using Business.Abstract.PSI.Telegrams;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages.PSI.Telegrams;
using Business.Validators.FluentValidators.PSI.Telegrams.PSIPingAckPES2L2Validators;
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
    public class PSIPingAckPES2L2Manager : IPSIPingAckPES2L2Service
    {
        private IPSIPingAckPES2L2Dal _psiPingAckPES2L2Dal;
        public PSIPingAckPES2L2Manager(IPSIPingAckPES2L2Dal psiPingAckPES2L2Dal)
        {
            _psiPingAckPES2L2Dal = psiPingAckPES2L2Dal;
        }

        [SecurityAspect("PSIPingAckPES2L2.Add", Priority = 2)]
        [ValidationAspect(typeof(PSIPingAckPES2L2Validator), Priority = 3)]
        [CacheRemoveAspect("IPSIPingAckPES2L2Service.Get", Priority = 4)]
        public async Task<IResult> Add(PSIPingAckPES2L2 psiPingAckPES2L2)
        {
            await _psiPingAckPES2L2Dal.Add(psiPingAckPES2L2);
            return new SuccessResult(PSIPingAckPES2L2Messages.Added);
        }

        [SecurityAspect("PSIPingAckPES2L2.Delete", Priority = 2)]
        [CacheRemoveAspect("IPSIPingAckPES2L2Service.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var psiPingAckPES2L2DataResult = await GetById(id);
            if (psiPingAckPES2L2DataResult != null)
            {
                if (psiPingAckPES2L2DataResult.Success)
                {
                    var psiPingAckPES2L2 = psiPingAckPES2L2DataResult.Data;
                    psiPingAckPES2L2.IsActive = false;
                    await _psiPingAckPES2L2Dal.Update(psiPingAckPES2L2);
                    return new SuccessResult(PSIPingAckPES2L2Messages.Deleted);
                }
            }
            return new ErrorResult(PSIPingAckPES2L2Messages.OperationFailed);
        }

        [SecurityAspect("PSIPingAckPES2L2.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<PSIPingAckPES2L2>>> GetAll()
        {
            var psiPingAckPES2L2s = await _psiPingAckPES2L2Dal.GetList(x => x.IsActive == true);
            psiPingAckPES2L2s = psiPingAckPES2L2s.OrderBy(x => x.Optime).ToList();
            return new SuccessDataResult<List<PSIPingAckPES2L2>>(psiPingAckPES2L2s);
        }

        [SecurityAspect("PSIPingAckPES2L2.GetById", Priority = 2)]
        public async Task<IDataResult<PSIPingAckPES2L2>> GetById(Guid id)
        {
            return new SuccessDataResult<PSIPingAckPES2L2>(await _psiPingAckPES2L2Dal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("PSIPingAckPES2L2.Search", Priority = 2)]
        public async Task<IDataResult<List<PSIPingAckPES2L2>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<PSIPingAckPES2L2>>(await _psiPingAckPES2L2Dal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("PSIPingAckPES2L2.Update", Priority = 2)]
        [ValidationAspect(typeof(PSIPingAckPES2L2Validator), Priority = 3)]
        [CacheRemoveAspect("IPSIPingAckPES2L2Service.Get", Priority = 4)]
        public async Task<IResult> Update(PSIPingAckPES2L2 psiPingAckPES2L2)
        {
            await _psiPingAckPES2L2Dal.Update(psiPingAckPES2L2);
            return new SuccessResult(PSIPingAckPES2L2Messages.Updated);
        }
    }
}
