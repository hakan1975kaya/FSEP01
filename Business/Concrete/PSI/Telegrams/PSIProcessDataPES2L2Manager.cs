using Business.Abstract.PSI.Telegrams;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages.PSI.Telegrams;
using Business.Validators.FluentValidators.PSI.Telegrams.PSIProcessDataPES2L2Validators;
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
    public class PSIProcessDataPES2L2Manager : IPSIProcessDataPES2L2Service
    {
        private IPSIProcessDataPES2L2Dal _psiProcessDataPES2L2Dal;
        public PSIProcessDataPES2L2Manager(IPSIProcessDataPES2L2Dal psiProcessDataPES2L2Dal)
        {
            _psiProcessDataPES2L2Dal = psiProcessDataPES2L2Dal;
        }

        [SecurityAspect("PSIProcessDataPES2L2.Add", Priority = 2)]
        [ValidationAspect(typeof(PSIProcessDataPES2L2Validator), Priority = 3)]
        [CacheRemoveAspect("IPSIProcessDataPES2L2Service.Get", Priority = 4)]
        public async Task<IResult> Add(PSIProcessDataPES2L2 psiProcessDataPES2L2)
        {
            await _psiProcessDataPES2L2Dal.Add(psiProcessDataPES2L2);
            return new SuccessResult(PSIProcessDataPES2L2Messages.Added);
        }

        [SecurityAspect("PSIProcessDataPES2L2.Delete", Priority = 2)]
        [CacheRemoveAspect("IPSIProcessDataPES2L2Service.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var psiProcessDataPES2L2DataResult = await GetById(id);
            if (psiProcessDataPES2L2DataResult != null)
            {
                if (psiProcessDataPES2L2DataResult.Success)
                {
                    var psiProcessDataPES2L2 = psiProcessDataPES2L2DataResult.Data;
                    psiProcessDataPES2L2.IsActive = false;
                    await _psiProcessDataPES2L2Dal.Update(psiProcessDataPES2L2);
                    return new SuccessResult(PSIProcessDataPES2L2Messages.Deleted);
                }
            }
            return new ErrorResult(PSIProcessDataPES2L2Messages.OperationFailed);
        }

        [SecurityAspect("PSIProcessDataPES2L2.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<PSIProcessDataPES2L2>>> GetAll()
        {
            var psiProcessDataPES2L2s = await _psiProcessDataPES2L2Dal.GetList(x => x.IsActive == true);
            psiProcessDataPES2L2s = psiProcessDataPES2L2s.OrderBy(x => x.Optime).ToList();
            return new SuccessDataResult<List<PSIProcessDataPES2L2>>(psiProcessDataPES2L2s);
        }

        [SecurityAspect("PSIProcessDataPES2L2.GetById", Priority = 2)]
        public async Task<IDataResult<PSIProcessDataPES2L2>> GetById(Guid id)
        {
            return new SuccessDataResult<PSIProcessDataPES2L2>(await _psiProcessDataPES2L2Dal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("PSIProcessDataPES2L2.Search", Priority = 2)]
        public async Task<IDataResult<List<PSIProcessDataPES2L2>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<PSIProcessDataPES2L2>>(await _psiProcessDataPES2L2Dal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter) ));
        }

        [SecurityAspect("PSIProcessDataPES2L2.Update", Priority = 2)]
        [ValidationAspect(typeof(PSIProcessDataPES2L2Validator), Priority = 3)]
        [CacheRemoveAspect("IPSIProcessDataPES2L2Service.Get", Priority = 4)]
        public async Task<IResult> Update(PSIProcessDataPES2L2 psiProcessDataPES2L2)
        {
            await _psiProcessDataPES2L2Dal.Update(psiProcessDataPES2L2);
            return new SuccessResult(PSIProcessDataPES2L2Messages.Updated);
        }
    }
}
