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
    public class ParameterRewinderTwoTensionManager : IParameterRewinderTwoTensionService
    {
        private IParameterRewinderTwoTensionDal _parameterRewinderTwoTensionDal;
        public ParameterRewinderTwoTensionManager(IParameterRewinderTwoTensionDal parameterRewinderTwoTensionDal)
        {
            _parameterRewinderTwoTensionDal = parameterRewinderTwoTensionDal;
        }

        [SecurityAspect("ParameterRewinderTwoTension.Add", Priority = 2)]
        [ValidationAspect(typeof(ParameterRewinderTwoTensionValidator), Priority = 3)]
        [CacheRemoveAspect("IParameterRewinderTwoTensionService.Get", Priority = 4)]
        public async Task<IResult> Add(ParameterRewinderTwoTension parameterRewinderTwoTension)
        {
            await _parameterRewinderTwoTensionDal.Add(parameterRewinderTwoTension);
            return new SuccessResult(ParameterRewinderTwoTensionMessages.Added);
        }

        [SecurityAspect("ParameterRewinderTwoTension.Delete", Priority = 2)]
        [CacheRemoveAspect("IParameterRewinderTwoTensionService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var parameterRewinderTwoTensionDataResult = await GetById(id);
            if (parameterRewinderTwoTensionDataResult != null)
            {
                if (parameterRewinderTwoTensionDataResult.Success)
                {
                    var parameterRewinderTwoTension = parameterRewinderTwoTensionDataResult.Data;
                    parameterRewinderTwoTension.IsActive = false;
                    await _parameterRewinderTwoTensionDal.Update(parameterRewinderTwoTension);
                    return new SuccessResult(ParameterRewinderTwoTensionMessages.Deleted);
                }
            }
            return new ErrorResult(ParameterRewinderTwoTensionMessages.OperationFailed);
        }

        [SecurityAspect("ParameterRewinderTwoTension.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<ParameterRewinderTwoTension>>> GetAll()
        {
            var parameterRewinderTwoTensions = await _parameterRewinderTwoTensionDal.GetList(x => x.IsActive == true);
            parameterRewinderTwoTensions = parameterRewinderTwoTensions.OrderBy(x => x.Optime).ToList();
            return new SuccessDataResult<List<ParameterRewinderTwoTension>>(parameterRewinderTwoTensions);
        }

        [SecurityAspect("ParameterRewinderTwoTension.GetById", Priority = 2)]
        public async Task<IDataResult<ParameterRewinderTwoTension>> GetById(Guid id)
        {
            return new SuccessDataResult<ParameterRewinderTwoTension>(await _parameterRewinderTwoTensionDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("ParameterRewinderTwoTension.Search", Priority = 2)]
        public async Task<IDataResult<List<ParameterRewinderTwoTension>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<ParameterRewinderTwoTension>>(await _parameterRewinderTwoTensionDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("ParameterRewinderTwoTension.Update", Priority = 2)]
        [ValidationAspect(typeof(ParameterRewinderTwoTensionValidator), Priority = 3)]
        [CacheRemoveAspect("IParameterRewinderTwoTensionService.Get", Priority = 4)]
        public async Task<IResult> Update(ParameterRewinderTwoTension parameterRewinderTwoTension)
        {
            await _parameterRewinderTwoTensionDal.Update(parameterRewinderTwoTension);
            return new SuccessResult(ParameterRewinderTwoTensionMessages.Updated);
        }
    }
}
