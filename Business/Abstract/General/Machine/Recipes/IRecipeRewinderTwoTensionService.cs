using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.Recipes;

namespace Business.Abstract.General.General
{
    public interface IRecipeRewinderTwoTensionService
    {
        public Task<IResult> Add(RecipeRewinderTwoTension recipeRewinderTwoTension);
        public Task<IResult> Update(RecipeRewinderTwoTension recipeRewinderTwoTension);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<RecipeRewinderTwoTension>> GetById(Guid id);
        public Task<IDataResult<List<RecipeRewinderTwoTension>>> GetAll();
        public Task<IDataResult<List<RecipeRewinderTwoTension>>> Search(FilterDto filterDto);
    }
}
