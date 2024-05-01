using Core.Utilities.Results.Abstract;
using Entities.Concrete.Entities.PLC.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.PLC.Machine
{
    public interface IPLCRecipeService
    {
       
        public Task<IDataResult<PLCRecipe>> ReadPLCRecipe(int recipeNumber);
        public Task<IResult> WritePLCRecipe(PLCRecipe plcRecipe);

    }
}
