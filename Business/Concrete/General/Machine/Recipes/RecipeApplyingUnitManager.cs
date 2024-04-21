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
    public class RecipeApplyingUnitManager : IRecipeApplyingUnitService
    {
        private IRecipeApplyingUnitDal _recipeApplyingUnitDal;
        public RecipeApplyingUnitManager(IRecipeApplyingUnitDal recipeApplyingUnitDal)
        {
            _recipeApplyingUnitDal = recipeApplyingUnitDal;
        }

        [SecurityAspect("RecipeApplyingUnit.Add", Priority = 2)]
        [ValidationAspect(typeof(RecipeApplyingUnitValidator), Priority = 3)]
        [CacheRemoveAspect("IRecipeApplyingUnitService.Get", Priority = 4)]
        public async Task<IResult> Add(RecipeApplyingUnit recipeApplyingUnit)
        {
            await _recipeApplyingUnitDal.Add(recipeApplyingUnit);
            return new SuccessResult(RecipeApplyingUnitMessages.Added);
        }

        [SecurityAspect("RecipeApplyingUnit.Delete", Priority = 2)]
        [CacheRemoveAspect("IRecipeApplyingUnitService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var recipeApplyingUnitDataResult = await GetById(id);
            if (recipeApplyingUnitDataResult != null)
            {
                if (recipeApplyingUnitDataResult.Success)
                {
                    var recipeApplyingUnit = recipeApplyingUnitDataResult.Data;
                    recipeApplyingUnit.IsActive = false;
                    await _recipeApplyingUnitDal.Update(recipeApplyingUnit);
                    return new SuccessResult(RecipeApplyingUnitMessages.Deleted);
                }
            }
            return new ErrorResult(RecipeApplyingUnitMessages.OperationFailed);
        }

        [SecurityAspect("RecipeApplyingUnit.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<RecipeApplyingUnit>>> GetAll()
        {
            var recipeApplyingUnits = await _recipeApplyingUnitDal.GetList(x => x.IsActive == true);
            recipeApplyingUnits = recipeApplyingUnits.OrderBy(x => x.LocalId).ToList();
            return new SuccessDataResult<List<RecipeApplyingUnit>>(recipeApplyingUnits);
        }

        [SecurityAspect("RecipeApplyingUnit.GetById", Priority = 2)]
        public async Task<IDataResult<RecipeApplyingUnit>> GetById(Guid id)
        {
            return new SuccessDataResult<RecipeApplyingUnit>(await _recipeApplyingUnitDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("RecipeApplyingUnit.Search", Priority = 2)]
        public async Task<IDataResult<List<RecipeApplyingUnit>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<RecipeApplyingUnit>>(await _recipeApplyingUnitDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("RecipeApplyingUnit.Update", Priority = 2)]
        [ValidationAspect(typeof(RecipeApplyingUnitValidator), Priority = 3)]
        [CacheRemoveAspect("IRecipeApplyingUnitService.Get", Priority = 4)]
        public async Task<IResult> Update(RecipeApplyingUnit recipeApplyingUnit)
        {
            await _recipeApplyingUnitDal.Update(recipeApplyingUnit);
            return new SuccessResult(RecipeApplyingUnitMessages.Updated);
        }
    }
}
