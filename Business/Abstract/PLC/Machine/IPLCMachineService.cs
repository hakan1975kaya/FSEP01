using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.PLC.Machine
{
    public interface IPLCMachineService
    {
        public Task<IDataResult<int>> ReadMachineSpeedSet();
        public Task<IResult> WriteMachineSpeedSet(int machineSpeedSet);

        public Task<IDataResult<int>> ReadTransportOneTensionSet();
        public Task<IResult> WriteTransportOneTensionSet(int transportOneTensionSet);

        public Task<IDataResult<int>> ReadTransportTwoTensionSet();
        public Task<IResult> WriteTransportTwoTensionSet(int transportTwoTensionSet);

        public Task<IDataResult<long>> ReadWeightRewinderOne();
        public Task<IResult> WriteWeightRewinderOne(long weightRewinderOne);

        public Task<IDataResult<long>> ReadWeightRewinderTwo();
        public Task<IResult> WriteWeightRewinderTwo(long weightRewinderOne);

        public Task<IDataResult<int>> ReadRewinderOneDiameterSet();
        public Task<IResult> WriteRewinderOneDiameterSet(int rewinderOneDiameterSet);

        public Task<IDataResult<int>> ReadRewinderOneDiameterActuel();
        public Task<IResult> WriteRewinderOneDiameterActuel(int rewinderOneDiameterActuel);

        public Task<IDataResult<long>> ReadRewinderOneLengthSet();
        public Task<IResult> WriteRewinderOneLengthSet(long rewinderOneLengthSet);

        public Task<IDataResult<long>> ReadRewinderOneLengthActuel();
        public Task<IResult> WriteRewinderOneLengthActuel(long rewinderOneLengthActuel);

        public Task<IDataResult<int>> ReadRewinderTwoDiameterSet();
        public Task<IResult> WriteRewinderTwoDiameterSet(int rewinderTwoDiameterSet);

        public Task<IDataResult<int>> ReadRewinderTwoDiameterActuel();
        public Task<IResult> WriteRewinderTwoDiameterActuel(int rewinderTwoDiameterActuel);

        public Task<IDataResult<long>> ReadRewinderTwoLengthSet();
        public Task<IResult> WriteRewinderTwoLengthSet(long rewinderTwoLengthSet);

        public Task<IDataResult<long>> ReadRewinderTwoLengthActuel();
        public Task<IResult> WriteRewinderTwoLengthActuel(long rewinderTwoLengthActuel);

        public Task<IDataResult<int>> ReadUnwinderOneDiameterSet();
        public Task<IResult> WriteUnwinderOneDiameterSet(int unwinderOneDiameterSet);

        public Task<IDataResult<int>> ReadUnwinderOneDiameterActuel();
        public Task<IResult> WriteUnwinderOneDiameterActuel(int unwinderOneDiameterActuel);

        public Task<IDataResult<decimal>> ReadRewinderOneTensionLaySetScaled();
        public Task<IResult> WriteRewinderOneTensionLaySetScaled(decimal rewinderOneTensionLaySetScaled);

        public Task<IDataResult<decimal>> ReadRewinderOneTensionCalculateCharScaled();
        public Task<IResult> WriteRewinderOneTensionCalculateCharScaled(decimal rewinderOneTensionCalculateCharScaled);

        public Task<IDataResult<decimal>> ReadContactOneTensionActuel();
        public Task<IResult> WriteContactOneTensionActuel(decimal contactOneTensionActuel);

        public Task<IDataResult<decimal>> ReadContactTwoTensionActuel();
        public Task<IResult> WriteContactTwoTensionActuel(decimal contactTwoTensionActuel);

        public Task<IDataResult<decimal>> ReadRewinderTwoTensionSupportSetScaled();
        public Task<IResult> WriteRewinderTwoTensionSupportSetScaled(decimal rewinderTwoTensionSupportSetScaled);

        public Task<IDataResult<int>> ReadRecipeRecordNumber();
        public Task<IResult> WriteRecipeRecordNumber(int recipeRecordNumber);

        public Task<IDataResult<int>> ReadRecipeNumber();
        public Task<IResult> WriteRecipeNumber(int recipeNumber);






    }

}
