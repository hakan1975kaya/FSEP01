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
    public class RecipeRewinderOneTensionManager : IRecipeRewinderOneTensionService
    {
        private IRecipeRewinderOneTensionDal _recipeRewinderOneTensionDal;
        public RecipeRewinderOneTensionManager(EFRecipeRewinderOneTensionDal recipeRewinderOneTensionDal)
        {
            _recipeRewinderOneTensionDal = recipeRewinderOneTensionDal;
        }

        [SecurityAspect("RecipeRewinderOneTension.Add", Priority = 2)]
        [ValidationAspect(typeof(RecipeRewinderOneTensionValidator), Priority = 3)]
        [CacheRemoveAspect("IRecipeRewinderOneTensionService.Get", Priority = 4)]
        public async Task<IResult> Add(RecipeRewinderOneTension recipeRewinderOneTension)
        {
            await _recipeRewinderOneTensionDal.Add(recipeRewinderOneTension);
            return new SuccessResult(RecipeRewinderOneTensionMessages.Added);
        }

        [SecurityAspect("RecipeRewinderOneTension.Delete", Priority = 2)]
        [CacheRemoveAspect("IRecipeRewinderOneTensionService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var recipeRewinderOneTensionDataResult = await GetById(id);
            if (recipeRewinderOneTensionDataResult != null)
            {
                if (recipeRewinderOneTensionDataResult.Success)
                {
                    var recipeRewinderOneTension = recipeRewinderOneTensionDataResult.Data;
                    recipeRewinderOneTension.IsActive = false;
                    await _recipeRewinderOneTensionDal.Update(recipeRewinderOneTension);
                    return new SuccessResult(RecipeRewinderOneTensionMessages.Deleted);
                }
            }
            return new ErrorResult(RecipeRewinderOneTensionMessages.OperationFailed);
        }

        [SecurityAspect("RecipeRewinderOneTension.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<RecipeRewinderOneTension>>> GetAll()
        {
            var recipeRewinderOneTensions = await _recipeRewinderOneTensionDal.GetList(x => x.IsActive == true);
            recipeRewinderOneTensions = recipeRewinderOneTensions.OrderBy(x => x.Optime).ToList();
            return new SuccessDataResult<List<RecipeRewinderOneTension>>(recipeRewinderOneTensions);
        }

        [SecurityAspect("RecipeRewinderOneTension.GetById", Priority = 2)]
        public async Task<IDataResult<RecipeRewinderOneTension>> GetById(Guid id)
        {
            return new SuccessDataResult<RecipeRewinderOneTension>(await _recipeRewinderOneTensionDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("RecipeRewinderOneTension.Search", Priority = 2)]
        public async Task<IDataResult<List<RecipeRewinderOneTension>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<RecipeRewinderOneTension>>(await _recipeRewinderOneTensionDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("RecipeRewinderOneTension.Update", Priority = 2)]
        [ValidationAspect(typeof(RecipeRewinderOneTensionValidator), Priority = 3)]
        [CacheRemoveAspect("IRecipeRewinderOneTensionService.Get", Priority = 4)]
        public async Task<IResult> Update(RecipeRewinderOneTension recipeRewinderOneTension)
        {
            await _recipeRewinderOneTensionDal.Update(recipeRewinderOneTension);
            return new SuccessResult(RecipeRewinderOneTensionMessages.Updated);
        }
    }
}
