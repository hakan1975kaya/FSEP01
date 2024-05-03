using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.PLC.Machine
{
    public interface IPLCHandlingService
    {
        public Task<IDataResult<decimal>> ReadPositionHandling();
        public Task<IResult> WritePositionHandling(decimal positionHandling);

        public Task<IDataResult<decimal>> ReadPositionHandlingLiftOne();
        public Task<IResult> WritePositionHandlingLiftOne(decimal positionHandlingLiftOne);

        public Task<IDataResult<decimal>> ReadPositionHandlingLiftTwo();
        public Task<IResult> WritePositionHandlingLiftTwo(decimal positionHandlingLiftTwo);

        public Task<IDataResult<long>> ReadHandlingPositionOne();
        public Task<IResult> WriteHandlingPositionOne(long handlingPositionOne);

        public Task<IDataResult<long>> ReadHandlingPositionTwo();
        public Task<IResult> WriteHandlingPositionTwo(long handlingPositionTwo);

        public Task<IDataResult<long>> ReadHandlingPositionThree();
        public Task<IResult> WriteHandlingPositionThree(long handlingPositionThree);

        public Task<IDataResult<long>> ReadHandlingPositionFour();
        public Task<IResult> WriteHandlingPositionFour(long handlingPositionFour);

        public Task<IDataResult<long>> ReadHandlingPositionFive();
        public Task<IResult> WriteHandlingPositionFive(long handlingPositionFive);

        public Task<IDataResult<bool>> ReadLiftOnePositionOne();
        public Task<IResult> WriteLiftOnePositionOne(bool liftOnePositionOne);

        public Task<IDataResult<bool>> ReadLiftOnePositionTwo();
        public Task<IResult> WriteLiftOnePositionTwo(bool liftOnePositionTwo);

        public Task<IDataResult<bool>> ReadLiftOnePositionThree();
        public Task<IResult> WriteLiftOnePositionThree(bool liftOnePositionThree);

        public Task<IDataResult<bool>> ReadLiftOnePositionFour();
        public Task<IResult> WriteLiftOnePositionFour(bool liftOnePositionFour);

        public Task<IDataResult<bool>> ReadLiftOnePositionFive();
        public Task<IResult> WriteLiftOnePositionFive(bool liftOnePositionFive);

        public Task<IDataResult<bool>> ReadLiftOnePositionSix();
        public Task<IResult> WriteLiftOnePositionSix(bool liftOnePositionSix);

        public Task<IDataResult<bool>> ReadLiftOnePositionSeven();
        public Task<IResult> WriteLiftOnePositionSeven(bool liftOnePositionSeven);

        public Task<IDataResult<bool>> ReadLiftOnePositionEight();
        public Task<IResult> WriteLiftOnePositionEight(bool liftOnePositionEight);

        public Task<IDataResult<bool>> ReadLiftTwoPositionOne();
        public Task<IResult> WriteLiftTwoPositionOne(bool liftTwoPositionOne);

        public Task<IDataResult<bool>> ReadLiftTwoPositionTwo();
        public Task<IResult> WriteLiftTwoPositionTwo(bool liftTwoPositionTwo);

        public Task<IDataResult<bool>> ReadLiftTwoPositionThree();
        public Task<IResult> WriteLiftTwoPositionThree(bool liftTwoPositionThree);

        public Task<IDataResult<bool>> ReadLiftTwoPositionFour();
        public Task<IResult> WriteLiftTwoPositionFour(bool liftTwoPositionFour);

        public Task<IDataResult<bool>> ReadLiftTwoPositionFive();
        public Task<IResult> WriteLiftTwoPositionFive(bool liftTwoPositionFive);

        public Task<IDataResult<bool>> ReadLiftTwoPositionSix();
        public Task<IResult> WriteLiftTwoPositionSix(bool liftTwoPositionSix);

        public Task<IDataResult<bool>> ReadLiftTwoPositionSeven();
        public Task<IResult> WriteLiftTwoPositionSeven(bool liftTwoPositionSeven);

        public Task<IDataResult<bool>> ReadLiftTwoPositionEight();
        public Task<IResult> WriteLiftTwoPositionEight(bool liftTwoPositionEight);

        public Task<IDataResult<long>> ReadLiftOneSetPositionOne();
        public Task<IResult> WriteLiftOneSetPositionOne(long liftOneSetPositionOne);

        public Task<IDataResult<long>> ReadLiftOneSetPositionTwo();
        public Task<IResult> WriteLiftOneSetPositionTwo(long liftOneSetPositionTwo);

        public Task<IDataResult<long>> ReadLiftOneSetPositionThree();
        public Task<IResult> WriteLiftOneSetPositionThree(long liftOneSetPositionThree);

        public Task<IDataResult<long>> ReadLiftOneSetPositionFour();
        public Task<IResult> WriteLiftOneSetPositionFour(long liftOneSetPositionFour);

        public Task<IDataResult<long>> ReadLiftOneSetPositionFive();
        public Task<IResult> WriteLiftOneSetPositionFive(long liftOneSetPositionFive);

        public Task<IDataResult<long>> ReadLiftOneSetPositionSix();
        public Task<IResult> WriteLiftOneSetPositionSix(long liftOneSetPositionSix);

        public Task<IDataResult<long>> ReadLiftOneSetPositionSeven();
        public Task<IResult> WriteLiftOneSetPositionSeven(long liftOneSetPositionSeven);

        public Task<IDataResult<long>> ReadLiftOneSetPositionEight();
        public Task<IResult> WriteLiftOneSetPositionEight(long liftOneSetPositionEight);

        public Task<IDataResult<long>> ReadLiftTwoSetPositionOne();
        public Task<IResult> WriteLiftTwoSetPositionOne(long LiftTwoSetPositionOne);

        public Task<IDataResult<long>> ReadLiftTwoSetPositionTwo();
        public Task<IResult> WriteLiftTwoSetPositionTwo(long LiftTwoSetPositionTwo);

        public Task<IDataResult<long>> ReadLiftTwoSetPositionThree();
        public Task<IResult> WriteLiftTwoSetPositionThree(long LiftTwoSetPositionThree);

        public Task<IDataResult<long>> ReadLiftTwoSetPositionFour();
        public Task<IResult> WriteLiftTwoSetPositionFour(long LiftTwoSetPositionFour);

        public Task<IDataResult<long>> ReadLiftTwoSetPositionFive();
        public Task<IResult> WriteLiftTwoSetPositionFive(long LiftTwoSetPositionFive);

        public Task<IDataResult<long>> ReadLiftTwoSetPositionSix();
        public Task<IResult> WriteLiftTwoSetPositionSix(long LiftTwoSetPositionSix);

        public Task<IDataResult<long>> ReadLiftTwoSetPositionSeven();
        public Task<IResult> WriteLiftTwoSetPositionSeven(long LiftTwoSetPositionSeven);

        public Task<IDataResult<long>> ReadLiftTwoSetPositionEight();
        public Task<IResult> WriteLiftTwoSetPositionEight(long LiftTwoSetPositionEight);
    }
}
