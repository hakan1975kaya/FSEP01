using Business.Abstract.PSI.Types;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages.PSI.Types;
using Business.Validators.FluentValidators.PSI.Types.PSITypeHeaderValidators;
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
    public class PSITypeHeaderManager : IPSITypeHeaderService
    {
        private IPSITypeHeaderDal _psiTypeHeaderDal;
        public PSITypeHeaderManager(IPSITypeHeaderDal psiTypeHeaderDal)
        {
            _psiTypeHeaderDal = psiTypeHeaderDal;
        }

        [SecurityAspect("PSITypeHeader.Add", Priority = 2)]
        [ValidationAspect(typeof(PSITypeHeaderValidator), Priority = 3)]
        [CacheRemoveAspect("IPSITypeHeaderService.Get", Priority = 4)]
        public async Task<IResult> Add(PSITypeHeader psiTypeHeader)
        {
            await _psiTypeHeaderDal.Add(psiTypeHeader);
            return new SuccessResult(PSITypeHeaderMessages.Added);
        }

        [SecurityAspect("PSITypeHeader.Delete", Priority = 2)]
        [CacheRemoveAspect("IPSITypeHeaderService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var psiTypeHeaderDataResult = await GetById(id);
            if (psiTypeHeaderDataResult != null)
            {
                if (psiTypeHeaderDataResult.Success)
                {
                    var psiTypeHeader = psiTypeHeaderDataResult.Data;
                    psiTypeHeader.IsActive = false;
                    await _psiTypeHeaderDal.Update(psiTypeHeader);
                    return new SuccessResult(PSITypeHeaderMessages.Deleted);
                }
            }
            return new ErrorResult(PSITypeHeaderMessages.OperationFailed);
        }

        [SecurityAspect("PSITypeHeader.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<PSITypeHeader>>> GetAll()
        {
            var psiTypeHeaders = await _psiTypeHeaderDal.GetList(x => x.IsActive == true);
            psiTypeHeaders = psiTypeHeaders.OrderBy(x => x.Optime).ToList();
            return new SuccessDataResult<List<PSITypeHeader>>(psiTypeHeaders);
        }

        [SecurityAspect("PSITypeHeader.GetById", Priority = 2)]
        public async Task<IDataResult<PSITypeHeader>> GetById(Guid id)
        {
            return new SuccessDataResult<PSITypeHeader>(await _psiTypeHeaderDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("PSITypeHeader.Search", Priority = 2)]
        public async Task<IDataResult<List<PSITypeHeader>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<PSITypeHeader>>(await _psiTypeHeaderDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("PSITypeHeader.Update", Priority = 2)]
        [ValidationAspect(typeof(PSITypeHeaderValidator), Priority = 3)]
        [CacheRemoveAspect("IPSITypeHeaderService.Get", Priority = 4)]
        public async Task<IResult> Update(PSITypeHeader psiTypeHeader)
        {
            await _psiTypeHeaderDal.Update(psiTypeHeader);
            return new SuccessResult(PSITypeHeaderMessages.Updated);
        }
    }
}
