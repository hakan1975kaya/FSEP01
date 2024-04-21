using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.Recipes;

namespace Business.Abstract.General.General
{
    public interface IRecipeBasicDataService
    {
        public Task<IResult> Add(RecipeBasicData recipeBasicData);
        public Task<IResult> Update(RecipeBasicData recipeBasicData);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<RecipeBasicData>> GetById(Guid id);
        public Task<IDataResult<List<RecipeBasicData>>> GetAll();
        public Task<IDataResult<List<RecipeBasicData>>> Search(FilterDto filterDto);
    }
}
