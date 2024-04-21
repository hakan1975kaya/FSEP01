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
    public class ParameterRewinderOneTensionManager : IParameterRewinderOneTensionService
    {
        private IParameterRewinderOneTensionDal _parameterRewinderOneTensionDal;
        public ParameterRewinderOneTensionManager(IParameterRewinderOneTensionDal parameterRewinderOneTensionDal)
        {
            _parameterRewinderOneTensionDal = parameterRewinderOneTensionDal;
        }

        [SecurityAspect("ParameterRewinderOneTension.Add", Priority = 2)]
        [ValidationAspect(typeof(ParameterRewinderOneTensionValidator), Priority = 3)]
        [CacheRemoveAspect("IParameterRewinderOneTensionService.Get", Priority = 4)]
        public async Task<IResult> Add(ParameterRewinderOneTension parameterRewinderOneTension)
        {
            await _parameterRewinderOneTensionDal.Add(parameterRewinderOneTension);
            return new SuccessResult(ParameterRewinderOneTensionMessages.Added);
        }

        [SecurityAspect("ParameterRewinderOneTension.Delete", Priority = 2)]
        [CacheRemoveAspect("IParameterRewinderOneTensionService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var parameterRewinderOneTensionDataResult = await GetById(id);
            if (parameterRewinderOneTensionDataResult != null)
            {
                if (parameterRewinderOneTensionDataResult.Success)
                {
                    var parameterRewinderOneTension = parameterRewinderOneTensionDataResult.Data;
                    parameterRewinderOneTension.IsActive = false;
                    await _parameterRewinderOneTensionDal.Update(parameterRewinderOneTension);
                    return new SuccessResult(ParameterRewinderOneTensionMessages.Deleted);
                }
            }
            return new ErrorResult(ParameterRewinderOneTensionMessages.OperationFailed);
        }

        [SecurityAspect("ParameterRewinderOneTension.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<ParameterRewinderOneTension>>> GetAll()
        {
            var parameterRewinderOneTensions = await _parameterRewinderOneTensionDal.GetList(x => x.IsActive == true);
            parameterRewinderOneTensions = parameterRewinderOneTensions.OrderBy(x => x.Optime).ToList();
            return new SuccessDataResult<List<ParameterRewinderOneTension>>(parameterRewinderOneTensions);
        }

        [SecurityAspect("ParameterRewinderOneTension.GetById", Priority = 2)]
        public async Task<IDataResult<ParameterRewinderOneTension>> GetById(Guid id)
        {
            return new SuccessDataResult<ParameterRewinderOneTension>(await _parameterRewinderOneTensionDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("ParameterRewinderOneTension.Search", Priority = 2)]
        public async Task<IDataResult<List<ParameterRewinderOneTension>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<ParameterRewinderOneTension>>(await _parameterRewinderOneTensionDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("ParameterRewinderOneTension.Update", Priority = 2)]
        [ValidationAspect(typeof(ParameterRewinderOneTensionValidator), Priority = 3)]
        [CacheRemoveAspect("IParameterRewinderOneTensionService.Get", Priority = 4)]
        public async Task<IResult> Update(ParameterRewinderOneTension parameterRewinderOneTension)
        {
            await _parameterRewinderOneTensionDal.Update(parameterRewinderOneTension);
            return new SuccessResult(ParameterRewinderOneTensionMessages.Updated);
        }
    }
}
