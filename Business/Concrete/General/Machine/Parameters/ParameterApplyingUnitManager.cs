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
    public class ParameterApplyingUnitManager : IParameterApplyingUnitService
    {
        private IParameterApplyingUnitDal _parameterApplyingUnitDal;
        public ParameterApplyingUnitManager(IParameterApplyingUnitDal parameterApplyingUnitDal)
        {
            _parameterApplyingUnitDal = parameterApplyingUnitDal;
        }

        [SecurityAspect("ParameterApplyingUnit.Add", Priority = 2)]
        [ValidationAspect(typeof(ParameterApplyingUnitValidator), Priority = 3)]
        [CacheRemoveAspect("IParameterApplyingUnitService.Get", Priority = 4)]
        public async Task<IResult> Add(ParameterApplyingUnit parameterApplyingUnit)
        {
            await _parameterApplyingUnitDal.Add(parameterApplyingUnit);
            return new SuccessResult(ParameterApplyingUnitMessages.Added);
        }

        [SecurityAspect("ParameterApplyingUnit.Delete", Priority = 2)]
        [CacheRemoveAspect("IParameterApplyingUnitService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var parameterApplyingUnitDataResult = await GetById(id);
            if (parameterApplyingUnitDataResult != null)
            {
                if (parameterApplyingUnitDataResult.Success)
                {
                    var parameterApplyingUnit = parameterApplyingUnitDataResult.Data;
                    parameterApplyingUnit.IsActive = false;
                    await _parameterApplyingUnitDal.Update(parameterApplyingUnit);
                    return new SuccessResult(ParameterApplyingUnitMessages.Deleted);
                }
            }
            return new ErrorResult(ParameterApplyingUnitMessages.OperationFailed);
        }

        [SecurityAspect("ParameterApplyingUnit.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<ParameterApplyingUnit>>> GetAll()
        {
            var parameterApplyingUnits = await _parameterApplyingUnitDal.GetList(x => x.IsActive == true);
            parameterApplyingUnits = parameterApplyingUnits.OrderBy(x => x.Optime).ToList();
            return new SuccessDataResult<List<ParameterApplyingUnit>>(parameterApplyingUnits);
        }

        [SecurityAspect("ParameterApplyingUnit.GetById", Priority = 2)]
        public async Task<IDataResult<ParameterApplyingUnit>> GetById(Guid id)
        {
            return new SuccessDataResult<ParameterApplyingUnit>(await _parameterApplyingUnitDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("ParameterApplyingUnit.Search", Priority = 2)]
        public async Task<IDataResult<List<ParameterApplyingUnit>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<ParameterApplyingUnit>>(await _parameterApplyingUnitDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("ParameterApplyingUnit.Update", Priority = 2)]
        [ValidationAspect(typeof(ParameterApplyingUnitValidator), Priority = 3)]
        [CacheRemoveAspect("IParameterApplyingUnitService.Get", Priority = 4)]
        public async Task<IResult> Update(ParameterApplyingUnit parameterApplyingUnit)
        {
            await _parameterApplyingUnitDal.Update(parameterApplyingUnit);
            return new SuccessResult(ParameterApplyingUnitMessages.Updated);
        }
    }
}
