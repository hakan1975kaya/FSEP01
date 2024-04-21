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
    public class RecipeRewinderTwoTensionManager : IRecipeRewinderTwoTensionService
    {
        private IRecipeRewinderTwoTensionDal _recipeRewinderTwoTensionDal;
        public RecipeRewinderTwoTensionManager(EFRecipeRewinderTwoTensionDal recipeRewinderTwoTensionDal)
        {
            _recipeRewinderTwoTensionDal = recipeRewinderTwoTensionDal;
        }

        [SecurityAspect("RecipeRewinderTwoTension.Add", Priority = 2)]
        [ValidationAspect(typeof(RecipeRewinderTwoTensionValidator), Priority = 3)]
        [CacheRemoveAspect("IRecipeRewinderTwoTensionService.Get", Priority = 4)]
        public async Task<IResult> Add(RecipeRewinderTwoTension recipeRewinderTwoTension)
        {
            await _recipeRewinderTwoTensionDal.Add(recipeRewinderTwoTension);
            return new SuccessResult(RecipeRewinderTwoTensionMessages.Added);
        }

        [SecurityAspect("RecipeRewinderTwoTension.Delete", Priority = 2)]
        [CacheRemoveAspect("IRecipeRewinderTwoTensionService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var recipeRewinderTwoTensionDataResult = await GetById(id);
            if (recipeRewinderTwoTensionDataResult != null)
            {
                if (recipeRewinderTwoTensionDataResult.Success)
                {
                    var recipeRewinderTwoTension = recipeRewinderTwoTensionDataResult.Data;
                    recipeRewinderTwoTension.IsActive = false;
                    await _recipeRewinderTwoTensionDal.Update(recipeRewinderTwoTension);
                    return new SuccessResult(RecipeRewinderTwoTensionMessages.Deleted);
                }
            }
            return new ErrorResult(RecipeRewinderTwoTensionMessages.OperationFailed);
        }

        [SecurityAspect("RecipeRewinderTwoTension.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<RecipeRewinderTwoTension>>> GetAll()
        {
            var recipeRewinderTwoTensions = await _recipeRewinderTwoTensionDal.GetList(x => x.IsActive == true);
            recipeRewinderTwoTensions = recipeRewinderTwoTensions.OrderBy(x => x.Optime).ToList();
            return new SuccessDataResult<List<RecipeRewinderTwoTension>>(recipeRewinderTwoTensions);
        }

        [SecurityAspect("RecipeRewinderTwoTension.GetById", Priority = 2)]
        public async Task<IDataResult<RecipeRewinderTwoTension>> GetById(Guid id)
        {
            return new SuccessDataResult<RecipeRewinderTwoTension>(await _recipeRewinderTwoTensionDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("RecipeRewinderTwoTension.Search", Priority = 2)]
        public async Task<IDataResult<List<RecipeRewinderTwoTension>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<RecipeRewinderTwoTension>>(await _recipeRewinderTwoTensionDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("RecipeRewinderTwoTension.Update", Priority = 2)]
        [ValidationAspect(typeof(RecipeRewinderTwoTensionValidator), Priority = 3)]
        [CacheRemoveAspect("IRecipeRewinderTwoTensionService.Get", Priority = 4)]
        public async Task<IResult> Update(RecipeRewinderTwoTension recipeRewinderTwoTension)
        {
            await _recipeRewinderTwoTensionDal.Update(recipeRewinderTwoTension);
            return new SuccessResult(RecipeRewinderTwoTensionMessages.Updated);
        }
    }
}
