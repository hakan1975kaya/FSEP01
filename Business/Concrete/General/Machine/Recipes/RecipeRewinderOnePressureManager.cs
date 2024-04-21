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
    public class RecipeRewinderOnePressureManager : IRecipeRewinderOnePressureService
    {
        private IRecipeRewinderOnePressureDal _recipeRewinderOnePressureDal;
        public RecipeRewinderOnePressureManager(EFRecipeRewinderOnePressureDal recipeRewinderOnePressureDal)
        {
            _recipeRewinderOnePressureDal = recipeRewinderOnePressureDal;
        }

        [SecurityAspect("RecipeRewinderOnePressure.Add", Priority = 2)]
        [ValidationAspect(typeof(RecipeRewinderOnePressureValidator), Priority = 3)]
        [CacheRemoveAspect("IRecipeRewinderOnePressureService.Get", Priority = 4)]
        public async Task<IResult> Add(RecipeRewinderOnePressure recipeRewinderOnePressure)
        {
            await _recipeRewinderOnePressureDal.Add(recipeRewinderOnePressure);
            return new SuccessResult(RecipeRewinderOnePressureMessages.Added);
        }

        [SecurityAspect("RecipeRewinderOnePressure.Delete", Priority = 2)]
        [CacheRemoveAspect("IRecipeRewinderOnePressureService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var recipeRewinderOnePressureDataResult = await GetById(id);
            if (recipeRewinderOnePressureDataResult != null)
            {
                if (recipeRewinderOnePressureDataResult.Success)
                {
                    var recipeRewinderOnePressure = recipeRewinderOnePressureDataResult.Data;
                    recipeRewinderOnePressure.IsActive = false;
                    await _recipeRewinderOnePressureDal.Update(recipeRewinderOnePressure);
                    return new SuccessResult(RecipeRewinderOnePressureMessages.Deleted);
                }
            }
            return new ErrorResult(RecipeRewinderOnePressureMessages.OperationFailed);
        }

        [SecurityAspect("RecipeRewinderOnePressure.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<RecipeRewinderOnePressure>>> GetAll()
        {
            var recipeRewinderOnePressures = await _recipeRewinderOnePressureDal.GetList(x => x.IsActive == true);
            recipeRewinderOnePressures = recipeRewinderOnePressures.OrderBy(x => x.Optime).ToList();
            return new SuccessDataResult<List<RecipeRewinderOnePressure>>(recipeRewinderOnePressures);
        }

        [SecurityAspect("RecipeRewinderOnePressure.GetById", Priority = 2)]
        public async Task<IDataResult<RecipeRewinderOnePressure>> GetById(Guid id)
        {
            return new SuccessDataResult<RecipeRewinderOnePressure>(await _recipeRewinderOnePressureDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("RecipeRewinderOnePressure.Search", Priority = 2)]
        public async Task<IDataResult<List<RecipeRewinderOnePressure>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<RecipeRewinderOnePressure>>(await _recipeRewinderOnePressureDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("RecipeRewinderOnePressure.Update", Priority = 2)]
        [ValidationAspect(typeof(RecipeRewinderOnePressureValidator), Priority = 3)]
        [CacheRemoveAspect("IRecipeRewinderOnePressureService.Get", Priority = 4)]
        public async Task<IResult> Update(RecipeRewinderOnePressure recipeRewinderOnePressure)
        {
            await _recipeRewinderOnePressureDal.Update(recipeRewinderOnePressure);
            return new SuccessResult(RecipeRewinderOnePressureMessages.Updated);
        }
    }
}
