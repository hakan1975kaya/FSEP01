using Business.Abstract.PSI.Telegrams;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages.PSI.Telegrams;
using Business.Validators.FluentValidators.PSI.Telegrams.PSIGeneralAckPES2L2Validators;
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
    public class PSIGeneralAckPES2L2Manager : IPSIGeneralAckPES2L2Service
    {
        private IPSIGeneralAckPES2L2Dal _psiGeneralAckPES2L2Dal;
        public PSIGeneralAckPES2L2Manager(IPSIGeneralAckPES2L2Dal psiGeneralAckPES2L2Dal)
        {
            _psiGeneralAckPES2L2Dal = psiGeneralAckPES2L2Dal;
        }

        [SecurityAspect("PSIGeneralAckPES2L2.Add", Priority = 2)]
        [ValidationAspect(typeof(PSIGeneralAckPES2L2Validator), Priority = 3)]
        [CacheRemoveAspect("IPSIGeneralAckPES2L2Service.Get", Priority = 4)]
        public async Task<IResult> Add(PSIGeneralAckPES2L2 psiGeneralAckPES2L2)
        {
            await _psiGeneralAckPES2L2Dal.Add(psiGeneralAckPES2L2);
            return new SuccessResult(PSIGeneralAckPES2L2Messages.Added);
        }

        [SecurityAspect("PSIGeneralAckPES2L2.Delete", Priority = 2)]
        [CacheRemoveAspect("IPSIGeneralAckPES2L2Service.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var psiGeneralAckPES2L2DataResult = await GetById(id);
            if (psiGeneralAckPES2L2DataResult != null)
            {
                if (psiGeneralAckPES2L2DataResult.Success)
                {
                    var psiGeneralAckPES2L2 = psiGeneralAckPES2L2DataResult.Data;
                    psiGeneralAckPES2L2.IsActive = false;
                    await _psiGeneralAckPES2L2Dal.Update(psiGeneralAckPES2L2);
                    return new SuccessResult(PSIGeneralAckPES2L2Messages.Deleted);
                }
            }
            return new ErrorResult(PSIGeneralAckPES2L2Messages.OperationFailed);
        }

        [SecurityAspect("PSIGeneralAckPES2L2.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<PSIGeneralAckPES2L2>>> GetAll()
        {
            var psiGeneralAckPES2L2s = await _psiGeneralAckPES2L2Dal.GetList(x => x.IsActive == true);
            psiGeneralAckPES2L2s = psiGeneralAckPES2L2s.OrderBy(x => x.Optime).ToList();
            return new SuccessDataResult<List<PSIGeneralAckPES2L2>>(psiGeneralAckPES2L2s);
        }

        [SecurityAspect("PSIGeneralAckPES2L2.GetById", Priority = 2)]
        public async Task<IDataResult<PSIGeneralAckPES2L2>> GetById(Guid id)
        {
            return new SuccessDataResult<PSIGeneralAckPES2L2>(await _psiGeneralAckPES2L2Dal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("PSIGeneralAckPES2L2.Search", Priority = 2)]
        public async Task<IDataResult<List<PSIGeneralAckPES2L2>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<PSIGeneralAckPES2L2>>(await _psiGeneralAckPES2L2Dal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("PSIGeneralAckPES2L2.Update", Priority = 2)]
        [ValidationAspect(typeof(PSIGeneralAckPES2L2Validator), Priority = 3)]
        [CacheRemoveAspect("IPSIGeneralAckPES2L2Service.Get", Priority = 4)]
        public async Task<IResult> Update(PSIGeneralAckPES2L2 psiGeneralAckPES2L2)
        {
            await _psiGeneralAckPES2L2Dal.Update(psiGeneralAckPES2L2);
            return new SuccessResult(PSIGeneralAckPES2L2Messages.Updated);
        }
    }
}
