using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.PLC.Machine
{
    public interface IPLCRewinderPressureService
    {
        public Task<IDataResult<decimal>> ReadRewinderOnePressureLaySetScaled();
        public Task<IResult> WriteRewinderOnePressureLaySetScaled(decimal rewinderOnePressureLaySetScaled);

        public Task<IDataResult<decimal>> ReadRewinderOnePressureLayCalculateCharScaled();
        public Task<IResult> WriteRewinderOnePressureLayCalculateCharScaled(decimal rewinderOnePressureLayCalculateCharScaled);

        public Task<IDataResult<int>> ReadRewinderOnePresureLayBalance();
        public Task<IResult> WriteRewinderOnePresureLayBalance(int rewinderOnePresureLayBalance);

        public Task<IDataResult<decimal>> ReadRewinderOnePressureLayCalculateRight();
        public Task<IResult> WriteRewinderOnePressureLayCalculateRight(decimal rewinderOnePressureLayCalculateRight);

        public Task<IDataResult<decimal>> ReadRewinderOnePressureLayCalculateLeft();
        public Task<IResult> WriteRewinderOnePressureLayCalculateLeft(decimal rewinderOnePressureLayCalculateLeft);

        public Task<IDataResult<decimal>> ReadRewinderOnePressureContactSetScaled();
        public Task<IResult> WriteRewinderOnePressureContactSetScaled(decimal rewinderOnePressureContactSetScaled);

        public Task<IDataResult<decimal>> ReadRewinderOnePressureContactCalculateCharScaled();
        public Task<IResult> WriteRewinderOnePressureContactCalculateCharScaled(decimal rewinderOnePressureContactCalculateCharScaled);

        public Task<IDataResult<int>> ReadRewinderOnePressureContactBalance();
        public Task<IResult> WriteRewinderOnePressureContactBalance(int rewinderOnePressureContactBalance);

        public Task<IDataResult<decimal>> ReadRewinderOnePressureContactCalculateRight();
        public Task<IResult> WriteRewinderOnePressureContactCalculateRight(decimal rewinderOnePressureContactCalculateRight);

        public Task<IDataResult<decimal>> ReadRewinderOnePressureContactCalculateLeft();
        public Task<IResult> WriteRewinderOnePressureContactCalculateLeft(decimal rewinderOnePressureContactCalculateLeft);

        public Task<IDataResult<decimal>> ReadRewinderTwoPressureContanctSetScaled();
        public Task<IResult> WriteRewinderTwoPressureContanctSetScaled(decimal rewinderTwoPressureContanctSetScaled);

        public Task<IDataResult<decimal>> ReadRewinderTwoPressureContactCalculateCharScaled();
        public Task<IResult> WriteRewinderTwoPressureContactCalculateCharScaled(decimal rewinderTwoPressureContactCalculateCharScaled);

        public Task<IDataResult<int>> ReadRewinderTwoPressureContanctBalance();
        public Task<IResult> WriteRewinderTwoPressureContanctBalance(int rewinderTwoPressureContanctBalance);

        public Task<IDataResult<decimal>> ReadRewinderTwoPressureContactCalculateRight();
        public Task<IResult> WriteRewinderTwoPressureContactCalculateRight(decimal rewinderTwoPressureContactCalculateRight);

        public Task<IDataResult<decimal>> ReadRewinderTwoPressureContactCalculateLeft();
        public Task<IResult> WriteRewinderTwoPressureContactCalculateLeft(decimal rewinderTwoPressureContactCalculateLeft);

        public Task<IDataResult<decimal>> ReadRewinderTwoPressureSupportSetScaled();
        public Task<IResult> WriteRewinderTwoPressureSupportSetScaled(decimal rewinderTwoPressureSupportSetScaled);

        public Task<IDataResult<decimal>> ReadRewinderTwoPressureSupportCalculateCharScaled();
        public Task<IResult> WriteRewinderTwoPressureSupportCalculateCharScaled(decimal rewinderTwoPressureSupportCalculateCharScaled);

        public Task<IDataResult<int>> ReadRewinderTwoPressureSupportBalance();
        public Task<IResult> WriteRewinderTwoPressureSupportBalance(int rewinderTwoPressureSupportBalance);

        public Task<IDataResult<decimal>> ReadRewinderTwoPressureSupportCalcuteRight();
        public Task<IResult> WriteRewinderTwoPressureSupportCalcuteRight(decimal rewinderTwoPressureSupportCalcuteRight);

        public Task<IDataResult<decimal>> ReadRewinderTwoPressureSupportCalcuteLeft();
        public Task<IResult> WriteRewinderTwoPressureSupportCalcuteLeft(decimal rewinderTwoPressureSupportCalcuteLeft);
    }
}  
