using Core.Entities.Concrete;
using Entities.Concrete.Entities.General.Machine.General;
using Entities.Concrete.Entities.General.Machine.ProcessCoils;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.FluentValidators.General.General.DemandValidators
{
    public class ProcessCoilValidator : AbstractValidator<ProcessCoil>
    {
        public ProcessCoilValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.InputCoilId).NotEmpty();

            RuleFor(x => x.LocalId).Length(2, 20);

            RuleFor(x => x.UnwinderActuelDiameter).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.RewinderOneActuelDiameter).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.RewinderOneActuelLength).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.RewinderTwoActuelDiameter).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.RewinderTwoActuelLength).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.TransportOneTensionActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.TransportTwoTensionActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.RewinderOneActuelTension).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.RewinderOneActuelContactPressure).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.RewinderTwoActuelTension).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.RewinderTwoActuelContactPressure).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.MachineActuelSpeed).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.MachineOn).InclusiveBetween(false, true);

            RuleFor(x => x.RewinderOneCrossCuttingApplied).InclusiveBetween(false, true);

            RuleFor(x => x.RewinderTwoCrossCuttingApplied).InclusiveBetween(false, true);

            RuleFor(x => x.RewinderOneUnloadSequenceActive).InclusiveBetween(false, true);

            RuleFor(x => x.RewinderTwoUnloadSequenceActive).InclusiveBetween(false, true);

            RuleFor(x => x.ComminicationCounterFromPLC).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.UnwinderActuelLength).InclusiveBetween(int.MinValue, int.MaxValue);

            RuleFor(x => x.UnwinderThickness).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.UnwinderThicknessCalculateValueActuel).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.MachineActuelSpeed).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.TensionInletValueActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.TensionOutletValueActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.ApplyingUnitBearingLeftSideForceSilitPattern).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.ApplyingUnitBearingLeftSideActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.ApplyingUnitBearingRightsideForceSilitPattern).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.ApplyingUnitBearingRightSideActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.RelativeApplyingSpeedActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.RelativeApplyingSpeedSlitPatter).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.ApplyingUnitMinSpeedSlitPatter).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.ApplyingRollerOneTorqueActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.ApplyingRollerTwoTorqueActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.ImmersionRollerOneTorqueActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.ImmersionRollerTwoTorqueActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.ApplyingRollOneDiameter).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.ApplyingRollTwoDiameter).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.ImmersionRollOneDiameter).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.ImmersionRollTwoDiameter).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.RollTwoTwoDiameter).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.RollTwoThreeDiameter).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.ApplingUnitTempTrayOneSlitPattern).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.ApplingUnitTempTrayTwoSlitPattern).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.ApplingUnitTempTrayOneActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.ApplingUnitTempTrayTwoActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.AccelerationTimeActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.TransportMachineRPMActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.RewinderOneTensionAbsActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.RewinderOneContactPressureActuel).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

            RuleFor(x => x.RewinderTwoTensionAbsActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.RewinderTwoContactPressureActuel).InclusiveBetween(decimal.MinValue, decimal.MaxValue);

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

            RuleFor(x => x.SlittingWidthRewinderOneSlitPattern).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.SlittingWidthRewinderTwoSlitPattern).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.PrecutterOneRpmActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.PrecutterTwoRpmActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.SuctionRpmActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.PrecutterOneTwoOnOff).InclusiveBetween(false, true);

            RuleFor(x => x.BoosterOnOff).InclusiveBetween(false, true);

            RuleFor(x => x.SuctionOnOff).InclusiveBetween(false, true);

            RuleFor(x => x.BoosterSortOneOnOff).InclusiveBetween(false, true);

            RuleFor(x => x.BoosterSortTwoOnOff).InclusiveBetween(false, true);

            RuleFor(x => x.BoosterSortThreeOnOff).InclusiveBetween(false, true);

            RuleFor(x => x.AirFlapOneActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.AirFlapTwoActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.RollRollWidthTwoOneOnOff).InclusiveBetween(false, true);

            RuleFor(x => x.RollWidthTwoTwoOnOff).InclusiveBetween(false, true);

            RuleFor(x => x.RollWidthFourOnOff).InclusiveBetween(false, true);

            RuleFor(x => x.RollWidthThreeSpeedActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.RollWidthFourSpeedActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.OverlapValueActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.OvergapValueActuel).InclusiveBetween(short.MinValue, short.MaxValue);

            RuleFor(x => x.ProductionStart).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.ProductionEnd).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.Optime).NotEmpty();
            RuleFor(x => x.Optime).LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.IsActive).NotEmpty();
            RuleFor(x => x.IsActive).InclusiveBetween(false, true);
        }
    }
}
