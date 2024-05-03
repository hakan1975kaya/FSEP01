using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.PLC.Machine
{
    public interface IPLCMachineOverviewService
    {
        public Task<IDataResult<long>> ReadUnwinderOneDiameterActuel();
        public Task<IResult> WriteUnwinderOneDiameterActuel(long unwinderOneDiameterActuel);

        public Task<IDataResult<long>> ReadTransportOneTensionSet();
        public Task<IResult> WriteTransportOneTensionSet(long transportOneTensionSet);

        public Task<IDataResult<long>> ReadTransportTwoTensionSet();
        public Task<IResult> WriteTransportTwoTensionSet(long transportTwoTensionSet);

        public Task<IDataResult<decimal>> ReadRewinderOneTensionLaySetScaled();
        public Task<IResult> WriteRewinderOneTensionLaySetScaled(decimal rewinderOneTensionLaySetScaled);

        public Task<IDataResult<decimal>> ReadRewinderOneTensionCalculateCharScaled();
        public Task<IResult> WriteRewinderOneTensionCalculateCharScaled(decimal rewinderOneTensionCalculateCharScaled);

        public Task<IDataResult<long>> ReadRewinderOneLengthActuel();
        public Task<IResult> WriteRewinderOneLengthActuel(long rewinderOneLengthActuel);

        public Task<IDataResult<long>> ReadRewinderOneDiameterActuel();
        public Task<IResult> WriteRewinderOneDiameterActuel(long rewinderOneDiameterActuel);

        public Task<IDataResult<decimal>> ReadContactOneTensionActuel();
        public Task<IResult> WriteContactOneTensionActuel(decimal contactOneTensionActuel);

        public Task<IDataResult<decimal>> ReadContactTwoTensionActuel();
        public Task<IResult> WriteContactTwoTensionActuel(decimal contactTwoTensionActuel);

        public Task<IDataResult<decimal>> ReadRewinderTwoTensionCalculateCharScaled();
        public Task<IResult> WriteRewinderTwoTensionCalculateCharScaled(decimal rewinderTwoTensionCalculateCharScaled);

        public Task<IDataResult<long>> ReadRewinderTwoLengthActuel();
        public Task<IResult> WriteRewinderTwoLengthActuel(long rewinderTwoLengthActuel);

        public Task<IDataResult<long>> ReadRewinderTwoDiameterActuel();
        public Task<IResult> WriteRewinderTwoDiameterActuel(long rewinderTwoDiameterActuel);

        public Task<IDataResult<decimal>> ReadRewinderTwoTensionSupportSetScaled();
        public Task<IResult> WriteRewinderTwoTensionSupportSetScaled(decimal rewinderTwoTensionSupportSetScaled);

        public Task<IDataResult<decimal>> ReadRewinderOnePressureLayCalculateCharScaled();
        public Task<IResult> WriteRewinderOnePressureLayCalculateCharScaled(decimal rewinderOnePressureLayCalculateCharScaled);

        public Task<IDataResult<decimal>> ReadRewinderOnePressureContactCalculateCharScaled();
        public Task<IResult> WriteRewinderOnePressureContactCalculateCharScaled(decimal rewinderOnePressureContactCalculateCharScaled);

        public Task<IDataResult<decimal>> ReadRewinderTwoPressureContactCalculateCharScaled();
        public Task<IResult> WriteRewinderTwoPressureContactCalculateCharScaled(decimal rewinderTwoPressureContactCalculateCharScaled);

        public Task<IDataResult<decimal>> ReadRewinderTwoPressureSupportCalculateCharScaled();
        public Task<IResult> WriteRewinderTwoPressureSupportCalculateCharScaled(decimal rewinderTwoPressureSupportCalculateCharScaled);


    }
}
  
