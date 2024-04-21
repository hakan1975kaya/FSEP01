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
    public class ParameterBasicDataManager : IParameterBasicDataService
    {
        private IParameterBasicDataDal _parameterBasicDataDal;
        public ParameterBasicDataManager(IParameterBasicDataDal parameterBasicDataDal)
        {
            _parameterBasicDataDal = parameterBasicDataDal;
        }

        [SecurityAspect("ParameterBasicData.Add", Priority = 2)]
        [ValidationAspect(typeof(ParameterBasicDataValidator), Priority = 3)]
        [CacheRemoveAspect("IParameterBasicDataService.Get", Priority = 4)]
        public async Task<IResult> Add(ParameterBasicData parameterBasicData)
        {
            await _parameterBasicDataDal.Add(parameterBasicData);
            return new SuccessResult(ParameterBasicDataMessages.Added);
        }

        [SecurityAspect("ParameterBasicData.Delete", Priority = 2)]
        [CacheRemoveAspect("IParameterBasicDataService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var parameterBasicDataDataResult = await GetById(id);
            if (parameterBasicDataDataResult != null)
            {
                if (parameterBasicDataDataResult.Success)
                {
                    var parameterBasicData = parameterBasicDataDataResult.Data;
                    parameterBasicData.IsActive = false;
                    await _parameterBasicDataDal.Update(parameterBasicData);
                    return new SuccessResult(ParameterBasicDataMessages.Deleted);
                }
            }
            return new ErrorResult(ParameterBasicDataMessages.OperationFailed);
        }

        [SecurityAspect("ParameterBasicData.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<ParameterBasicData>>> GetAll()
        {
            var parameterBasicDatas = await _parameterBasicDataDal.GetList(x => x.IsActive == true);
            parameterBasicDatas = parameterBasicDatas.OrderBy(x => x.Optime).ToList();
            return new SuccessDataResult<List<ParameterBasicData>>(parameterBasicDatas);
        }

        [SecurityAspect("ParameterBasicData.GetById", Priority = 2)]
        public async Task<IDataResult<ParameterBasicData>> GetById(Guid id)
        {
            return new SuccessDataResult<ParameterBasicData>(await _parameterBasicDataDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("ParameterBasicData.Search", Priority = 2)]
        public async Task<IDataResult<List<ParameterBasicData>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<ParameterBasicData>>(await _parameterBasicDataDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("ParameterBasicData.Update", Priority = 2)]
        [ValidationAspect(typeof(ParameterBasicDataValidator), Priority = 3)]
        [CacheRemoveAspect("IParameterBasicDataService.Get", Priority = 4)]
        public async Task<IResult> Update(ParameterBasicData parameterBasicData)
        {
            await _parameterBasicDataDal.Update(parameterBasicData);
            return new SuccessResult(ParameterBasicDataMessages.Updated);
        }
    }
}
