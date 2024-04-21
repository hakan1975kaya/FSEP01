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
    public class RecipeBasicDataManager : IRecipeBasicDataService
    {
        private IRecipeBasicDataDal _recipeBasicDataDal;
        public RecipeBasicDataManager(EFRecipeBasicDataDal recipeBasicDataDal)
        {
            _recipeBasicDataDal = recipeBasicDataDal;
        }

        [SecurityAspect("RecipeBasicData.Add", Priority = 2)]
        [ValidationAspect(typeof(RecipeBasicDataValidator), Priority = 3)]
        [CacheRemoveAspect("IRecipeBasicDataService.Get", Priority = 4)]
        public async Task<IResult> Add(RecipeBasicData recipeBasicData)
        {
            await _recipeBasicDataDal.Add(recipeBasicData);
            return new SuccessResult(RecipeBasicDataMessages.Added);
        }

        [SecurityAspect("RecipeBasicData.Delete", Priority = 2)]
        [CacheRemoveAspect("IRecipeBasicDataService.Get", Priority = 3)]
        public async Task<IResult> Delete(Guid id)
        {
            var recipeBasicDataDataResult = await GetById(id);
            if (recipeBasicDataDataResult != null)
            {
                if (recipeBasicDataDataResult.Success)
                {
                    var recipeBasicData = recipeBasicDataDataResult.Data;
                    recipeBasicData.IsActive = false;
                    await _recipeBasicDataDal.Update(recipeBasicData);
                    return new SuccessResult(RecipeBasicDataMessages.Deleted);
                }
            }
            return new ErrorResult(RecipeBasicDataMessages.OperationFailed);
        }

        [SecurityAspect("RecipeBasicData.GetAll", Priority = 2)]
        [CacheAspect(Priority = 3)]
        public async Task<IDataResult<List<RecipeBasicData>>> GetAll()
        {
            var recipeBasicDatas = await _recipeBasicDataDal.GetList(x => x.IsActive == true);
            recipeBasicDatas = recipeBasicDatas.OrderBy(x => x.Optime).ToList();
            return new SuccessDataResult<List<RecipeBasicData>>(recipeBasicDatas);
        }

        [SecurityAspect("RecipeBasicData.GetById", Priority = 2)]
        public async Task<IDataResult<RecipeBasicData>> GetById(Guid id)
        {
            return new SuccessDataResult<RecipeBasicData>(await _recipeBasicDataDal.Get(x => x.Id == id && x.IsActive == true));
        }

        [SecurityAspect("RecipeBasicData.Search", Priority = 2)]
        public async Task<IDataResult<List<RecipeBasicData>>> Search(FilterDto filterDto)
        {
            return new SuccessDataResult<List<RecipeBasicData>>(await _recipeBasicDataDal.GetList(x => x.IsActive == true && x.Optime.ToString().Contains(filterDto.Filter)));
        }

        [SecurityAspect("RecipeBasicData.Update", Priority = 2)]
        [ValidationAspect(typeof(RecipeBasicDataValidator), Priority = 3)]
        [CacheRemoveAspect("IRecipeBasicDataService.Get", Priority = 4)]
        public async Task<IResult> Update(RecipeBasicData recipeBasicData)
        {
            await _recipeBasicDataDal.Update(recipeBasicData);
            return new SuccessResult(RecipeBasicDataMessages.Updated);
        }
    }
}
