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
    public class RecipeRewinderTwoPressureManager : IRecipeRewinderTwoPressureService
    {
        private IRecipeRewinderTwoPressureDal _recipeRewinderTwoPressureDal;
        public RecipeRewinderTwoPressureManager(EFRecipeRewinderTwoPressureDal recipeRewinderTwoPressureDal)
        {
            _recipeRewinderTwoPressureDal = recipeRewinderTwoPressureDal;
        }

        [SecurityAspect("RecipeRewinderTwoPressure.Add", Priority = 2)]
        [ValidationAspect(typeof(RecipeRewinderTwoPressureValidator), Priority = 3)]
        [CacheRemoveAspect("IRecipeRewinderTwoPressureService.Get", Priority = 4)]
        public async Task<IResult> Add(RecipeRewinderTwoPressure recipeRewinderTwoPressure)
        {
            await _recipeRewinderTwoPressureDal.Add(recipeRewinderTwoPressure);
            return new SuccessResult(RecipeRewinderTwoPressureMessages.Added);
        }

        [SecurityAspect("RecipeRewinderTwoPressure.Delete", Priority = 2)]
        [CacheRemoveAspect("IRecipeRewinderTwoPressureService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var recipeRewinderTwoPressureDataResult = await GetById(id);
            if (recipeRewinderTwoPressureDataResult != null)
            {
                if (recipeRewinderTwoPressureDataResult.Success)
                {
                    var recipeRewinderTwoPressure = recipeRewinderTwoPressureDataResult.Data;
                    recipeRewinderTwoPressure.IsActive = false;
                    await _recipeRewinderTwoPressureDal.Update(recipeRewinderTwoPressure);
                    return new SuccessResult(RecipeRewinderTwoPressureMessages.Deleted);
                }
            }
            return new ErrorResult(RecipeRewinderTwoPressureMessages.OperationFailed);
        }

        [SecurityAspect("RecipeRewinderTwoPressure.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<RecipeRewinderTwoPressure>>> GetAll()
        {
            var recipeRewinderTwoPressures = await _recipeRewinderTwoPressureDal.GetList(x => x.IsActive == true);
            recipeRewinderTwoPressures = recipeRewinderTwoPressures.OrderBy(x => x.Optime).ToList();
            return new SuccessDataResult<List<RecipeRewinderTwoPressure>>(recipeRewinderTwoPressures);
        }

        [SecurityAspect("RecipeRewinderTwoPressure.GetById", Priority = 2)]
        public async Task<IDataResult<RecipeRewinderTwoPressure>> GetById(Guid id)
        {
            return new SuccessDataResult<RecipeRewinderTwoPressure>(await _recipeRewinderTwoPressureDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("RecipeRewinderTwoPressure.Search", Priority = 2)]
        public async Task<IDataResult<List<RecipeRewinderTwoPressure>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<RecipeRewinderTwoPressure>>(await _recipeRewinderTwoPressureDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("RecipeRewinderTwoPressure.Update", Priority = 2)]
        [ValidationAspect(typeof(RecipeRewinderTwoPressureValidator), Priority = 3)]
        [CacheRemoveAspect("IRecipeRewinderTwoPressureService.Get", Priority = 4)]
        public async Task<IResult> Update(RecipeRewinderTwoPressure recipeRewinderTwoPressure)
        {
            await _recipeRewinderTwoPressureDal.Update(recipeRewinderTwoPressure);
            return new SuccessResult(RecipeRewinderTwoPressureMessages.Updated);
        }
    }
}
