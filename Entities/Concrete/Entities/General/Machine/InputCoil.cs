using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.General.Machine
{
    public class InputCoil : IEntity
    {
        public Guid Id { get; set; }
        public int? RecipeNumber { get; set; }
        public string? LocalId { get; set; }
        public int? CoilStatusNumber { get; set; }
        public string? CoilStatus { get; set; }
        public string? Alloy { get; set; }
        public decimal? Thickness { get; set; }
        public decimal? Width { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Length { get; set; }
        public decimal? InnerDiameter { get; set; }
        public decimal? OuterDiameter { get; set; }
        public string? Temper { get; set; }
        public string? UsageArea { get; set; }
        public short? SetupGenerateStatusNumber { get; set; }
        public string? SetupGenerateStatusDescription { get; set; }
        public decimal? Gravity { get; set; }
        public string? MainCoilProductionId { get; set; }
        public string? SurfaceCondition { get; set; }
        public string? Location { get; set; }
        public DateTime? DeadLine { get; set; }
        public string? BlockedFlag { get; set; }
        public string? TerstenAc { get; set; }
        public string? PreviousPositionSteps { get; set; }
        public string? NextPositionSteps { get; set; }
        public DateTime? LastProductionTime { get; set; }
        public string? Comment { get; set; }
        public string? ProductionRemark { get; set; }
        public short? ExitSpoolInnerDiameter { get; set; }
        public string? ExitSpoolType { get; set; }
        public string? SpoolProtrusion { get; set; }
        public decimal? BurrHeight { get; set; }
        public decimal? CoilWeightMaximum { get; set; }
        public decimal? CoilWeightMinimum { get; set; }
        public decimal? EdgeWaveHeightMaximum { get; set; }
        public decimal? FoilAvgerageThicknessTolerance { get; set; }
        public int? LengthInMeters { get; set; }
        public short? LengthInMetersToleranceMaximum { get; set; }
        public short? LengthInMetersToleranceMinimum { get; set; }
        public short? NumberOfEdgeWavePerMeter { get; set; }
        public short? NumberOfSplicesPerCoilMaximum { get; set; }
        public string? PackageCode { get; set; }
        public short? MinimumAmountOfLubrication { get; set; }
        public short? MaximumAmountOfLubrication { get; set; }
        public decimal? SOIThickness { get; set; }
        public decimal? ThicknessAim { get; set; }
        public decimal? ThicknessToleranceMaximum { get; set; }
        public decimal? ThicknessToleranceMinimum { get; set; }
        public short? MinimumOuterDiameter { get; set; }
        public short? MaximumOuterDiameter { get; set; }
        public short? WidthAim { get; set; }
        public decimal? WidthToleranceMaximum { get; set; }
        public decimal? WidthToleranceMinimum { get; set; }
        public string? CustomerName { get; set; }
        public bool? ReSendSetupToleranceOne { get; set; }
        public decimal? RemainingWeight { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}
