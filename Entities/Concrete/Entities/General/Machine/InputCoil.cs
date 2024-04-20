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
        public int? RecipeNumber { get; set; }//Tarif Numarası1 7
        public string? LocalId { get; set; }//122080796.02
        public int? CoilStatusNumber { get; set; }// Bobin Durum Numarası 7
        public string? CoilStatus { get; set; }//Consumed
        public string? Alloy { get; set; }//82020
        public decimal? Thickness { get; set; }//Kalınlık 0.0670
        public decimal? Width { get; set; }//1960.00
        public decimal? Weight { get; set; }//10850.00
        public decimal? Length { get; set; }//30375.91
        public decimal? InnerDiameter { get; set; }//665.00
        public decimal? OuterDiameter { get; set; }//1748.00
        public string? Temper { get; set; }//çeliğe verilen su 1240
        public string? UsageArea { get; set; }//Kullanım Alanı CONTAINER FOIL
        public short? SetupGenerateStatusNumber { get; set; }//30
        public string? SetupGenerateStatusDescription { get; set; }//Good
        public decimal? Gravity { get; set; }//2.72
        public string? MainCoilProductionId { get; set; }//1249454741
        public string? SurfaceCondition { get; set; }//Yüzey durumu B/B
        public string? Location { get; set; }//BefFSLT01-02
        public DateTime? DeadLine { get; set; }//Son teslim tarihi 1977-01-01 00:00:00
        public string? BlockedFlag { get; set; }//Engellenen Bayrak N
        public string? TerstenAc { get; set; }//N
        public string? PreviousPositionSteps { get; set; }//COOL
        public string? NextPositionSteps { get; set; }//MPACK
        public DateTime? LastProductionTime { get; set; }//2022-12-16 10:47:13
        public string? Comment { get; set; }//SH DKT! 0,679 MMDE İÇ BUKLE VAR KONTROLLÜ ÇALIŞ 29.11.22
        public string? ProductionRemark { get; set; }//ÜretimAçıklama
        public short? ExitSpoolInnerDiameter { get; set; }//Çıkış Makara İç Çap 150
        public string? ExitSpoolType { get; set; }//Çıkış Makara Türü ALUMINUM/STEEL
        public string? SpoolProtrusion { get; set; }//Makara Çıkıntısı 0
        public decimal? BurrHeight { get; set; }//Çapak Yüksekliği 0
        public decimal? CoilWeightMaximum { get; set; }//646.00
        public decimal? CoilWeightMinimum { get; set; }//447.00
        public decimal? EdgeWaveHeightMaximum { get; set; }//0.00
        public decimal? FoilAvgerageThicknessTolerance { get; set; }//Folyo Ortalama Kalınlık Toleransı 0.00
        public int? LengthInMeters { get; set; }//0
        public short? LengthInMetersToleranceMaximum { get; set; }//Metre Olarak Uzunluk 0
        public short? LengthInMetersToleranceMinimum { get; set; }//0
        public short? NumberOfEdgeWavePerMeter { get; set; }//Metre Başına Kenar Dalga Sayısı 0
        public short? NumberOfSplicesPerCoilMaximum { get; set; }//Bobin Başına Ekleme Sayısı Maksimum 1
        public string? PackageCode { get; set; }//PaketKodu 4A/1B EPAL
        public short? MinimumAmountOfLubrication { get; set; }//Minimum Yağlama Miktarı400
        public short? MaximumAmountOfLubrication { get; set; }//600
        public decimal? SOIThickness { get; set; }//0.0670
        public decimal? ThicknessAim { get; set; }//0.0670
        public decimal? ThicknessToleranceMaximum { get; set; }//0.0027
        public decimal? ThicknessToleranceMinimum { get; set; }//-0.0027
        public short? MinimumOuterDiameter { get; set; }//600
        public short? MaximumOuterDiameter { get; set; }//714
        public short? WidthAim { get; set; }//GenişlikHedef i598
        public decimal? WidthToleranceMaximum { get; set; }//0.50
        public decimal? WidthToleranceMinimum { get; set; }//-0.50
        public string? CustomerName { get; set; }//CUKI COFRESCO SRL
        public bool? ReSendSetupToleranceOne { get; set; }//0x31
        public decimal? RemainingWeight { get; set; }//Kalan Ağırlık 3536.95
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}

				