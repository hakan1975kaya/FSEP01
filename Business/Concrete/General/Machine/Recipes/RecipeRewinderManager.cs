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
    public class RecipeRewinderManager : IRecipeRewinderService
    {
        private IRecipeRewinderDal _recipeRewinderDal;
        public RecipeRewinderManager(EFRecipeRewinderDal recipeRewinderDal)
        {
            _recipeRewinderDal = recipeRewinderDal;
        }

        [SecurityAspect("RecipeRewinder.Add", Priority = 2)]
        [ValidationAspect(typeof(RecipeRewinderValidator), Priority = 3)]
        [CacheRemoveAspect("IRecipeRewinderService.Get", Priority = 4)]
        public async Task<IResult> Add(RecipeRewinder recipeRewinder)
        {
            await _recipeRewinderDal.Add(recipeRewinder);
            return new SuccessResult(RecipeRewinderMessages.Added);
        }

        [SecurityAspect("RecipeRewinder.Delete", Priority = 2)]
        [CacheRemoveAspect("IRecipeRewinderService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var recipeRewinderDataResult = await GetById(id);
            if (recipeRewinderDataResult != null)
            {
                if (recipeRewinderDataResult.Success)
                {
                    var recipeRewinder = recipeRewinderDataResult.Data;
                    recipeRewinder.IsActive = false;
                    await _recipeRewinderDal.Update(recipeRewinder);
                    return new SuccessResult(RecipeRewinderMessages.Deleted);
                }
            }
            return new ErrorResult(RecipeRewinderMessages.OperationFailed);
        }

        [SecurityAspect("RecipeRewinder.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<RecipeRewinder>>> GetAll()
        {
            var recipeRewinders = await _recipeRewinderDal.GetList(x => x.IsActive == true);
            recipeRewinders = recipeRewinders.OrderBy(x => x.Optime).ToList();
            return new SuccessDataResult<List<RecipeRewinder>>(recipeRewinders);
        }

        [SecurityAspect("RecipeRewinder.GetById", Priority = 2)]
        public async Task<IDataResult<RecipeRewinder>> GetById(Guid id)
        {
            return new SuccessDataResult<RecipeRewinder>(await _recipeRewinderDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("RecipeRewinder.Search", Priority = 2)]
        public async Task<IDataResult<List<RecipeRewinder>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<RecipeRewinder>>(await _recipeRewinderDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("RecipeRewinder.Update", Priority = 2)]
        [ValidationAspect(typeof(RecipeRewinderValidator), Priority = 3)]
        [CacheRemoveAspect("IRecipeRewinderService.Get", Priority = 4)]
        public async Task<IResult> Update(RecipeRewinder recipeRewinder)
        {
            await _recipeRewinderDal.Update(recipeRewinder);
            return new SuccessResult(RecipeRewinderMessages.Updated);
        }
    }
}
