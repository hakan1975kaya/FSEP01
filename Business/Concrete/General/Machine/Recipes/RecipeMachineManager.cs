using Business.Abstract.General.General;
using Business.BusinessAspect.Autofac;
using Business.Constants.Messages.General.General;
using Business.Validators.FluentValidators.General.Machine.Recipe;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract.General.Machine.Recipes;
using DataAccess.Concrete.EntityFramework.General.Machine.Recipes;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.Recipes;

namespace Business.Concrete.General.General
{
    [LogAspect(typeof(DatabaseLogger), Priority = 1)]
    public class RecipeMachineManager : IRecipeMachineService
    {
        private IRecipeMachineDal _recipeMachineDal;
        public RecipeMachineManager(EFRecipeMachineDal recipeMachineDal)
        {
            _recipeMachineDal = recipeMachineDal;
        }

        [SecurityAspect("RecipeMachine.Add", Priority = 2)]
        [ValidationAspect(typeof(RecipeMachineValidator), Priority = 3)]
        [CacheRemoveAspect("IRecipeMachineService.Get", Priority = 4)]
        public async Task<IResult> Add(RecipeMachine recipeMachine)
        {
            await _recipeMachineDal.Add(recipeMachine);
            return new SuccessResult(RecipeMachineMessages.Added);
        }

        [SecurityAspect("RecipeMachine.Delete", Priority = 2)]
        [CacheRemoveAspect("IRecipeMachineService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var recipeMachineDataResult = await GetById(id);
            if (recipeMachineDataResult != null)
            {
                if (recipeMachineDataResult.Success)
                {
                    var recipeMachine = recipeMachineDataResult.Data;
                    recipeMachine.IsActive = false;
                    await _recipeMachineDal.Update(recipeMachine);
                    return new SuccessResult(RecipeMachineMessages.Deleted);
                }
            }
            return new ErrorResult(RecipeMachineMessages.OperationFailed);
        }

        [SecurityAspect("RecipeMachine.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<RecipeMachine>>> GetAll()
        {
            var recipeMachines = await _recipeMachineDal.GetList(x => x.IsActive == true);
            recipeMachines = recipeMachines.OrderBy(x => x.Optime).ToList();
            return new SuccessDataResult<List<RecipeMachine>>(recipeMachines);
        }

        [SecurityAspect("RecipeMachine.GetById", Priority = 2)]
        public async Task<IDataResult<RecipeMachine>> GetById(Guid id)
        {
            return new SuccessDataResult<RecipeMachine>(await _recipeMachineDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("RecipeMachine.Search", Priority = 2)]
        public async Task<IDataResult<List<RecipeMachine>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<RecipeMachine>>(await _recipeMachineDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("RecipeMachine.Update", Priority = 2)]
        [ValidationAspect(typeof(RecipeMachineValidator), Priority = 3)]
        [CacheRemoveAspect("IRecipeMachineService.Get", Priority = 4)]
        public async Task<IResult> Update(RecipeMachine recipeMachine)
        {
            await _recipeMachineDal.Update(recipeMachine);
            return new SuccessResult(RecipeMachineMessages.Updated);
        }
    }
}
