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
    public class ParameterManager : IParameterService
    {
        private IParameterDal _parameterDal;
        public ParameterManager(IParameterDal parameterDal)
        {
            _parameterDal = parameterDal;
        }

        [SecurityAspect("Parameter.Add", Priority = 2)]
        [ValidationAspect(typeof(ParameterValidator), Priority = 3)]
        [CacheRemoveAspect("IParameterService.Get", Priority = 4)]
        public async Task<IResult> Add(Parameter Parameter)
        {
            await _parameterDal.Add(Parameter);
            return new SuccessResult(ParameterMessages.Added);
        }

        [SecurityAspect("Parameter.Delete", Priority = 2)]
        [CacheRemoveAspect("IParameterService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var parameterDataResult = await GetById(id);
            if (parameterDataResult != null)
            {
                if (parameterDataResult.Success)
                {
                    var parameter = parameterDataResult.Data;
                    parameter.IsActive = false;
                    await _parameterDal.Update(parameter);
                    return new SuccessResult(ParameterMessages.Deleted);
                }
            }
            return new ErrorResult(ParameterMessages.OperationFailed);
        }

        [SecurityAspect("Parameter.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<Parameter>>> GetAll()
        {
            var parameters = await _parameterDal.GetList(x => x.IsActive == true);
            parameters = parameters.OrderBy(x => x.RecipeNumber).ToList();
            return new SuccessDataResult<List<Parameter>>(parameters);
        }

        [SecurityAspect("Parameter.GetById", Priority = 2)]
        public async Task<IDataResult<Parameter>> GetById(Guid id)
        {
            return new SuccessDataResult<Parameter>(await _parameterDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("Parameter.Search", Priority = 2)]
        public async Task<IDataResult<List<Parameter>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<Parameter>>(await _parameterDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("Parameter.Update", Priority = 2)]
        [ValidationAspect(typeof(ParameterValidator), Priority = 3)]
        [CacheRemoveAspect("IParameterService.Get", Priority = 4)]
        public async Task<IResult> Update(Parameter parameter)
        {
            await _parameterDal.Update(parameter);
            return new SuccessResult(ParameterMessages.Updated);
        }
    }
}
