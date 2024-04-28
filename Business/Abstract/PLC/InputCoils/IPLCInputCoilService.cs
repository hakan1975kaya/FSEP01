using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.PLC.InputCoils
{
    public interface IPLCInputCoilService
    {
        public Task<IDataResult<string>> ReadRecipeNumber();
        public Task<IResult> WriteRecipeNumber(string recipeNumber);

    }
}
