using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.Recipes;

namespace Business.Abstract.General.General
{
    public interface IRecipeRewinderOnePressureService
    {
        public Task<IResult> Add(RecipeRewinderOnePressure recipeRewinderOnePressure);
        public Task<IResult> Update(RecipeRewinderOnePressure recipeRewinderOnePressure);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<RecipeRewinderOnePressure>> GetById(Guid id);
        public Task<IDataResult<List<RecipeRewinderOnePressure>>> GetAll();
        public Task<IDataResult<List<RecipeRewinderOnePressure>>> Search(FilterDto filterDto);
    }
}
