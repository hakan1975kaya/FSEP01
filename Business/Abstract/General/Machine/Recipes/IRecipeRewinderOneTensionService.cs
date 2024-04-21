using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.Recipes;

namespace Business.Abstract.General.General
{
    public interface IRecipeRewinderOneTensionService
    {
        public Task<IResult> Add(RecipeRewinderOneTension recipeRewinderOneTension);
        public Task<IResult> Update(RecipeRewinderOneTension recipeRewinderOneTension);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<RecipeRewinderOneTension>> GetById(Guid id);
        public Task<IDataResult<List<RecipeRewinderOneTension>>> GetAll();
        public Task<IDataResult<List<RecipeRewinderOneTension>>> Search(FilterDto filterDto);
    }
}
