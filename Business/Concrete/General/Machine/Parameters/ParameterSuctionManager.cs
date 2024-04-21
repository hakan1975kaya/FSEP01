using Business.Abstract.General.General;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages.General.General;
using Business.Validators.FluentValidators.General.Machine.Parameters;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract.General.Machine.Parameters;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.Parameters;

namespace Business.Concrete.General.General
{
    [LogAspect(typeof(DatabaseLogger), Priority = 1)]
    public class ParameterSuctionManager : IParameterSuctionService
    {
        private IParameterSuctionDal _parameterSuctionDal;
        public ParameterSuctionManager(IParameterSuctionDal parameterSuctionDal)
        {
            _parameterSuctionDal = parameterSuctionDal;
        }

        [SecurityAspect("ParameterSuction.Add", Priority = 2)]
        [ValidationAspect(typeof(ParameterSuctionValidator), Priority = 3)]
        [CacheRemoveAspect("IParameterSuctionService.Get", Priority = 4)]
        public async Task<IResult> Add(ParameterSuction parameterSuction)
        {
            await _parameterSuctionDal.Add(parameterSuction);
            return new SuccessResult(ParameterSuctionMessages.Added);
        }

        [SecurityAspect("ParameterSuction.Delete", Priority = 2)]
        [CacheRemoveAspect("IParameterSuctionService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var parameterSuctionDataResult = await GetById(id);
            if (parameterSuctionDataResult != null)
            {
                if (parameterSuctionDataResult.Success)
                {
                    var parameterSuction = parameterSuctionDataResult.Data;
                    parameterSuction.IsActive = false;
                    await _parameterSuctionDal.Update(parameterSuction);
                    return new SuccessResult(ParameterSuctionMessages.Deleted);
                }
            }
            return new ErrorResult(ParameterSuctionMessages.OperationFailed);
        }

        [SecurityAspect("ParameterSuction.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<ParameterSuction>>> GetAll()
        {
            var parameterSuctions = await _parameterSuctionDal.GetList(x => x.IsActive == true);
            parameterSuctions = parameterSuctions.OrderBy(x => x.Optime).ToList();
            return new SuccessDataResult<List<ParameterSuction>>(parameterSuctions);
        }

        [SecurityAspect("ParameterSuction.GetById", Priority = 2)]
        public async Task<IDataResult<ParameterSuction>> GetById(Guid id)
        {
            return new SuccessDataResult<ParameterSuction>(await _parameterSuctionDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("ParameterSuction.Search", Priority = 2)]
        public async Task<IDataResult<List<ParameterSuction>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<ParameterSuction>>(await _parameterSuctionDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("ParameterSuction.Update", Priority = 2)]
        [ValidationAspect(typeof(ParameterSuctionValidator), Priority = 3)]
        [CacheRemoveAspect("IParameterSuctionService.Get", Priority = 4)]
        public async Task<IResult> Update(ParameterSuction parameterSuction)
        {
            await _parameterSuctionDal.Update(parameterSuction);
            return new SuccessResult(ParameterSuctionMessages.Updated);
        }
    }
}
