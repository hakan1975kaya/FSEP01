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
    public class ParameterMachineManager : IParameterMachineService
    {
        private IParameterMachineDal _parameterMachineDal;
        public ParameterMachineManager(IParameterMachineDal parameterMachineDal)
        {
            _parameterMachineDal = parameterMachineDal;
        }

        [SecurityAspect("ParameterMachine.Add", Priority = 2)]
        [ValidationAspect(typeof(ParameterMachineValidator), Priority = 3)]
        [CacheRemoveAspect("IParameterMachineService.Get", Priority = 4)]
        public async Task<IResult> Add(ParameterMachine parameterMachine)
        {
            await _parameterMachineDal.Add(parameterMachine);
            return new SuccessResult(ParameterMachineMessages.Added);
        }

        [SecurityAspect("ParameterMachine.Delete", Priority = 2)]
        [CacheRemoveAspect("IParameterMachineService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var parameterMachineDataResult = await GetById(id);
            if (parameterMachineDataResult != null)
            {
                if (parameterMachineDataResult.Success)
                {
                    var parameterMachine = parameterMachineDataResult.Data;
                    parameterMachine.IsActive = false;
                    await _parameterMachineDal.Update(parameterMachine);
                    return new SuccessResult(ParameterMachineMessages.Deleted);
                }
            }
            return new ErrorResult(ParameterMachineMessages.OperationFailed);
        }

        [SecurityAspect("ParameterMachine.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<ParameterMachine>>> GetAll()
        {
            var parameterMachines = await _parameterMachineDal.GetList(x => x.IsActive == true);
            parameterMachines = parameterMachines.OrderBy(x => x.Optime).ToList();
            return new SuccessDataResult<List<ParameterMachine>>(parameterMachines);
        }

        [SecurityAspect("ParameterMachine.GetById", Priority = 2)]
        public async Task<IDataResult<ParameterMachine>> GetById(Guid id)
        {
            return new SuccessDataResult<ParameterMachine>(await _parameterMachineDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("ParameterMachine.Search", Priority = 2)]
        public async Task<IDataResult<List<ParameterMachine>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<ParameterMachine>>(await _parameterMachineDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("ParameterMachine.Update", Priority = 2)]
        [ValidationAspect(typeof(ParameterMachineValidator), Priority = 3)]
        [CacheRemoveAspect("IParameterMachineService.Get", Priority = 4)]
        public async Task<IResult> Update(ParameterMachine parameterMachine)
        {
            await _parameterMachineDal.Update(parameterMachine);
            return new SuccessResult(ParameterMachineMessages.Updated);
        }
    }
}
