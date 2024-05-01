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

        public Task<IDataResult<decimal>> ReadHandlingPositionOne();
        public Task<IResult> WriteHandlingPositionOne(decimal handlingPositionOne);

        public Task<IDataResult<decimal>> ReadHandlingPositionTwo();
        public Task<IResult> WriteHandlingPositionTwo(decimal handlingPositionTwo);

        public Task<IDataResult<decimal>> ReadHandlingPositionThree();
        public Task<IResult> WriteHandlingPositionThree(decimal handlingPositionThree);

        public Task<IDataResult<decimal>> ReadHandlingPositionFour();
        public Task<IResult> WriteHandlingPositionFour(decimal handlingPositionFour);

        public Task<IDataResult<decimal>> ReadHandlingPositionFive();
        public Task<IResult> WriteHandlingPositionFive(decimal handlingPositionFive);

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

        public Task<IDataResult<decimal>> ReadLiftOneSetPositionOne();
        public Task<IResult> WriteLiftOneSetPositionOne(decimal liftOneSetPositionOne);

        public Task<IDataResult<decimal>> ReadLiftOneSetPositionTwo();
        public Task<IResult> WriteLiftOneSetPositionTwo(decimal liftOneSetPositionTwo);

        public Task<IDataResult<decimal>> ReadLiftOneSetPositionThree();
        public Task<IResult> WriteLiftOneSetPositionThree(decimal liftOneSetPositionThree);

        public Task<IDataResult<decimal>> ReadLiftOneSetPositionFour();
        public Task<IResult> WriteLiftOneSetPositionFour(decimal liftOneSetPositionFour);

        public Task<IDataResult<decimal>> ReadLiftOneSetPositionFive();
        public Task<IResult> WriteLiftOneSetPositionFive(decimal liftOneSetPositionFive);

        public Task<IDataResult<decimal>> ReadLiftOneSetPositionSix();
        public Task<IResult> WriteLiftOneSetPositionSix(decimal liftOneSetPositionSix);

        public Task<IDataResult<decimal>> ReadLiftOneSetPositionSeven();
        public Task<IResult> WriteLiftOneSetPositionSeven(decimal liftOneSetPositionSeven);

        public Task<IDataResult<decimal>> ReadLiftOneSetPositionEight();
        public Task<IResult> WriteLiftOneSetPositionEight(decimal liftOneSetPositionEight);

        public Task<IDataResult<decimal>> ReadLiftTwoSetPositionOne();
        public Task<IResult> WriteLiftTwoSetPositionOne(decimal LiftTwoSetPositionOne);

        public Task<IDataResult<decimal>> ReadLiftTwoSetPositionTwo();
        public Task<IResult> WriteLiftTwoSetPositionTwo(decimal LiftTwoSetPositionTwo);

        public Task<IDataResult<decimal>> ReadLiftTwoSetPositionThree();
        public Task<IResult> WriteLiftTwoSetPositionThree(decimal LiftTwoSetPositionThree);

        public Task<IDataResult<decimal>> ReadLiftTwoSetPositionFour();
        public Task<IResult> WriteLiftTwoSetPositionFour(decimal LiftTwoSetPositionFour);

        public Task<IDataResult<decimal>> ReadLiftTwoSetPositionFive();
        public Task<IResult> WriteLiftTwoSetPositionFive(decimal LiftTwoSetPositionFive);

        public Task<IDataResult<decimal>> ReadLiftTwoSetPositionSix();
        public Task<IResult> WriteLiftTwoSetPositionSix(decimal LiftTwoSetPositionSix);

        public Task<IDataResult<decimal>> ReadLiftTwoSetPositionSeven();
        public Task<IResult> WriteLiftTwoSetPositionSeven(decimal LiftTwoSetPositionSeven);

        public Task<IDataResult<decimal>> ReadLiftTwoSetPositionEight();
        public Task<IResult> WriteLiftTwoSetPositionEight(decimal LiftTwoSetPositionEight);
    }
}
