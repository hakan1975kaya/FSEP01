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
    public class RecipeSpeedCharacteristicManager : IRecipeSpeedCharacteristicService
    {
        private IRecipeSpeedCharacteristicDal _recipeSpeedCharacteristicDal;
        public RecipeSpeedCharacteristicManager(EFRecipeSpeedCharacteristicDal recipeSpeedCharacteristicDal)
        {
            _recipeSpeedCharacteristicDal = recipeSpeedCharacteristicDal;
        }

        [SecurityAspect("RecipeSpeedCharacteristic.Add", Priority = 2)]
        [ValidationAspect(typeof(RecipeSpeedCharacteristicValidator), Priority = 3)]
        [CacheRemoveAspect("IRecipeSpeedCharacteristicService.Get", Priority = 4)]
        public async Task<IResult> Add(RecipeSpeedCharacteristic recipeSpeedCharacteristic)
        {
            await _recipeSpeedCharacteristicDal.Add(recipeSpeedCharacteristic);
            return new SuccessResult(RecipeSpeedCharacteristicMessages.Added);
        }

        [SecurityAspect("RecipeSpeedCharacteristic.Delete", Priority = 2)]
        [CacheRemoveAspect("IRecipeSpeedCharacteristicService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var recipeSpeedCharacteristicDataResult = await GetById(id);
            if (recipeSpeedCharacteristicDataResult != null)
            {
                if (recipeSpeedCharacteristicDataResult.Success)
                {
                    var recipeSpeedCharacteristic = recipeSpeedCharacteristicDataResult.Data;
                    recipeSpeedCharacteristic.IsActive = false;
                    await _recipeSpeedCharacteristicDal.Update(recipeSpeedCharacteristic);
                    return new SuccessResult(RecipeSpeedCharacteristicMessages.Deleted);
                }
            }
            return new ErrorResult(RecipeSpeedCharacteristicMessages.OperationFailed);
        }

        [SecurityAspect("RecipeSpeedCharacteristic.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<RecipeSpeedCharacteristic>>> GetAll()
        {
            var recipeSpeedCharacteristics = await _recipeSpeedCharacteristicDal.GetList(x => x.IsActive == true);
            recipeSpeedCharacteristics = recipeSpeedCharacteristics.OrderBy(x => x.Optime).ToList();
            return new SuccessDataResult<List<RecipeSpeedCharacteristic>>(recipeSpeedCharacteristics);
        }

        [SecurityAspect("RecipeSpeedCharacteristic.GetById", Priority = 2)]
        public async Task<IDataResult<RecipeSpeedCharacteristic>> GetById(Guid id)
        {
            return new SuccessDataResult<RecipeSpeedCharacteristic>(await _recipeSpeedCharacteristicDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("RecipeSpeedCharacteristic.Search", Priority = 2)]
        public async Task<IDataResult<List<RecipeSpeedCharacteristic>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<RecipeSpeedCharacteristic>>(await _recipeSpeedCharacteristicDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("RecipeSpeedCharacteristic.Update", Priority = 2)]
        [ValidationAspect(typeof(RecipeSpeedCharacteristicValidator), Priority = 3)]
        [CacheRemoveAspect("IRecipeSpeedCharacteristicService.Get", Priority = 4)]
        public async Task<IResult> Update(RecipeSpeedCharacteristic recipeSpeedCharacteristic)
        {
            await _recipeSpeedCharacteristicDal.Update(recipeSpeedCharacteristic);
            return new SuccessResult(RecipeSpeedCharacteristicMessages.Updated);
        }
    }
}
