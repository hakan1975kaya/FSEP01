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
        public Task<IDataResult<long>> ReadMachineSpeedSet();
        public Task<IResult> WriteMachineSpeedSet(long machineSpeedSet);

        public Task<IDataResult<long>> ReadTransportOneTensionSet();
        public Task<IResult> WriteTransportOneTensionSet(long transportOneTensionSet);

        public Task<IDataResult<long>> ReadTransportTwoTensionSet();
        public Task<IResult> WriteTransportTwoTensionSet(long transportTwoTensionSet);

        public Task<IDataResult<long>> ReadWeightRewinderOne();
        public Task<IResult> WriteWeightRewinderOne(long weightRewinderOne);

        public Task<IDataResult<long>> ReadWeightRewinderTwo();
        public Task<IResult> WriteWeightRewinderTwo(long weightRewinderOne);

        public Task<IDataResult<long>> ReadRewinderOneDiameterSet();
        public Task<IResult> WriteRewinderOneDiameterSet(long rewinderOneDiameterSet);

        public Task<IDataResult<long>> ReadRewinderOneDiameterActuel();
        public Task<IResult> WriteRewinderOneDiameterActuel(long rewinderOneDiameterActuel);

        public Task<IDataResult<long>> ReadRewinderOneLengthSet();
        public Task<IResult> WriteRewinderOneLengthSet(long rewinderOneLengthSet);

        public Task<IDataResult<long>> ReadRewinderOneLengthActuel();
        public Task<IResult> WriteRewinderOneLengthActuel(long rewinderOneLengthActuel);

        public Task<IDataResult<long>> ReadRewinderTwoDiameterSet();
        public Task<IResult> WriteRewinderTwoDiameterSet(long rewinderTwoDiameterSet);

        public Task<IDataResult<long>> ReadRewinderTwoDiameterActuel();
        public Task<IResult> WriteRewinderTwoDiameterActuel(long rewinderTwoDiameterActuel);

        public Task<IDataResult<long>> ReadRewinderTwoLengthSet();
        public Task<IResult> WriteRewinderTwoLengthSet(long rewinderTwoLengthSet);

        public Task<IDataResult<long>> ReadRewinderTwoLengthActuel();
        public Task<IResult> WriteRewinderTwoLengthActuel(long rewinderTwoLengthActuel);

        public Task<IDataResult<long>> ReadUnwinderOneDiameterSet();
        public Task<IResult> WriteUnwinderOneDiameterSet(long unwinderOneDiameterSet);

        public Task<IDataResult<long>> ReadUnwinderOneDiameterActuel();
        public Task<IResult> WriteUnwinderOneDiameterActuel(long unwinderOneDiameterActuel);

        public Task<IDataResult<bool>> ReadRewinderOneResetLength();
        public Task<IResult> WriteRewinderOneResetLength(bool rewinderOneResetLength);

        public Task<IDataResult<bool>> ReadRewinderTwoResetLength();
        public Task<IResult> WriteRewinderTwoResetLength(bool rewinderTwoResetLength);



    }

}
