using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.PLC.Recipes
{
    public interface IPLCRecipeBasicDataService
    {
        public Task<IDataResult<int>> ReadAcceleration();
        public Task<IResult> WriteAcceleration(int acceleration);

        public Task<IDataResult<int>> ReadDecelaration();
        public Task<IResult> WriteDecelaration(int decelaration);

        public Task<IDataResult<int>> ReadFastStop();
        public Task<IResult> WriteFastStop(int fastStop);

        public Task<IDataResult<int>> ReadJogSpeed();
        public Task<IResult> WriteJogSpeed(int jogSpeed);

    }
}
