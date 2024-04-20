using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.General.Machine.ProcessCoils
{
    public class ProcessCoil : IEntity
    {
        public Guid Id { get; set; }
        public Guid InputCoilId { get; set; }
        public string? LocalId { get; set; }
        public short? UnwinderActuelDiameter { get; set; }
        public short? RewinderOneActuelDiameter { get; set; }
        public int? RewinderOneActuelLength { get; set; }
        public short? RewinderTwoActuelDiameter { get; set; }
        public int? RewinderTwoActuelLength { get; set; }
        public short? TransportOneTensionActuel { get; set; }
        public short? TransportTwoTensionActuel { get; set; }
        public short? RewinderOneActuelTension { get; set; }
        public decimal? RewinderOneActuelContactPressure { get; set; }
        public short? RewinderTwoActuelTension { get; set; }
        public decimal? RewinderTwoActuelContactPressure { get; set; }
        public short? MachineActuelSpeed { get; set; }
        public bool? MachineOn { get; set; }
        public bool? RewinderOneCrossCuttingApplied { get; set; }
        public bool? RewinderTwoCrossCuttingApplied { get; set; }
        public bool? RewinderOneUnloadSequenceActive { get; set; }
        public bool? RewinderTwoUnloadSequenceActive { get; set; }
        public int? ComminicationCounterFromPLC { get; set; }
        public int? UnwinderActuelLength { get; set; }
        public decimal? UnwinderThickness { get; set; }
        public decimal? UnwinderThicknessCalculateValueActuel { get; set; }
        public short? TensionInletValueActuel { get; set; }
        public short? TensionOutletValueActuel { get; set; }
        public short? ApplyingUnitBearingLeftSideForceSilitPattern { get; set; }
        public short? ApplyingUnitBearingLeftSideActuel { get; set; }
        public short? ApplyingUnitBearingRightsideForceSilitPattern { get; set; }
        public short? ApplyingUnitBearingRightSideActuel { get; set; }
        public short? RelativeApplyingSpeedActuel { get; set; }
        public short? RelativeApplyingSpeedSlitPatter { get; set; }
        public short? ApplyingUnitMinSpeedSlitPatter { get; set; }
        public short? ApplyingRollerOneTorqueActuel { get; set; }
        public short? ApplyingRollerTwoTorqueActuel { get; set; }
        public short? ImmersionRollerOneTorqueActuel { get; set; }
        public short? ImmersionRollerTwoTorqueActuel { get; set; }
        public decimal? ApplyingRollOneDiameter { get; set; }
        public decimal? ApplyingRollTwoDiameter { get; set; }
        public decimal? ImmersionRollOneDiameter { get; set; }
        public decimal? ImmersionRollTwoDiameter { get; set; }
        public decimal? RollTwoTwoDiameter { get; set; }
        public decimal? RollTwoThreeDiameter { get; set; }
        public short? ApplingUnitTempTrayOneSlitPattern { get; set; }
        public short? ApplingUnitTempTrayTwoSlitPattern { get; set; }
        public short? ApplingUnitTempTrayOneActuel { get; set; }
        public short? ApplingUnitTempTrayTwoActuel { get; set; }
        public short? AccelerationTimeActuel { get; set; }
        public short? TransportMachineRPMActuel { get; set; }
        public short? RewinderOneTensionAbsActuel { get; set; }
        public decimal? RewinderOneContactPressureActuel { get; set; }
        public decimal? RewinderTwoTensionAbsActuel { get; set; }
        public decimal? RewinderTwoContactPressureActuel { get; set; }
        public int? PositionInletRollActuel { get; set; }
        public int? PositionOutletRollOneActuel { get; set; }
        public int? PositionOutletRollTwoActuel { get; set; }
        public int? PositionContactRollOneActuel { get; set; }
        public int? PositionContactRollTwoActuel { get; set; }
        public bool? LubricatorAutoOnOff { get; set; }
        public bool? RewinderOneGapModeOnOff { get; set; }
        public bool? RewinderOneContactPositionOnOff { get; set; }
        public bool? RewinderOneContactForcePositionOnOff { get; set; }
        public bool? RewinderOnePreSelectionOnOff { get; set; }
        public bool? RewinderTwoGapModeOnOff { get; set; }
        public bool? RewinderTwoContactPositionOnOff { get; set; }
        public bool? RewinderTwoContactForcePositionOnOff { get; set; }
        public bool? RewinderTwoPreSelectionOnOff { get; set; }
        public short? SlittingWidthRewinderOneSlitPattern { get; set; }
        public short? SlittingWidthRewinderTwoSlitPattern { get; set; }
        public short? PrecutterOneRpmActuel { get; set; }
        public short? PrecutterTwoRpmActuel { get; set; }
        public short? SuctionRpmActuel { get; set; }
        public bool? PrecutterOneTwoOnOff { get; set; }
        public bool? BoosterOnOff { get; set; }
        public bool? SuctionOnOff { get; set; }
        public bool? BoosterSortOneOnOff { get; set; }
        public bool? BoosterSortTwoOnOff { get; set; }
        public bool? BoosterSortThreeOnOff { get; set; }
        public short? AirFlapOneActuel { get; set; }
        public short? AirFlapTwoActuel { get; set; }
        public bool? RollRollWidthTwoOneOnOff { get; set; }
        public bool? RollWidthTwoTwoOnOff { get; set; }
        public short? RollWidthFourOnOff { get; set; }
        public short? RollWidthThreeSpeedActuel { get; set; }
        public short? RollWidthFourSpeedActuel { get; set; }
        public short? OverlapValueActuel { get; set; }
        public short? OvergapValueActuel { get; set; }
        public DateTime? ProductionStart { get; set; }
        public DateTime? ProductionEnd { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}