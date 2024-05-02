﻿using Core.Utilities.Results.Abstract;
using Entities.Concrete.Dtos.General.Genaral;
using Entities.Concrete.Entities.PLC.Recipe;
using Entities.Concrete.Entities.PSI.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.PLC.Machine
{
    public interface IPLCRecipeService
    {
        public Task<IDataResult<PLCRecipe>> Read();
        public Task<IResult> Write(PLCRecipe plcCRecipe);
    }
}
