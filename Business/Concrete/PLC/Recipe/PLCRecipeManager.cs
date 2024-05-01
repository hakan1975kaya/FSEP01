using Business.Abstract.PLC.Machine;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Entities.Concrete.Entities.PLC.Recipe;
using PLC.Abstract;
using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.PLC
{
    public class PLCRecipeManager : IPLCRecipeService
    {
        private IPLCDal _plcDal;
        public PLCRecipeManager(IPLCDal plcDal)
        {
            _plcDal = plcDal;
        }

        public async Task<IDataResult<PLCRecipe>> ReadPLCRecipe(int recipeNumber)
        {
            return new SuccessDataResult<PLCRecipe>(new PLCRecipe {}) ;
        }
        public async Task<IResult> WritePLCRecipe(PLCRecipe plcRecipe)
        {
            return new SuccessResult();
        }


    }
}
