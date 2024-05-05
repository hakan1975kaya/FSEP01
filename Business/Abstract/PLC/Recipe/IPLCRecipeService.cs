using Core.Utilities.Results.Abstract;
using Entities.Concrete.Entities.PLC.Recipe;

namespace Business.Abstract.PLC.Machine
{
    public interface IPLCRecipeService
    {
        public Task<IDataResult<PLCRecipe>> Read();
        public Task<IResult> Write(PLCRecipe plcCRecipe);
    }
}
