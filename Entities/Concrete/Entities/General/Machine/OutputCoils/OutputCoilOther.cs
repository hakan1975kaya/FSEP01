using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Entities.General.Machine.OutputCoils
{
    public class OutputCoilOther : IEntity
    {
        public Guid Id { get; set; }
        public Guid InputCoilId { get; set; }
        public int? UnwinderlLength { get; set; }//0
        public decimal? UnwinderThickness { get; set; }//75.00
        public decimal? UnwinderThicknessCalculatedValueActuel { get; set; }// Çözücü Kalınlık Hesaplanan Değer Gerçek 60.40
        public decimal? UnwinderThicknessCalculatedValueMinimum { get; set; }//48.70
        public decimal? UnwinderThicknessCalculatedValueMaximum { get; set; }//61.40
        public decimal? UnwinderThicknessCalculatedValueAverage { get; set; }//57.29
        public short? TensionInletValueActuel { get; set; }//Gerginlik Giriş Değer iMinimum 3332
        public short? TensionInletValueMininimum { get; set; }//Gerginlik Giriş Değer iMinimum 3332
        public short? TensionInletValueMaximum { get; set; }//5920
        public short? TensionInletValueAverage { get; set; }//5084
        public short? TensionOutletValueActuel { get; set; }//2927
        public short? TensionOutletValueMinimum { get; set; }//2713
        public short? TensionOutletValueMaximum { get; set; }//6019
        public short? TensionOutletValueAverage { get; set; }//5406
        public short? ApplyingUnitBearingLeftSideForceSilitPattern { get; set; }//Uygulama Ünite Rulman Sol Yan Kuvvet Silit Model 500
        public short? ApplyingUnitBearingLeftSideActuel { get; set; }//3
        public short? ApplyingUnitBearingRightSideForceSilitPattern { get; set; }//500
        public short? ApplyingUnitBearingRightSideActuel { get; set; }//6553
        public short? RelativeApplyingSpeedActuel { get; set; }//Göreceli Uygulama Hızı Gerçek 1
        public short? RelativeApplyingSpeedSilitPattern { get; set; }//5
        public short? ApplyingUnitMinSpeedSilitPattern { get; set; }//3
        public short? ApplyingRollerOneTorqueActuel { get; set; }//Roller One Torkunun Gerçek Değerinin Uygulanması 24
        public short? ApplyingRollerOneTorqueMinimum { get; set; }//10
        public short? ApplyingRollerOneTorqueMaximum { get; set; }//6551
        public short? ApplyingRollerOneTorqueAverage { get; set; }//5960
        public short? ApplyingRollerTwoTorqueActuel { get; set; }//38
        public short? ApplyingRollerTwoTorqueMinimum { get; set; }//5
        public short? ApplyingRollerTwoTorqueMaximum { get; set; }//6545
        public short? ApplyingRollerTwoTorqueAverage { get; set; }//6129
        public short? ImmersionRollerOneTorqueActuel { get; set; }//Daldırma Silindiri Bir Tork Gerçek 163
        public short? ImmersionRollerOneTorqueMinimum { get; set; }//0
        public short? ImmersionRollerOneTorqueMaximum { get; set; }//6553
        public short? ImmersionRollerOneTorqueAverage { get; set; }//200
        public short? ImmersionRollerTwoTorqueActuel { get; set; }//149
        public short? ImmersionRollerTwoTorqueMinimum { get; set; }//0
        public short? ImmersionRollerTwoTorqueMaximum { get; set; }//6553
        public short? ImmersionRollerTwoTorqueAverage { get; set; }//6002
        public decimal? ApplyingRollOneDiameter { get; set; }//Bir Çaplı Rulo Uygulama 244.91
        public decimal? ApplyingRollTwoDiameter { get; set; }//245.25
        public decimal? ImmersionRollOneDiameter { get; set; }//246.18
        public decimal? ImmersionRollTwoDiameter { get; set; }//246.16
        public decimal? RollTwoTwoDiameter { get; set; }//345.03
        public decimal? RollTwoThreeDiameter { get; set; }//345.06
        public short? ApplingUnitTempTrayOneSilitPattern { get; set; }//75
        public short? ApplingUnitTempTrayTwoSilitPattern { get; set; }//75
        public short? ApplingUnitTempTrayOneActuel { get; set; }//Uygulama Ünitesi Sıcaklık Tepsisi Bir Gerçek 70
        public short? ApplingUnitTempTrayOneMinimum { get; set; }//68
        public short? ApplingUnitTempTrayOneMaximum { get; set; }//74
        public short? ApplingUnitTempTrayOneAverage { get; set; }//69
        public short? ApplingUnitTempTrayTwoActuel { get; set; }//67
        public short? ApplingUnitTempTrayTwoMinimum { get; set; }//67
        public short? ApplingUnitTempTrayTwoMaximum { get; set; }//73
        public short? ApplingUnitTempTrayTwoAverage { get; set; }//70
        public short? AccelerationTimeActuel { get; set; }//Hızlanma Süresi Gerçek300
        public short? TransportMachineRPMActuel { get; set; }//0
        public short? TransportMachineRPMMinimum { get; set; }//0
        public short? TransportMachineRPMMaximum { get; set; }//6553
        public short? TransportMachineRPMAverage { get; set; }//676
        public short? RewinderOneTensionAbsActuel { get; set; }//560
        public short? RewinderOneTensionAbsMinimum { get; set; }//560
        public short? RewinderOneTensionAbsMaximum { get; set; }//2978
        public short? RewinderOneTensionAbsAverage { get; set; }//2748
        public decimal? RewinderOneContactPressureActuel { get; set; }//0.65
        public decimal? RewinderOneContactPressureMinimum { get; set; }//0.65
        public decimal? RewinderOneContactPressureMaximum { get; set; }//0.65
        public decimal? RewinderOneContactPressureAverage { get; set; }//0.65
        public short? RewinderTwoTensionAbActuel { get; set; }//317
        public short? RewinderTwoTensionAbsMinimum { get; set; }//317
        public short? RewinderTwoTensionAbsMaximum { get; set; }//1686
        public short? RewinderTwoTensionAbsAverage { get; set; }//1554
        public decimal? RewinderTwoContactPressureActuel { get; set; }//0.65
        public decimal? RewinderTwoContactPressureMinimum { get; set; }//0.65
        public decimal? RewinderTwoContactPressureMaximum { get; set; }//0.65
        public decimal? RewinderTwoContactPressureAverage { get; set; }//0.65
        public int? PositionInletRollActuel { get; set; }//Çıkış Çıkışı Bir Rulo Konumu Gerçek 229
        public int? PositionOutletRollOneActuel { get; set; }//943
        public int? PositionOutletRollTwoActuel { get; set; }//182
        public int? PositionContactRollOneActuel { get; set; }//20
        public int? PositionContactRollTwoActuel { get; set; }//21
        public bool? LubricatorAutoOnOff { get; set; }//0x31
        public bool? RewinderOneGapModeOnOff { get; set; }// Geri Sarma Tek Boşluk Modu Açık Kapalı 0x30
        public bool? RewinderOneContactPositionOnOff { get; set; }//0x31
        public bool? RewinderOneContactForcePositionOnOff { get; set; }//0x31
        public bool? RewinderOnePreSelectionOnOff { get; set; }//0x31
        public bool? RewinderTwoGapModeOnOff { get; set; }//0x31
        public bool? RewinderTwoContactPositionOnOff { get; set; }//0x31
        public bool? RewinderTwoContactForcePositionOnOff { get; set; }//0x31
        public bool? RewinderTwoPreSelectionOnOff { get; set; }//0x31
        public short? SlittingWidthRewinderOneSilitPattern { get; set; }//Dilme Genişlik Geri Sarma Bir Silit Desen 75.00
        public short? SlittingWidthRewinderTwoSilitPattern { get; set; }//75.00
        public short? PrecutterOneRpmActuel { get; set; }//1325
        public short? PrecutterOneRpmMinimum { get; set; }//750
        public short? PrecutterOneRpmMaximum { get; set; }//0
        public short? PrecutterOneRpmAverage { get; set; }//0
        public short? PrecutterTwoRpmActuel { get; set; }//0
        public short? PrecutterTwoRpmMinimum { get; set; }//0
        public short? PrecutterTwoRpmMaximum { get; set; }//0
        public short? PrecutterTwoRpmAverage { get; set; }//0
        public short? SuctionRpmActuel { get; set; }// Emme Rpm Gerçek 0
        public short? SuctionRpmMinimum { get; set; }//0
        public short? SuctionRpmMaximum { get; set; }//0
        public short? SuctionRpmAverage { get; set; }//0
        public bool? PrecutterOneTwoOnOff { get; set; }//0
        public bool? BoosterOnOff { get; set; }//Güçlendirici Açık Kapalı0x30
        public bool? SuctionOnOff { get; set; }//0x30
        public bool? BoosterSortOneOnOff { get; set; }//0x30
        public bool? BoosterSortTwoOnOff { get; set; }//0x30
        public bool? BoosterSortThreeOnOff { get; set; }//0x30
        public short? AirFlapOneActuel { get; set; }//Hava Flap Bir Gerçek 0
        public short? AirFlapOneMinimum { get; set; }//0
        public short? AirFlapOneMaximum { get; set; }//0
        public short? AirFlapOneAverage { get; set; }//0
        public short? AirFlapTwoActuel { get; set; }//0
        public short? AirFlapTwoMinimum { get; set; }//0
        public short? AirFlapTwoMaximum { get; set; }//0
        public short? AirFlapTwoAverage { get; set; }//0
        public bool? RollWidthTwoOneOnOff { get; set; }//0x30
        public bool? RollWidthTwoTwoOnOff { get; set; }//0x30
        public bool? RollWidthFourOnOff { get; set; }//0x30
        public short? RollWidthOneThreeSpeedActuel { get; set; }//6551
        public short? RollWidthOneThreeSpeedMinimum { get; set; }//5509
        public short? RollWidthOneThreeSpeedMaximum { get; set; }//0
        public short? RollWidthOneThreeSpeedAverage { get; set; }//0
        public short? RollWidthOneFourSpeedActuel { get; set; }//6551
        public short? RollWidthOneFourSpeedMinimum { get; set; }//6551
        public short? RollWidthOneFourSpeedMaximum { get; set; }//6551
        public short? RollWidthOneFourSpeedAverage { get; set; }//6551
        public short? OverlapValueActuel { get; set; }//0
        public short? OverlapValueMininimum { get; set; }//0
        public short? OverlapValueMaximum { get; set; }//Örtüşme Değeri Gerçek0
        public short? OverlapValueAverage { get; set; }//0
        public short? OvergapValueActuel { get; set; }//0
        public short? OvergapValueMinimum { get; set; }//0
        public short? OvergapValueMaximum { get; set; }//0
        public short? OvergapValueAverage { get; set; }//0
        public string? UsedTramRollOneNumber { get; set; }//İkinci El Tramvay Rulosu Tek Numara432-TM-01
        public string? UsedTramRollTwoNumber { get; set; }//432-TM-02
        public string? UsedContactRollOneNumber { get; set; }//431-CRS-02
        public string? UsedContactRollTwoNumber { get; set; }//431-CRS-04
        public string? UsedApplyingRollOneNumber { get; set; }//432-YM-03
        public string? UsedApplyingRollTwoNumber { get; set; }//432-YM-04
        public DateTime Optime { get; set; }
        public bool IsActive { get; set; }
    }
}