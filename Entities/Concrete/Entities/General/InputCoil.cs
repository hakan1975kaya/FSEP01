using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.General
{
    public class InputCoil : IEntity
    {
        public Guid Id { get; set; }
        public int RecipeNumber { get; set; }
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
        public string? POId { get; set; }
        public string? SurfCD { get; set; }
        public string? Location { get; set; }
        public DateTime? DeadLine { get; set; }
        public string? BlokedFlag { get; set; }
        public string? TerstenAc { get; set; }
        public string? PrevPOStep { get; set; }
        public string? NextPOStep { get; set; }
        public DateTime? LastProductionTime { get; set; }
        public string? Comment { get; set; }
        public string? PORemark { get; set; }
        public short? ExitSpoolInnerDiameter { get; set; }
        public string? ExitSpoolType { get; set; }
        public string? SpoolProtrusion { get; set; }
        public decimal? BurrHeight { get; set; }
        public decimal? CoilWeightMax { get; set; }
        public decimal? CoilWeightMin { get; set; }
        public decimal? EdgeWaveHeightMax { get; set; }
        public decimal? FoilAvgThicknessTolerance { get; set; }
        public int? LengthInMeters { get; set; }
        public short? LengthInMetersToleranceMax { get; set; }
        public short? LengthInMetersToleranceMin { get; set; }
        public short? NumberOfEdgeWavePerMeter { get; set; }
        public short? NumberOfSplicesPerCoilMax { get; set; }
        public string? PackageCode { get; set; }
        public short? MinAmountOfLubrication { get; set; }
        public short? MaxAmountOfLubrication { get; set; }
        public decimal? SOIThickness { get; set; }
        public decimal? ThicknessAim { get; set; }
        public decimal? ThicknessToleranceMax { get; set; }
        public decimal? ThicknessToleranceMin { get; set; }
        public short? MinimumOuterDiameter { get; set; }
        public short? MaximumOuterDiameter { get; set; }
        public short? WidthAim { get; set; }
        public decimal? WidthTeranceMax { get; set; }
        public decimal? WidthTeranceMin { get; set; }
        public string? CustomerName { get; set; }
        public bool? ReSendSetupToLOne { get; set; }
        public decimal? RemainingWeight { get; set; }
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}
