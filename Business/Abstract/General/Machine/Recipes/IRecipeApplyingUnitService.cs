using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.Recipes;

namespace Business.Abstract.General.General
{
    public interface IRecipeApplyingUnitService
    {
        public Task<IResult> Add(RecipeApplyingUnit recipeApplyingUnit);
        public Task<IResult> Update(RecipeApplyingUnit recipeApplyingUnit);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<RecipeApplyingUnit>> GetById(Guid id);
        public Task<IDataResult<List<RecipeApplyingUnit>>> GetAll();
        public Task<IDataResult<List<RecipeApplyingUnit>>> Search(FilterDto filterDto);
    }
}
