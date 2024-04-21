using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.Recipes;

namespace Business.Abstract.General.General
{
    public interface IRecipeRewinderTwoPressureService
    {
        public Task<IResult> Add(RecipeRewinderTwoPressure recipeRewinderTwoPressure);
        public Task<IResult> Update(RecipeRewinderTwoPressure recipeRewinderTwoPressure);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<RecipeRewinderTwoPressure>> GetById(Guid id);
        public Task<IDataResult<List<RecipeRewinderTwoPressure>>> GetAll();
        public Task<IDataResult<List<RecipeRewinderTwoPressure>>> Search(FilterDto filterDto);
    }
}
