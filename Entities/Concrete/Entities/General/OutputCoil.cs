﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.General
{
    public class OutputCoil:IEntity
    {
        public Guid Id { get; set; }
        public Guid InputCoilId { get; set; }
        public Guid ProcessCoilId { get; set; }
        public int? UnwinderActLength { get; set; }
        public decimal? UnwinderThickness { get; set; }
        public decimal? UnwinderThicknessCalcValueAct { get; set; }
        public decimal? UnwinderThicknessCalcValueMin { get; set; }
        public decimal? UnwinderThicknessCalcValueMax { get; set; }
        public decimal? UnwinderThicknessCalcValueAvg { get; set; }
        public short? TensionInletValueAct { get; set; }
        public short? TensionInletValueMin { get; set; }
        public short? TensionInletValueMax { get; set; }
        public short? TensionInletValueAvg { get; set; }
        public short? TensionOutletValueAct { get; set; }
        public short? TensionOutletValueMin { get; set; }
        public short? TensionOutletValueMax { get; set; }
        public short? TensionOutletValueAvg { get; set; }
        public short? ApplyingUnitBearingLeftsideForceSP { get; set; }
        public short? ApplyingUnitBearingLeftsideAct { get; set; }
        public short? ApplyingUnitBearingRightsideForceSP { get; set; }
        public short? ApplyingUnitBearingRightsideAct { get; set; }
        public short? RelativeApplyingSpeedAct { get; set; }
        public short? RelativeApplyingSpeedSP { get; set; }
        public short? ApplyingUnitMinSpeedSP { get; set; }
        public short? ApplyingRollerOneTorqueAct { get; set; }
        public short? ApplyingRollerOneTorqueMin { get; set; }
        public short? ApplyingRollerOneTorqueMax { get; set; }
        public short? ApplyingRollerOneTorqueAvg { get; set; }
        public short? ApplyingRollerTwoTorqueAct { get; set; }
        public short? ApplyingRollerTwoTorqueMin { get; set; }
        public short? ApplyingRollerTwoTorqueMax { get; set; }
        public short? ApplyingRollerTwoTorqueAvg { get; set; }
        public short? ImmersionRollerOneTorqueAct { get; set; }
        public short? ImmersionRollerOneTorqueMin { get; set; }
        public short? ImmersionRollerOneTorqueMax { get; set; }
        public short? ImmersionRollerOneTorqueAvg { get; set; }
        public short? ImmersionRollerTwoTorqueAct { get; set; }
        public short? ImmersionRollerTwoTorqueMin { get; set; }
        public short? ImmersionRollerTwoTorqueMax { get; set; }
        public short? ImmersionRollerTwoTorqueAvg { get; set; }
        public decimal? ApplyingRollOneDiameter { get; set; }
        public decimal? ApplyingRollTwoDiameter { get; set; }
        public decimal? ImmersionRollOneDiameter { get; set; }
        public decimal? ImmersionRollTwoDiameter { get; set; }
        public decimal? RollTwoTwoDiameter { get; set; }
        public decimal? RollTwoThreeDiameter { get; set; }
        public short? ApplingUnitTempTrayOneSP { get; set; }
        public short? ApplingUnitTempTrayTwoSP { get; set; }
        public short? ApplingUnitTempTrayOneAct { get; set; }
        public short? ApplingUnitTempTrayOneMin { get; set; }
        public short? ApplingUnitTempTrayOneMax { get; set; }
        public short? ApplingUnitTempTrayOneAvg { get; set; }
        public short? ApplingUnitTempTrayTwoAct { get; set; }
        public short? ApplingUnitTempTrayTwoMin { get; set; }
        public short? ApplingUnitTempTrayTwoMax { get; set; }
        public short? ApplingUnitTempTrayTwoAvg { get; set; }
        public short? AccTimeAct { get; set; }
        public short? TransportMachineRPMAct { get; set; }
        public short? TransportMachineRPMMin { get; set; }
        public short? TransportMachineRPMMax { get; set; }
        public short? TransportMachineRPMAvg { get; set; }
        public short? RewinderOneTensionAbsAct { get; set; }
        public short? RewinderOneTensionAbsMin { get; set; }
        public short? RewinderOneTensionAbsMax { get; set; }
        public short? RewinderOneTensionAbsAvg { get; set; }
        public decimal? RewinderOneContactPressureAct { get; set; }
        public decimal? RewinderOneContactPressureMin { get; set; }
        public decimal? RewinderOneContactPressureMax { get; set; }
        public decimal? RewinderOneContactPressureAvg { get; set; }
        public short? RewinderTwoTensionAbsAct { get; set; }
        public short? RewinderTwoTensionAbsMin { get; set; }
        public short? RewinderTwoTensionAbsMax { get; set; }
        public short? RewinderTwoTensionAbsAvg { get; set; }
        public decimal? RewinderTwoContactPressureAct { get; set; }
        public decimal? RewinderTwoContactPressureMin { get; set; }
        public decimal? RewinderTwoContactPressureMax { get; set; }
        public decimal? RewinderTwoContactPressureAvg { get; set; }
        public int? PosInletRollAct { get; set; }
        public int? PosOutletRollOneAct { get; set; }
        public int? PosOutletRollTwoAct { get; set; }
        public int? PosContactRollOneAct { get; set; }
        public int? PosContactRollTwoAct { get; set; }
        public bool? LubricatorAutoOnOff { get; set; }
        public bool? RewinderOneGapModeOnOff { get; set; }
        public bool? RewinderOneContactPositionOnOff { get; set; }
        public bool? RewinderOneContactForcePositionOnOff { get; set; }
        public bool? RewinderOnePreSelectionOnOff { get; set; }
        public bool? RewinderTwoGapModeOnOff { get; set; }
        public bool? RewinderTwoContactPositionOnOff { get; set; }
        public bool? RewinderTwoContactForcePositionOnOff { get; set; }
        public bool? RewinderTwoPreSelectionOnOff { get; set; }
        public short? SlittingWidthRewOneSP { get; set; }
        public short? SlittingWidthRewTwoSP { get; set; }
        public short? PrecutterOneRpmAct { get; set; }
        public short? PrecutterOneRpmMin { get; set; }
        public short? PrecutterOneRpmMax { get; set; }
        public short? PrecutterOneRpmAvg { get; set; }
        public short? PrecutterTwoRpmAct { get; set; }
        public short? PrecutterTwoRpmMin { get; set; }
        public short? PrecutterTwoRpmMax { get; set; }
        public short? PrecutterTwoRpmAvg { get; set; }
        public short? SuctionRpmAct { get; set; }
        public short? SuctionRpmMin { get; set; }
        public short? SuctionRpmMax { get; set; }
        public short? SuctionRpmAvg { get; set; }
        public bool? PrecutterOneTwoOnOff { get; set; }
        public bool? BoosterOnOff { get; set; }
        public bool? SuctionOnOff { get; set; }
        public bool? BoosterSort1OnOff { get; set; }
        public bool? BoosterSort2OnOff { get; set; }
        public bool? BoosterSort3OnOff { get; set; }
        public short? AirFlapOneAct { get; set; }
        public short? AirFlapOneMin { get; set; }
        public short? AirFlapOneMax { get; set; }
        public short? AirFlapOneAvg { get; set; }
        public short? AirFlapTwoAct { get; set; }
        public short? AirFlapTwoMin { get; set; }
        public short? AirFlapTwoMax { get; set; }
        public short? AirFlapTwoAvg { get; set; }
        public bool? RollWTwoOneOnOff { get; set; }
        public bool? RollWTwoTwoOnOff { get; set; }
        public bool? RollWFourOnOff { get; set; }
        public short? RollWOneThreeSpeedAct { get; set; }
        public short? RollWOneThreeSpeedMin { get; set; }
        public short? RollWOneThreeSpeedMax { get; set; }
        public short? RollWOneThreeSpeedAvg { get; set; }
        public short? RollWOneFourSpeedAct { get; set; }
        public short? RollWOneFourSpeedMin { get; set; }
        public short? RollWOneFourSpeedMax { get; set; }
        public short? RollWOneFourSpeedAvg { get; set; }
        public short? OverlapValueAct { get; set; }
        public short? OverlapValueMin { get; set; }
        public short? OverlapValueMax { get; set; }
        public short? OverlapValueAvg { get; set; }
        public short? OvergapValueAct { get; set; }
        public short? OvergapValueMin { get; set; }
        public short? OvergapValueMax { get; set; }
        public short? OvergapValueAvg { get; set; }
        public string? UsedTramRollOneNumber { get; set; }
        public string? UsedTramRollTwoNumber { get; set; }
        public string? UsedContactRollOneNumber { get; set; }
        public string? UsedContactRollTwoNumber { get; set; }
        public string? UsedApplyingRollOneNumber { get; set; }
        public string? UsedApplyingRollTwoNumber { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}
