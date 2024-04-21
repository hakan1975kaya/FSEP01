using Core.Entities.Concrete;
using Entities.Concrete.Entities.General.Machine.General;
using Entities.Concrete.Entities.General.Machine.OutputCoils;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.FluentValidators.General.General.DemandValidators
{
    public class OutputCoilOtherValidator : AbstractValidator<OutputCoilOther>
    {
        public OutputCoilOtherValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.InputCoilId).NotEmpty();

            RuleFor(x => x.UnwinderActuelLength).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.UnwinderThickness).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.UnwinderThicknessCalculatedValueActuel).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.UnwinderThicknessCalculatedValueMinimum).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.UnwinderThicknessCalculatedValueMaximum).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.UnwinderThicknessCalculatedValueAverage).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.TensionInletValueActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.TensionInletValueMininimum).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.TensionInletValueMaximum).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.TensionInletValueAverage).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.TensionOutletValueActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.TensionOutletValueMinimum).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.TensionOutletValueMaximum).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.TensionOutletValueAverage).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.ApplyingUnitBearingLeftSideForceSilitPattern).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.ApplyingUnitBearingLeftSideActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.ApplyingUnitBearingRightSideForceSilitPattern).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.ApplyingUnitBearingRightSideActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.RelativeApplyingSpeedActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.RelativeApplyingSpeedSilitPattern).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.ApplyingUnitMinSpeedSilitPattern).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.ApplyingRollerOneTorqueActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.ApplyingRollerOneTorqueMinimum).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.ApplyingRollerOneTorqueMaximum).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.ApplyingRollerOneTorqueAverage).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.ApplyingRollerTwoTorqueActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.ApplyingRollerTwoTorqueMinimum).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.ApplyingRollerTwoTorqueMaximum).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.ApplyingRollerTwoTorqueAverage).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.ImmersionRollerOneTorqueActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.ImmersionRollerOneTorqueMinimum).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.ImmersionRollerOneTorqueMaximum).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.ImmersionRollerOneTorqueAverage).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.ImmersionRollerTwoTorqueActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.ImmersionRollerTwoTorqueMinimum).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.ImmersionRollerTwoTorqueMaximum).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.ImmersionRollerTwoTorqueAverage).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.ApplyingRollOneDiameter).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.ApplyingRollTwoDiameter).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.RollTwoTwoDiameter).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.RollTwoThreeDiameter).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.ApplingUnitTempTrayOneSilitPattern).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.ApplingUnitTempTrayTwoSilitPattern).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.ApplingUnitTempTrayOneActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.ApplingUnitTempTrayOneMinimum).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.ApplingUnitTempTrayOneMaximum).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.ApplingUnitTempTrayOneAverage).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.ApplingUnitTempTrayTwoActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.ApplingUnitTempTrayTwoMinimum).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.ApplingUnitTempTrayTwoMaximum).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.ApplingUnitTempTrayTwoAverage).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.AccelerationTimeActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.TransportMachineRPMActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.TransportMachineRPMMinimum).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.TransportMachineRPMMaximum).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.TransportMachineRPMAverage).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.RewinderOneTensionAbsActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.RewinderOneTensionAbsMinimum).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.RewinderOneTensionAbsMaximum).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.RewinderOneTensionAbsAverage).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.RewinderOneContactPressureActuel).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.RewinderOneContactPressureMinimum).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.RewinderOneContactPressureMaximum).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.RewinderOneContactPressureAverage).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.RewinderTwoTensionAbActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.RewinderTwoTensionAbsMinimum).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.RewinderTwoTensionAbsMaximum).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.RewinderTwoTensionAbsAverage).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.RewinderTwoContactPressureActuel).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.RewinderTwoContactPressureMinimum).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.RewinderTwoContactPressureMaximum).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.RewinderTwoContactPressureAverage).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.PositionInletRollActuel).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.PositionOutletRollOneActuel).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.PositionOutletRollTwoActuel).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.PositionContactRollOneActuel).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.PositionContactRollTwoActuel).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.LubricatorAutoOnOff).InclusiveBetween(false, true);

            RuleFor(x => x.RewinderOneGapModeOnOff).InclusiveBetween(false, true);

            RuleFor(x => x.RewinderOneContactPositionOnOff).InclusiveBetween(false, true);

            RuleFor(x => x.RewinderOneContactForcePositionOnOff).InclusiveBetween(false, true);

            RuleFor(x => x.RewinderOnePreSelectionOnOff).InclusiveBetween(false, true);

            RuleFor(x => x.RewinderTwoGapModeOnOff).InclusiveBetween(false, true);

            RuleFor(x => x.RewinderTwoContactPositionOnOff).InclusiveBetween(false, true);

            RuleFor(x => x.RewinderTwoContactForcePositionOnOff).InclusiveBetween(false, true);

            RuleFor(x => x.RewinderTwoPreSelectionOnOff).InclusiveBetween(false, true);

            RuleFor(x => x.SlittingWidthRewinderOneSilitPattern).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.SlittingWidthRewinderTwoSilitPattern).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.PrecutterOneRpmActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.PrecutterOneRpmMinimum).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.PrecutterOneRpmMaximum).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.PrecutterOneRpmAverage).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.PrecutterTwoRpmActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.PrecutterTwoRpmMinimum).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.PrecutterTwoRpmMaximum).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.PrecutterTwoRpmAverage).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.SuctionRpmActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.SuctionRpmMinimum).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.SuctionRpmMaximum).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.SuctionRpmAverage).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.PrecutterOneTwoOnOff).InclusiveBetween(false, true);

            RuleFor(x => x.BoosterOnOff).InclusiveBetween(false, true);

            RuleFor(x => x.SuctionOnOff).InclusiveBetween(false, true);

            RuleFor(x => x.BoosterSortOneOnOff).InclusiveBetween(false, true);

            RuleFor(x => x.BoosterSortTwoOnOff).InclusiveBetween(false, true);

            RuleFor(x => x.BoosterSortThreeOnOff).InclusiveBetween(false, true);

            RuleFor(x => x.AirFlapOneActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.AirFlapOneMinimum).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.AirFlapOneMaximum).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.AirFlapOneAverage).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.AirFlapTwoActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.AirFlapTwoMinimum).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.AirFlapTwoMaximum).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.AirFlapTwoAverage).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.RollWidthTwoOneOnOff).InclusiveBetween(false, true);

            RuleFor(x => x.RollWidthTwoTwoOnOff).InclusiveBetween(false, true);

            RuleFor(x => x.RollWidthFourOnOff).InclusiveBetween(false, true);

            RuleFor(x => x.RollWidthOneThreeSpeedActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.RollWidthOneThreeSpeedMinimum).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.RollWidthOneThreeSpeedMaximum).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.RollWidthOneThreeSpeedAverage).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.RollWidthOneFourSpeedActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.RollWidthOneFourSpeedMinimum).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.RollWidthOneFourSpeedMaximum).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.RollWidthOneFourSpeedAverage).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.OverlapValueActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.OverlapValueMininimum).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.OverlapValueMaximum).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.OverlapValueAverage).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.OvergapValueActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.OvergapValueMinimum).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.OvergapValueMaximum).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.OvergapValueAverage).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.UsedTramRollOneNumber).Length(2, 15);

            RuleFor(x => x.UsedTramRollTwoNumber).Length(2, 15);

            RuleFor(x => x.UsedContactRollOneNumber).Length(2, 15);

            RuleFor(x => x.UsedContactRollTwoNumber).Length(2, 15);

            RuleFor(x => x.UsedApplyingRollOneNumber).Length(2, 15);

            RuleFor(x => x.UsedApplyingRollTwoNumber).Length(2, 15);

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}