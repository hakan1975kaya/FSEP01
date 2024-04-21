using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.Recipes;

namespace Business.Abstract.General.General
{
    public interface IRecipeRewinderService
    {
        public Task<IResult> Add(RecipeRewinder recipeRewinder);
        public Task<IResult> Update(RecipeRewinder recipeRewinder);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<RecipeRewinder>> GetById(Guid id);
        public Task<IDataResult<List<RecipeRewinder>>> GetAll();
        public Task<IDataResult<List<RecipeRewinder>>> Search(FilterDto filterDto);
    }
}
