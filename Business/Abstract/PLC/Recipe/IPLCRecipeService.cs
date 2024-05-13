using Core.Utilities.Results.Abstract;
using Entities.Concrete.Entities.PLC.Recipe;

namespace Business.Abstract.PLC.Machine
{
    public interface IPLCRecipeService
    {
        public Task<IDataResult<PLCRecipe>> ReadRecipe();
        public Task<IResult> WriteRecipe(PLCRecipe plcCRecipe);
    }
}
