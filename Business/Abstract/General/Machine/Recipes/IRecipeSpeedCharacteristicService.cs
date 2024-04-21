using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.General.Machine.Recipes;

namespace Business.Abstract.General.General
{
    public interface IRecipeSpeedCharacteristicService
    {
        public Task<IResult> Add(RecipeSpeedCharacteristic recipeSpeedCharacteristic);
        public Task<IResult> Update(RecipeSpeedCharacteristic recipeSpeedCharacteristic);
        public Task<IResult> Delete(Guid id);
        public Task<IDataResult<RecipeSpeedCharacteristic>> GetById(Guid id);
        public Task<IDataResult<List<RecipeSpeedCharacteristic>>> GetAll();
        public Task<IDataResult<List<RecipeSpeedCharacteristic>>> Search(FilterDto filterDto);
    }
}
